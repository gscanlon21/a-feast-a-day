using Core.Models;
using Core.Models.Ingredients;
using Core.Models.Recipe;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Data.Query.Builders;
using Data.Query.Options;
using Microsoft.Extensions.DependencyInjection;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query.Runners;

/// <summary>
/// Builds and runs an EF Core query for selecting recipes.
/// </summary>
public class QueryRunner : QueryRunnerBase
{
    public QueryRunner(Core.Models.Newsletter.Section section) : base(section) { }

    protected override IQueryable<Recipe> CreateRecipesQuery(CoreContext context)
    {
        return base.CreateRecipesQuery(context).Where(r => r.UserId == null);
    }

    protected override IQueryable<RecipesQueryResults> Map(IQueryable<Recipe> recipes)
    {
        return recipes.Select(r => new RecipesQueryResults()
        {
            Recipe = r,
            // Pull these out of the constructor so that EF Core can optimize the query.
            RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientQueryResults()
            {
                Id = ri.Id,
                Order = ri.Order,
                Group = ri.Group,
                Measure = ri.Measure,
                Optional = ri.Optional,
                CoarseCut = ri.CoarseCut,
                Adjustable = ri.Adjustable,
                Attributes = ri.Attributes,
                UserRecipeIngredient = null,
                CookedScale = ri.CookedScale,
                QuantityNumerator = ri.QuantityNumerator,
                QuantityDenominator = ri.QuantityDenominator,
                RawIngredientRecipeId = ri.IngredientRecipeId,
                Ingredient = ri.Ingredient == null ? null : new Ingredient(/* No constructor so EF Core can optimize the query */)
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Group = ri.Ingredient.Group,
                    Section = ri.Ingredient.Section,
                    Category = ri.Ingredient.Category,
                    FoodName = ri.Ingredient.FoodName,
                    Allergens = ri.Ingredient.Allergens,
                    DefaultMeasure = ri.Ingredient.DefaultMeasure,
                    GramsPerMeasure = ri.Ingredient.GramsPerMeasure,
                    GramsPerServing = ri.Ingredient.GramsPerServing,
                    GramsPerFineCup = ri.Ingredient.GramsPerFineCup,
                    GramsPerCoarseCup = ri.Ingredient.GramsPerCoarseCup,
                    SkipShoppingList = ri.Ingredient.SkipShoppingList,
                },
            }).ToList(),
        });
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public override async Task<List<QueryResults>> Query(IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
    {
        // Short-circut when this is set without any data. No results are returned.
        if (RecipeOptions.RecipeIds?.Any() == false)
        {
            return [];
        }

        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var queryResults = await QueryPartial(context);

        // Add in the prep recipe ingredients.
        var prepRecipes = await GetPrepRecipes(factory, queryResults);
        foreach (var queryResult in queryResults)
        {
            foreach (var recipeIngredientRecipe in queryResult.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe))
            {
                // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                recipeIngredientRecipe.IngredientRecipe = prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredientRecipe.IngredientRecipeId)
                    // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                    ?? prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredientRecipe.RawIngredientRecipeId);
            }
        }

        // List size doesn't change. Use the same capacity as the orderedResults.
        var recipeResults = new List<QueryResults>(queryResults.Count);
        foreach (var recipe in queryResults)
        {
            // Order the recipe ingredients based on user preferences. Always order recipes before ingredients.
            recipe.RecipeIngredients = ((recipe.Recipe.KeepIngredientOrder, IngredientOrder.OrderUsed) switch
            {
                (false, IngredientOrder.OptionalLast) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Optional).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                (false, IngredientOrder.LargeToSmall) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                _ => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Order),
            }).ToList();

            recipeResults.Add(new QueryResults(section, recipe.Recipe, recipe.RecipeIngredients, recipe.UserRecipe)
            {
                // Scaling the recipe will also scale the recipe ingredient quantities which then affects ingredient recipe scales.
                SetScale = (RecipeOptions.RecipeIds?.TryGetValue(recipe.Recipe.Id, out int? scale) == true && scale.HasValue) ? scale.Value
                    : (recipe.UserRecipe != null && recipe.Recipe.AdjustableServings) ? recipe.UserRecipe.Servings / (double)recipe.Recipe.Servings : 1,
            });
        }

        return recipeResults.OrderBy(vm => vm.Recipe.Name).ToList();
    }

    /// <summary>
    /// Returns the recipes that are using in this recipe.
    /// </summary>
    private async Task<IList<QueryResults>> GetPrepRecipes(IServiceScopeFactory factory, IList<InProgressQueryResults> filteredResults)
    {
        // Don't check RecipeOptions.IgnorePrepRecipes yet so other things work.
        var prepRecipeIds = filteredResults.SelectMany(ar => ar.RecipeIngredients
            // Query for prerequisites ingredient recipes here so we can check their ignored status before finalizing recipes.
            .Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe)).Where(ri => ri.UserRecipeIngredient?.Ignore != true)
            // Search for both the substituted recipe ingredient and the raw recipe ingredient, so we can fallback if one conflicts with allergens.
            .SelectMany(ri => new List<int?>(2) { ri.IngredientRecipeId, ri.RawIngredientRecipeId }).Where(rid => rid.HasValue).Distinct()
            // Don't scale prerequisite recipes yet since the prerequisite recipe scale is based on the quantity of the ingredient recipe.    
            .GroupBy(ri => ri!.Value).ToDictionary(g => g.Key, ri => (int?)1/*(int)Math.Ceiling(ri.Quantity.ToDouble())*/);

        // This will filter out prep recipes missing equipemnt. No infinite recursion please. 
        return prepRecipeIds.Any() ? await new QueryBuilder(Core.Models.Newsletter.Section.Prep)
            .WithRecipes(options => options.AddRecipes(prepRecipeIds))
            .WithEquipment(EquipmentOptions.Equipment)
            .Build().Query(factory) : [];
    }
}
