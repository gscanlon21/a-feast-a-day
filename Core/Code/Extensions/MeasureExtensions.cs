using Core.Code.Exceptions;
using Core.Models.User;

namespace Core.Code.Extensions;

/// <summary>
/// Exact measure conversions.
/// </summary>
public static class MeasureExtensions
{
    /// <summary>
    /// Returns the exact conversion factor from one measure to grams.
    /// Throws an exception when there is no exact conversion.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity = 1)
    {
        if (measure == Measure.None)
        {
            return quantity;
        }

        return quantity * measure.ToMeasure(Measure.Grams);
    }

    /// <summary>
    /// Returns the exact conversion factor from one measure to grams,
    /// ... or the exact milliliter conversion if there is no conversion to grams.
    /// Throws an exception when there is no exact conversion.
    /// </summary>
    public static double ToGramsOrMilliliters(this Measure measure, double quantity = 1)
    {
        if (measure == Measure.None)
        {
            return quantity;
        }

        return quantity * (measure.ToMeasureOrNull(Measure.Grams) ?? measure.ToMeasure(Measure.Milliliters));
    }

    /// <summary>
    /// Finds the exact conversion factor from one measure to another.
    /// Throws an exception when there is no exact conversion.
    /// </summary>
    public static double ToMeasure(this Measure fromMeasure, Measure toMeasure)
    {
        if (fromMeasure.ToMeasureOrNull(toMeasure) is double conversion)
        {
            return conversion;
        }

        throw new MissingMeasureException($"Missing measure: {fromMeasure}, {toMeasure}");
    }

    /// <summary>
    /// Finds the exact conversion factor from one measure to another.
    /// Returns null when there is no exact conversion.
    /// </summary>
    private static double? ToMeasureOrNull(this Measure fromMeasure, Measure toMeasure)
    {
        return (fromMeasure, toMeasure) switch
        {
            _ when fromMeasure == toMeasure => 1,

            // Dry conversions.
            (Measure.Pounds, Measure.Ounces) => 16,
            (Measure.Ounces, Measure.Pounds) => 1d / 16,
            (Measure.Pounds, Measure.Grams) => 453.59237,
            (Measure.Grams, Measure.Pounds) => 1d / 453.59237,
            (Measure.Ounces, Measure.Grams) => 28.3495231,
            (Measure.Grams, Measure.Ounces) => 1d / 28.3495231,
            (Measure.Micrograms, Measure.Grams) => 1d / 1000000,
            (Measure.Milligrams, Measure.Grams) => 1d / 1000,

            // Fluid conversions.
            (Measure.Gallons, Measure.Cups) => 16,
            (Measure.Cups, Measure.Gallons) => 1d / 16,
            (Measure.Cups, Measure.FluidOunces) => 8,
            (Measure.FluidOunces, Measure.Cups) => 1d / 8,
            (Measure.Cups, Measure.Tablespoons) => 16,
            (Measure.Tablespoons, Measure.Cups) => 1d / 16,
            (Measure.Cups, Measure.Teaspoons) => 48,
            (Measure.Teaspoons, Measure.Cups) => 1d / 48,
            (Measure.Cups, Measure.Milliliters) => 240,
            (Measure.Milliliters, Measure.Cups) => 1d / 240,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Teaspoons, Measure.Tablespoons) => 1d / 3,
            (Measure.Tablespoons, Measure.Milliliters) => 15,
            (Measure.FluidOunces, Measure.Milliliters) => 30,

            _ => null
        };
    }
}
