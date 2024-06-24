using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    public static double ToMeasure(this Measure recipeIngredientMeasure, Measure defaultMeasure)
    {
        return (recipeIngredientMeasure, defaultMeasure) switch
        {
            (Measure.Pound, Measure.Ounces) => 16,
            (Measure.Ounces, Measure.Cup) => 0.125,
            (Measure.Cup, Measure.Teaspoons) => 48,
            (Measure.Cup, Measure.Tablespoons) => 16,
            (Measure.Tablespoons, Measure.Cup) => 0.0625,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Teaspoons, Measure.Cup) => 0.0208333,
            (Measure.Tablespoons, Measure.Sticks) => 0.125,
            (Measure.Teaspoons, Measure.Tablespoons) => 0.333,
            (Measure.Can, Measure.Jar) => 1, // ~
            (Measure.Package, Measure.Cup) => 2, // ~
            (Measure.Pound, Measure.Cup) => 1.92, // ~
            (Measure.Pinch, Measure.Cup) => 0.01, // ~
            (Measure.Handful, Measure.Cup) => 0.5, // ~
            (Measure.Package, Measure.Slices) => 6, // ~
            (Measure.Pinch, Measure.Teaspoons) => 0.5, // ~
            (Measure.Pinch, Measure.Tablespoons) => 0.25, // ~
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
            Measure.Pound => quantity * 453.59237,
            _ => throw new NotImplementedException("Use RecipeIngredientExtensions.ToGrams()")
        };
    }
}
