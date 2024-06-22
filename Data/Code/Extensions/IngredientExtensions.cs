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
        var alternativeIngredients = allIngredients.Where(i => ingredient.ParentId == i.ParentId || ingredient.Id == i.ParentId).ToList();
        if (allergens.HasAnyFlag32(ingredient.Allergens))
        {
            return alternativeIngredients.FirstOrDefault(i => !allergens.HasAnyFlag32(i.Allergens));
        }

        return ingredient;
    }
}
