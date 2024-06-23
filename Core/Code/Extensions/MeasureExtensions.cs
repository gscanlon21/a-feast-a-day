using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity, double? gramsPerServing = null, double? gramsPerCup = null)
    {
        double getGramsPerCup() => gramsPerCup ?? throw new ArgumentNullException(nameof(gramsPerCup));
        double getGramsPerServing() => gramsPerServing ?? throw new ArgumentNullException(nameof(gramsPerServing));

        return measure switch
        {
            Measure.None => quantity,
            Measure.Micrograms => quantity / 1000000,
            Measure.Milligrams => quantity / 1000,
            Measure.Grams => quantity,
            Measure.Ounces => quantity * 28.3495231,
            Measure.Pound => quantity * 453.59237,
            Measure.Teaspoons => quantity * getGramsPerCup() * 0.02083333,
            Measure.Tablespoons => quantity * getGramsPerCup() * 0.0625,
            Measure.Handful => quantity * getGramsPerCup() * 0.5,
            Measure.Jar => quantity * getGramsPerCup(),
            Measure.Can => quantity * getGramsPerCup(),
            Measure.Cup => quantity * getGramsPerCup(),
            _ => throw new NotImplementedException($"Missing measure: {measure}"),
        };
    }
}
