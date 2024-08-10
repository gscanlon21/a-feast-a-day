using Data.Code.Extensions;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;

namespace Core.Code.Extensions;

public static class RecipeIngredientExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    internal static double NumberOfServings(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(ingredient);
        return recipeIngredient.ToGrams(ingredient, scale) / ingredient.GramsPerServing;
    }

    internal static double ToGrams(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(ingredient);
        return scale * recipeIngredient.Quantity.ToDouble() * recipeIngredient.Measure.ToGramsWithContext(ingredient);
    }
}
