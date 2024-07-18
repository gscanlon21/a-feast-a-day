using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    public static double ToMeasure(this Measure fromMeasure, Measure toMeasure)
    {
        return (fromMeasure, toMeasure) switch
        {
            _ when fromMeasure == toMeasure => 1,

            // Dry conversions.
            (Measure.Pounds, Measure.Ounces) => 16,
            (Measure.Pounds, Measure.Grams) => 453.592,
            (Measure.Ounces, Measure.Grams) => 28.35,
            (Measure.Ounces, Measure.Pounds) => 0.0625,
            (Measure.Grams, Measure.Ounces) => 0.0353,
            (Measure.Grams, Measure.Pounds) => 0.00220462442,

            // Fluid conversions.
            (Measure.Cups, Measure.Gallons) => 0.0625,
            (Measure.Cups, Measure.Tablespoons) => 16,
            (Measure.Cups, Measure.Teaspoons) => 48,
            (Measure.Gallons, Measure.Cups) => 16,
            (Measure.FluidOunces, Measure.Cups) => 0.125,
            (Measure.Tablespoons, Measure.Cups) => 0.0625,
            (Measure.Teaspoons, Measure.Cups) => 0.0208333,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Teaspoons, Measure.Tablespoons) => 0.333,

            _ => throw new NotImplementedException($"Missing measure: {fromMeasure}, {toMeasure}")
        };
    }

    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity)
    {
        return measure switch
        {
            Measure.Micrograms => quantity / 1000000d,
            Measure.Milligrams => quantity / 1000d,
            Measure.Grams or Measure.None => quantity,
            Measure.Ounces => quantity * 28.3495231,
            Measure.Pounds => quantity * 453.59237,
            _ => throw new NotImplementedException("Use RecipeIngredientExtensions.ToGrams()")
        };
    }
}
