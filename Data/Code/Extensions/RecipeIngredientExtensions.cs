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
        var fraction = new Fraction(recipeIngredient.QuantityNumerator, recipeIngredient.QuantityDenominator, true);

        return recipeIngredient.Measure switch
        {
            Measure.Grams => fraction.ToDouble() / ingredient.GramsPerServing,
            Measure.Ounces => fraction.ToDouble() * 28.3495231 / ingredient.GramsPerServing,
            Measure.Pound => fraction.ToDouble() * 453.59237 / ingredient.GramsPerServing,
            Measure.Teaspoons => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.02083333 / ingredient.GramsPerServing,
            Measure.Tablespoons => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.0625 / ingredient.GramsPerServing,
            Measure.Handful => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.5 / ingredient.GramsPerServing,
            Measure.Jar => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            Measure.Can => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            Measure.Cup => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            _ => throw new NotImplementedException($"Missing measure: {recipeIngredient.Measure}"),
        } * scale;
    }

    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    internal static double NormalizedGrams(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        var fraction = new Fraction(recipeIngredient.QuantityNumerator, recipeIngredient.QuantityDenominator, true);
        return scale * recipeIngredient.Measure.ToGrams(fraction.ToDouble(), gramsPerServing: ingredient.GramsPerServing, gramsPerCup: ingredient.GramsPerMeasure);
    }
}
