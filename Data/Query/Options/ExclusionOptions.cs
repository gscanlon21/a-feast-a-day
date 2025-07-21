namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any recipes that fall in this list.
    /// </summary>
    public List<int> RecipeIds = [];

    /// <summary>
    /// Exclude any of these recipes from being chosen.
    /// </summary>
    internal void AddExcludeRecipes(IEnumerable<QueryResults>? recipes)
    {
        if (recipes != null)
        {
            RecipeIds.AddRange(recipes.Select(e => e.Recipe.Id));
        }
    }
}
