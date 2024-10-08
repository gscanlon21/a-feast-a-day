﻿using Core.Code.Exceptions;
using Core.Models.User;

namespace Core.Code.Extensions;

/// <summary>
/// Exact measure conversions.
/// </summary>
public static class MeasureExtensions
{
    /// <summary>
    /// Finds the exact conversion factor from one measure to grams.
    /// Throws an exception when there is no exact conversion.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity = 1)
    {
        return quantity * measure.ToMeasure(Measure.Grams);
    }

    /// <summary>
    /// Finds the exact conversion factor from one measure to grams.
    /// Returns the input quantity when there is no exact conversion.
    /// </summary>
    public static double ToGramsOrDefault(this Measure measure, double quantity)
    {
        return (quantity * measure.ToMeasureOrNull(Measure.Grams)) ?? quantity;
    }

    /// <summary>
    /// Finds the exact conversion factor from one measure to grams.
    /// Returns null when there is no exact conversion.
    /// </summary>
    public static double? ToGramsOrNull(this Measure measure, double quantity = 1)
    {
        return quantity * measure.ToMeasureOrNull(Measure.Grams);
    }

    /// <summary>
    /// Finds the exact conversion factor from one measure to grams.
    /// Returns the exact milliliter conversion if there is no conversion to grams.
    /// Returns the input quantity when there is no exact conversion.
    /// </summary>
    public static double ToGramsOrMillilitersOrDefault(this Measure measure, double quantity)
    {
        return (quantity * (measure.ToMeasureOrNull(Measure.Grams) ?? measure.ToMeasureOrNull(Measure.Milliliters))) ?? quantity;
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
    public static double? ToMeasureOrNull(this Measure fromMeasure, Measure toMeasure)
    {
        return (fromMeasure, toMeasure) switch
        {
            _ when fromMeasure == toMeasure => 1,

            // Dry conversions.
            (Measure.Pounds, Measure.Ounces) => 16,
            (Measure.Pounds, Measure.Grams) => 453.59237,
            (Measure.Ounces, Measure.Grams) => 28.3495231,
            (Measure.Ounces, Measure.Pounds) => 0.0625,
            (Measure.Grams, Measure.Ounces) => 0.0353,
            (Measure.Grams, Measure.Pounds) => 0.00220462442,
            (Measure.Micrograms, Measure.Grams) => 0.000001,
            (Measure.Milligrams, Measure.Grams) => 0.001,

            // Fluid conversions.
            (Measure.Gallons, Measure.Cups) => 16,
            (Measure.Cups, Measure.Gallons) => 0.0625,
            (Measure.Cups, Measure.Tablespoons) => 16,
            (Measure.Cups, Measure.Teaspoons) => 48,
            (Measure.Cups, Measure.Milliliters) => 240,
            (Measure.FluidOunces, Measure.Cups) => 0.125,
            (Measure.Tablespoons, Measure.Cups) => 0.0625,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Tablespoons, Measure.Milliliters) => 15,
            (Measure.Teaspoons, Measure.Cups) => 0.0208333,
            (Measure.Teaspoons, Measure.Tablespoons) => 0.333,
            (Measure.Milliliters, Measure.Cups) => 0.00416666667,

            _ => null
        };
    }
}
