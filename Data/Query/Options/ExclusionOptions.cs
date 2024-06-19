using Core.Models.User;
using Data.Entities.User;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any exercises that fall in this list.
    /// </summary>
    public List<int> RecipeIds = [];

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public Allergy Allergens = Allergy.None;

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public IList<int> Ingredients = [];

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    public void AddExcludeRecipes(IEnumerable<Recipe>? exercises)
    {
        if (exercises != null)
        {
            RecipeIds.AddRange(exercises.Select(e => e.Id));
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeAllergens(IEnumerable<Recipe>? exercises)
    {
        if (exercises != null)
        {
            Allergens = exercises.Aggregate(Allergens, (c, n) => c | n.Allergens);
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeIngredients(IEnumerable<Ingredient>? ingredients)
    {
        if (ingredients != null)
        {
            Ingredients = Ingredients.Union(ingredients.Select(i => i.Id)).ToList();
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeAllergens(Allergy allergens)
    {
        Allergens |= allergens;
    }
}
