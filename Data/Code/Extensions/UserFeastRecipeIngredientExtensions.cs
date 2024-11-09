using Data.Code.Extensions;
using Data.Entities.Newsletter;

namespace Core.Code.Extensions;

public static class UserFeastRecipeIngredientExtensions
{
    internal static double NumberOfServings(this UserFeastRecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.Ingredient);
        return recipeIngredient.ToGrams(scale) / recipeIngredient.Ingredient.GramsPerServing;
    }

    internal static double ToGrams(this UserFeastRecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.Ingredient);
        return scale * recipeIngredient.Quantity * recipeIngredient.Measure.ToGramsWithContext(recipeIngredient.Ingredient);
    }
}
