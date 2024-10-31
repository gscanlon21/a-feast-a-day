using Data.Code.Extensions;
using Data.Entities.Recipe;

namespace Core.Code.Extensions;

public static class RecipeIngredientExtensions
{
    internal static double NumberOfServings(this RecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.Ingredient);
        return recipeIngredient.ToGrams(scale) / recipeIngredient.Ingredient.GramsPerServing;
    }

    internal static double ToGrams(this RecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.Ingredient);
        return scale * recipeIngredient.Quantity.ToDouble() * recipeIngredient.Measure.ToGramsWithContext(recipeIngredient.Ingredient);
    }
}
