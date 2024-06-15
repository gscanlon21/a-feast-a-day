using Core.Models.User;
using Data.Entities.User;
using Fractions;

namespace Core.Code.Extensions;

public static class RecipeIngredientExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double NumberOfServings(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        var fraction = new Fraction(recipeIngredient.QuantityNumerator ?? 0, recipeIngredient.QuantityDenominator ?? 1, true);

        return recipeIngredient.Measure switch
        {
            Measure.Grams => fraction.ToDouble() / ingredient.GramsPerServing,
            Measure.Ounce => fraction.ToDouble() * 28.3495231 / ingredient.GramsPerServing,
            Measure.Pound => fraction.ToDouble() * 453.59237 / ingredient.GramsPerServing,
            Measure.Teaspoon => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.02083333 / ingredient.GramsPerServing,
            Measure.Tablespoon => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.0625 / ingredient.GramsPerServing,
            Measure.Handful => fraction.ToDouble() * ingredient.GramsPerMeasure * 0.5 / ingredient.GramsPerServing,
            Measure.Jar => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            Measure.Can => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            Measure.Cup => fraction.ToDouble() * ingredient.GramsPerMeasure / ingredient.GramsPerServing,
            _ => fraction.ToDouble(),
        } * scale;
    }

    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double NormalizedGrams(this RecipeIngredient recipeIngredient, Ingredient ingredient, int scale = 1)
    {
        var fraction = new Fraction(recipeIngredient.QuantityNumerator ?? 0, recipeIngredient.QuantityDenominator ?? 1, true);
        return scale * recipeIngredient.Measure.ToGrams(fraction.ToDouble(), gramsPerServing: ingredient.GramsPerServing, gramsPerCup: ingredient.GramsPerMeasure);
    }
}
