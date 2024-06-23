using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class IngredientExtensions
{
    internal static Ingredient SubstitutedIngredient(this Ingredient ingredient, UserIngredient? substitute)
    {
        return substitute?.SubstituteIngredient ?? ingredient;
    }

    internal static Ingredient? SubstitutedIngredientForAllergens(this Ingredient ingredient, IList<Ingredient> allIngredients, Allergy allergens)
    {
        // Find alt ingredients where the alt's parent is this ingredient.
        var alternativeIngredients = allIngredients.Where(i => ingredient.Id == i.ParentId
            // Or the alt's parent and this ingredient's parent are the same.
            || (ingredient.ParentId.HasValue && ingredient.ParentId == i.ParentId)).ToList();

        if (allergens.HasAnyFlag32(ingredient.Allergens))
        {
            return alternativeIngredients.FirstOrDefault(i => !allergens.HasAnyFlag32(i.Allergens));
        }

        return ingredient;
    }
}
