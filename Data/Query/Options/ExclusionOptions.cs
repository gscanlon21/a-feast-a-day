using Data.Entities.Recipe;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any recipes that fall in this list.
    /// </summary>
    public List<int> RecipeIds = [];

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    internal void AddExcludeRecipes(IEnumerable<Recipe>? recipes)
    {
        if (recipes != null)
        {
            RecipeIds.AddRange(recipes.Select(e => e.Id));
        }
    }
}
