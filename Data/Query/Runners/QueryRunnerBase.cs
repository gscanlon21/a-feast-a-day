using Core.Models;
using Core.Models.Nutrients;
using Core.Models.Recipe;
using Data.Code.Extensions;
using Data.Entities.Ingredients;
using Data.Entities.Nutrients;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Models;
using Data.Models.Ingredients;
using Data.Query.Builders;
using Data.Query.Options;
using Data.Query.Options.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Data.Query.Runners;

/// <summary>
/// Builds and runs an EF Core query for selecting recipes.
/// </summary>
public abstract class QueryRunnerBase
{
    protected readonly Core.Models.Newsletter.Section section;

    public QueryRunnerBase(Core.Models.Newsletter.Section sec)
    {
        section = sec;
    }

    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    public class RecipesQueryResults : IRecipeCombo
    {
        /// <summary>EF Core can't optimize constructors.</summary>
        public RecipesQueryResults() { /* no-op */}

        public Recipe Recipe { get; init; } = null!;
        public UserRecipe UserRecipe { get; init; } = null!;
        public IList<QueryNutrient> Nutrients { get; init; } = null!;
        public List<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = null!;
    }

    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    protected class InProgressQueryResults(RecipesQueryResults queryResult) : IRecipeCombo
    {
        public Recipe Recipe { get; } = queryResult.Recipe;
        public UserRecipe? UserRecipe { get; set; } = queryResult.UserRecipe;
        public IList<QueryNutrient> Nutrients { get; set; } = queryResult.Nutrients;
        public List<RecipeIngredientQueryResults> RecipeIngredients { get; set; } = queryResult.RecipeIngredients;

        public override int GetHashCode() => HashCode.Combine(Recipe.Id);
        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Recipe.Id == Recipe.Id;
    }

    [DebuggerDisplay("{Ingredient}: {Scale}")]
    protected class IngredientUserIngredient
    {
        public double Scale { get; init; } = 1;
        public Measure? Measure { get; init; }
        public int? QuantityNumerator { get; init; }
        public int? QuantityDenominator { get; init; }
        public required Ingredient Ingredient { get; init; } = null!;
    }

    public required UserOptions UserOptions { get; init; }
    public required RecipeOptions RecipeOptions { get; init; }
    public required ServingOptions ServingOptions { get; init; }
    public required DurationOptions DurationOptions { get; init; }
    public required NutrientOptions NutrientOptions { get; init; }
    public required EquipmentOptions EquipmentOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required SelectionOptions SelectionOptions { get; init; }
    public required IngredientOptions IngredientOptions { get; init; }

    protected IQueryable<RecipesQueryResults> CreateFilteredRecipesQuery(CoreContext context)
    {
        var query = context.Recipes.TagWith(nameof(CreateFilteredRecipesQuery))
            .IgnoreQueryFilters().AsSplitQuery()
            .Include(r => r.Instructions)
            .Where(r => r.DisabledReason == null)
            // Don't grab recipes that we want to ignore.
            .Where(r => !ExclusionOptions.RecipeIds.Contains(r.Id))
            // Make sure the user owns or is able to see the recipes.
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            // Don't grab recipes that have too many non-optional ingredients.
            .Where(r => UserOptions.MaxIngredients == null || r.RecipeIngredients.Count(i => !i.Ingredient.SkipShoppingList) <= UserOptions.MaxIngredients)
            .Select(r => new RecipesQueryResults()
            {
                Recipe = r,
                UserRecipe = r.UserRecipes.First(ur => ur.UserId == UserOptions.Id),
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
                    CookedScale = ri.CookedScale,
                    QuantityNumerator = ri.QuantityNumerator,
                    QuantityDenominator = ri.QuantityDenominator,
                    RawIngredientRecipeId = ri.IngredientRecipeId,
                    UserRecipeIngredient = ri.UserRecipeIngredients.First(ui => ui.UserId == UserOptions.Id && ui.RecipeIngredientId == ri.Id),
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

        if (!UserOptions.IgnoreIgnored)
        {
            // Including skipped recipes for past feasts.
            if (!SelectionOptions.IncludeSkippedRecipes)
            {
                // Don't grab recipes that the user wants to ignore.
                query = query.Where(vm => vm.UserRecipe.IgnoreUntil.HasValue != true);
            }
            else
            {
                // Don't grab recipes that the user wants to ignore.
                query = query.Where(vm => vm.UserRecipe.IgnoreUntil != DateOnly.MaxValue);
            }

            // It's faster to check for ignored recipe ingredients where we check for allergens.
            //-Don't grab recipes that use ingredients that the user wants to ignore. 
            //.Where(vm => vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredient!.Ignore != true))
            //-Don't grab recipes that use ingredient recipes that the user wants to ignore.
            //.Where(vm => vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredientRecipe!.IgnoreUntil.HasValue != true));
        }

        return query;
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public abstract Task<List<QueryResults>> Query(IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue);

    /// <summary>
    /// Returns the recipes that are using in this recipe.
    /// </summary>
    protected async Task<IList<QueryResults>> GetPrepRecipes(IServiceScopeFactory factory, IList<InProgressQueryResults> filteredResults)
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
        return prepRecipeIds.Any() ? await new UserOptionsQueryBuilder(UserOptions, Core.Models.Newsletter.Section.Prep)
            .WithUser(options =>
            {
                // Keep ignored base recipes, user should ignore the recipe ingredient if they need to ignore this.
                // This allows the user to ignore "Sides" recipes that also function as base recipes.
                options.IgnoreIgnored = true;
            })
            .WithEquipment(EquipmentOptions.Equipment)
            .WithRecipes(options => options.AddRecipes(prepRecipeIds))
            .Build().Query(factory) : [];
    }
}
