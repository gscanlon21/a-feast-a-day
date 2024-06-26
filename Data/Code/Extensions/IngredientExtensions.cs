using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.Ingredient;
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
        if (allergens.HasAnyFlag32(ingredient.Allergens))
        {
            return ingredient.AlternativeIngredients.FirstOrDefault(i => !allergens.HasAnyFlag32(i.Ingredient.Allergens))?.Ingredient;
        }

        return ingredient;
    }
}
