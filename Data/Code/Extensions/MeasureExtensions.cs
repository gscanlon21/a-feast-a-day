using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.Ingredient;

namespace Data.Code.Extensions;

public static class MeasureExtensions
{
    public static double ToDefaultMeasure(this Measure fromMeasure, Ingredient ingredient)
    {
        return (fromMeasure, ingredient.DefaultMeasure) switch
        {
            // Dry conversions.
            (Measure.Pounds, Measure.Ounces) => 16,
            (Measure.Ounces, Measure.Grams) => 28.35,
            (Measure.Ounces, Measure.Pounds) => 0.0625,
            (Measure.Grams, Measure.Ounces) => 0.0353,

            // Fluid conversions.
            (Measure.FluidOunces, Measure.Cups) => 0.125,
            (Measure.Cups, Measure.Teaspoons) => 48,
            (Measure.Cups, Measure.Tablespoons) => 16,
            (Measure.Tablespoons, Measure.Cups) => 0.0625,
            (Measure.Tablespoons, Measure.Teaspoons) => 3,
            (Measure.Teaspoons, Measure.Cups) => 0.0208333,
            (Measure.Teaspoons, Measure.Tablespoons) => 0.333,

            _ when fromMeasure == ingredient.DefaultMeasure => 1,

            _ when MeasureConsts.LiquidMeasures.Contains(fromMeasure)
                => Measure.Grams.ToMeasure(ingredient.DefaultMeasure) * ingredient.GramsPerCup * fromMeasure.ToMeasure(Measure.Cups),
            
            _ when MeasureConsts.LiquidMeasures.Contains(ingredient.DefaultMeasure)
                => fromMeasure.ToMeasure(Measure.Grams) * ingredient.GramsPerCup * Measure.Cups.ToMeasure(ingredient.DefaultMeasure),
            
            _ => throw new NotImplementedException($"Missing measure: {fromMeasure}, {ingredient.DefaultMeasure}")
        };
    }
}
