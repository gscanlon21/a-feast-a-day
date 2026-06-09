using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Models;
using Data.Query.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    
    public required ServingOptions ServingOptions { private get; init; }
    public required DurationOptions DurationOptions { private get; init; }
    public required IngredientOptions IngredientOptions { private get; init; }

    public required RecipeOptions RecipeOptions { protected get; init; }
    public required NutrientOptions NutrientOptions { protected get; init; }
    public required EquipmentOptions EquipmentOptions { protected get; init; }
    public required ExclusionOptions ExclusionOptions { protected get; init; }
    public required SelectionOptions SelectionOptions { protected get; init; }

    protected virtual IQueryable<Recipe> CreateRecipesQuery(CoreContext context)
    {
        return context.Recipes.TagWith(nameof(CreateRecipesQuery))
            .IgnoreQueryFilters().AsSplitQuery()
            .Include(r => r.Instructions)
            .Where(r => r.DisabledReason == null)
            // Don't grab recipes that we want to ignore.
            .Where(r => !ExclusionOptions.RecipeIds.Contains(r.Id));
    }

    protected abstract IQueryable<RecipesQueryResults> Map(IQueryable<Recipe> recipes);

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    protected async Task<List<InProgressQueryResults>> QueryPartial(CoreContext context)
    {
        var filteredQuery = Map(CreateRecipesQuery(context));

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterEquipment(filteredQuery, EquipmentOptions.Equipment);
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds?.Keys);
        filteredQuery = Filters.FilterServings(filteredQuery, ServingOptions.MinimumServings);
        filteredQuery = Filters.FilterIngredient(filteredQuery, IngredientOptions.IngredientName);
        filteredQuery = Filters.FilterPrepTime(filteredQuery, DurationOptions.MaxPrepTimeMinutes);
        filteredQuery = Filters.FilterCookTime(filteredQuery, DurationOptions.MaxCookTimeMinutes);
        filteredQuery = Filters.FilterTotalTime(filteredQuery, DurationOptions.MaxTotalTimeMinutes);
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients, include: true, dataSource: NutrientOptions.DataSource);

        return await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync();
    }

    public abstract Task<List<QueryResults>> Query(IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue);
}
