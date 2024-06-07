using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity, int? gramsPerCup = null)
    {
        var gramMultiplier = gramsPerCup ?? 1;
        return measure switch
        {
            Measure.Micrograms => quantity / 1000000,
            Measure.Milligrams => quantity / 1000,
            Measure.Grams => quantity,
            Measure.Ounce => quantity * 28.3495231,
            Measure.Pound => quantity * 453.59237,
            Measure.Teaspoon => quantity * gramMultiplier * 0.02083333,
            Measure.Tablespoon => quantity * gramMultiplier * 0.0625,
            Measure.Handful => quantity * gramMultiplier * 0.5,
            Measure.Jar => quantity * gramMultiplier,
            Measure.Can => quantity * gramMultiplier,
            Measure.Cup => quantity * gramMultiplier,
            _ => quantity,
        };
    }
}
