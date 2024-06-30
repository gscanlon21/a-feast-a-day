using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.Ingredient;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class IngredientExtensions
{
    internal static Ingredient SubstitutedIngredient(this Ingredient ingredient, UserIngredient? substitute)
    {
        return (ingredient == substitute?.SubstituteIngredient) ? ingredient : substitute?.SubstituteIngredient ?? ingredient;
    }

    internal static Ingredient? SubstitutedIngredientForAllergens(this Ingredient ingredient, IList<Ingredient> allIngredients, Allergy allergens)
    {
        // Find alt ingredients that don't conflict with allergens.
        if (allergens.HasAnyFlag32(ingredient.Allergens))
        {
            return ingredient.Alternatives.Select(a => a.AlternativeIngredient).FirstOrDefault(ai => !allergens.HasAnyFlag32(ai.Allergens));
        }

        return ingredient;
    }
}
