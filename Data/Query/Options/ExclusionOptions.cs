using Core.Models.User;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Recipes that have already been choosen.
    /// </summary>
    public List<int> RecipeIds = [];

    /// <summary>
    /// Allergens that have already been choosen.
    /// </summary>
    public Allergens Allergens = Allergens.None;

    /// <summary>
    /// Exclude any of these recipes from being chosen.
    /// </summary>
    internal void AddExcludeRecipes(IEnumerable<QueryResults>? recipes)
    {
        if (recipes != null)
        {
            RecipeIds.AddRange(recipes.Select(e => e.Recipe.Id));
            Allergens |= GenericBitwise<Allergens>.Or(recipes.Select(e => e.Allergens));
        }
    }
}
