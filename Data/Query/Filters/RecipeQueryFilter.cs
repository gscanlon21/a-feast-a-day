using Data.Query.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Query.Filters;

public class RecipeQueryFilter : BaseQueryFilter
{
    protected readonly Core.Models.Newsletter.Section section;

    public RecipeQueryFilter(Core.Models.Newsletter.Section sec)
    {
        section = sec;
    }

    public required RecipeOptions RecipeOptions { protected get; init; }
    public required SelectionOptions SelectionOptions { protected get; init; }

    public override async Task<List<QueryResults>> Filter(List<QueryResults> queryResults, IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
    {
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var localResults = new HashSet<QueryResults>();
        foreach (var recipe in queryResults)
        {
            if (!SelectionOptions.IgnorePrepRecipes)
            {
                ScaleAndAddPrepRecipes(recipe, localResults, SelectionOptions.PrepRecipes);
            }

            localResults.Add(recipe);
        }

        return localResults.ToList();
    }
}
