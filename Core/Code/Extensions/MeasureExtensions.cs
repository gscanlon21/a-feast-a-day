using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    public static double ToMeasure(this Measure recipeIngredientMeasure, Measure defaultMeasure)
    {
        return (recipeIngredientMeasure, defaultMeasure) switch
        {
            (Measure.Pounds, Measure.Ounces) => 16,
            (Measure.Ounces, Measure.Cups) => 0.125,
            (Measure.Ounces, Measure.Grams) => 28.35,
            (Measure.Grams, Measure.Ounces) => 0.0353,
            (Measure.Cups, Measure.Teaspoons) => 48,
            (Measure.Cups, Measure.Tablespoons) => 16,
            (Measure.Tablespoons, Measure.Cups) => 0.0625,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Teaspoons, Measure.Cups) => 0.0208333,
            (Measure.Tablespoons, Measure.Sticks) => 0.125,
            (Measure.Teaspoons, Measure.Tablespoons) => 0.333,
            (Measure.Cans, Measure.Jars) => 1, // ~
            (Measure.Cans, Measure.Cups) => 1, // ~
            (Measure.Jars, Measure.Cups) => 1, // ~
            (Measure.Jars, Measure.Cans) => 1, // ~
            (Measure.Cups, Measure.Jars) => 1, // ~
            (Measure.Cups, Measure.Cans) => 1, // ~
            (Measure.Packages, Measure.Cups) => 2, // ~
            (Measure.Pounds, Measure.Cups) => 1.92, // ~
            (Measure.Pinch, Measure.Cups) => 0.01, // ~
            (Measure.Handful, Measure.Cups) => 0.5, // ~
            (Measure.Packages, Measure.Slices) => 6, // ~
            (Measure.Pinch, Measure.Teaspoons) => 0.5, // ~
            (Measure.Pinch, Measure.Tablespoons) => 0.25, // ~
            (Measure.Cups, Measure.None) => 1, // ~ // TODO use ingredient's grams per measure.
            (Measure.None, Measure.Cups) => 1, // ~ // TODO use ingredient's grams per measure.
            _ when recipeIngredientMeasure == defaultMeasure => 1,
            _ => throw new NotImplementedException($"Missing measure: {recipeIngredientMeasure}, {defaultMeasure}")
        };
    }

    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity)
    {
        return measure switch
        {
            Measure.Micrograms => quantity / 1000000,
            Measure.Milligrams => quantity / 1000,
            Measure.Grams or Measure.None => quantity,
            Measure.Ounces => quantity * 28.3495231,
            Measure.Pounds => quantity * 453.59237,
            _ => throw new NotImplementedException("Use RecipeIngredientExtensions.ToGrams()")
        };
    }
}
