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
    internal void AddExcludeRecipes(IEnumerable<Recipe>? exercises)
    {
        if (exercises != null)
        {
            RecipeIds.AddRange(exercises.Select(e => e.Id));
        }
    }
}
