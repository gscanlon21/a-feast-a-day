using Core.Models.User;
using Data.Entities.User;
using Fractions;

namespace Core.Code.Extensions;

public static class RecipeIngredientExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    internal static double NumberOfServings(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        return recipeIngredient.ToGrams(ingredient, scale) / ingredient.GramsPerServing;
    }

    internal static double ToGrams(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        var fraction = new Fraction(recipeIngredient.QuantityNumerator, recipeIngredient.QuantityDenominator, true);

        return recipeIngredient.Measure switch
        {
            Measure.Micrograms => fraction.ToDouble() / 1000000,
            Measure.Milligrams => fraction.ToDouble() / 1000,
            Measure.Grams => fraction.ToDouble(),
            Measure.Ounces => fraction.ToDouble() * 28.3495231,
            Measure.Pound => fraction.ToDouble() * 453.59237,
            _ => fraction.ToDouble() * recipeIngredient.Measure.ToMeasure(ingredient.DefaultMeasure) * ingredient.GramsPerMeasure,
        } * scale;
    }
}
