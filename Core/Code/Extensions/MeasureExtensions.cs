using Core.Models.User;

namespace Core.Code.Extensions;

public static class MeasureExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double ToGrams(this Measure measure, double quantity, double? gramsPerServing = null, double? gramsPerCup = null)
    {
        var getGramsPerCup = () => gramsPerCup ?? throw new ArgumentNullException(nameof(gramsPerCup));
        var getGramsPerServing = () => gramsPerServing ?? throw new ArgumentNullException(nameof(gramsPerServing));
        
        return measure switch
        {
            Measure.None => quantity,
            Measure.Micrograms => quantity / 1000000,
            Measure.Milligrams => quantity / 1000,
            Measure.Grams => quantity,
            Measure.Ounce => quantity * 28.3495231,
            Measure.Pound => quantity * 453.59237,
            Measure.Teaspoon => quantity * getGramsPerCup() * 0.02083333,
            Measure.Tablespoon => quantity * getGramsPerCup() * 0.0625,
            Measure.Handful => quantity * getGramsPerCup() * 0.5,
            Measure.Jar => quantity * getGramsPerCup(),
            Measure.Can => quantity * getGramsPerCup(),
            Measure.Cup => quantity * getGramsPerCup(),
            _ => quantity * getGramsPerServing(),
        };
    }
}
