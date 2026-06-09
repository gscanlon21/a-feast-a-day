using Core.Models;
using Core.Models.Ingredients;
using Core.Models.Recipe;
using Data.Query.Options;
using Data.Query.Options.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query.Runners;

/// <summary>
/// Builds and runs an EF Core query for selecting recipes.
/// </summary>
public class QueryRunner : QueryRunnerBase
{
    public QueryRunner(Core.Models.Newsletter.Section section) : base(section) { }

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

        var filteredQuery = CreateFilteredRecipesQuery(context);

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterEquipment(filteredQuery, EquipmentOptions.Equipment);
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds?.Keys);
        filteredQuery = Filters.FilterServings(filteredQuery, ServingOptions.MinimumServings);
        filteredQuery = Filters.FilterIngredient(filteredQuery, IngredientOptions.IngredientName);
        filteredQuery = Filters.FilterPrepTime(filteredQuery, DurationOptions.MaxPrepTimeMinutes);
        filteredQuery = Filters.FilterCookTime(filteredQuery, DurationOptions.MaxCookTimeMinutes);
        filteredQuery = Filters.FilterTotalTime(filteredQuery, DurationOptions.MaxTotalTimeMinutes);
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients, include: true, dataSource: NutrientOptions.DataSource);

        // When you perform comparisons with nullable types, if the value of one of the nullable types
        // ... is null and the other is not, all comparisons evaluate to false except for != (not equal).
        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

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
            recipe.RecipeIngredients = ((recipe.Recipe.KeepIngredientOrder, UserOptions.IngredientOrder) switch
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
}
