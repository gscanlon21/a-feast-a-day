using Microsoft.Extensions.DependencyInjection;

namespace Data.Query.Filters;

public class SystemQueryFilter : BaseQueryFilter
{
    public override async Task<List<QueryResults>> Filter(List<QueryResults> queryResults, IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
    {
        return queryResults;
    }
}
