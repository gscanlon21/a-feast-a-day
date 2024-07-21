using Core.Code.Exceptions;
using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.Ingredient;

namespace Data.Code.Extensions;

public static class MeasureExtensions
{
    public static double ToDefaultMeasure(this Measure fromMeasure, Ingredient ingredient)
    {
        // Dry to dry, liquid to liquid, or item to item measure conversions.
        var exactConversion = fromMeasure.ToMeasureOrNull(ingredient.DefaultMeasure);
        if (exactConversion.HasValue)
        {
            return exactConversion.Value;
        }

        try
        {
            return (fromMeasure, ingredient.DefaultMeasure) switch
            {
                // Liquid to item measure conversion.
                (not Measure.None, Measure.None) when MeasureConsts.LiquidMeasures.Contains(fromMeasure)
                    => fromMeasure.ToMeasure(Measure.Cups) * ingredient.GramsPerCup / ingredient.GramsPerMeasure,

                // Dry to item measure conversion.
                (not Measure.None, Measure.None)
                    => fromMeasure.ToMeasure(Measure.Grams) / ingredient.GramsPerMeasure,

                // Liquid to dry measure conversion.
                _ when MeasureConsts.LiquidMeasures.Contains(fromMeasure)
                    // Tablespoons to dry ounces: 0.0353oz/g * 0.0625c/tbsp * ~240g/c ~= 0.5295oz/tbsp. Approx 8oz/c and 16tbsp/c.
                    => Measure.Grams.ToMeasure(ingredient.DefaultMeasure) * fromMeasure.ToMeasure(Measure.Cups) * ingredient.GramsPerCup,

                // Dry to liquid measure conversion.
                _ when MeasureConsts.LiquidMeasures.Contains(ingredient.DefaultMeasure)
                    // Dry ounces to tablespoons: 28.35g/oz * 16tbsp/c / ~240g/c ~= 1.89tbsp/oz. Approx 8oz/c and 16tbsp/c.
                    => fromMeasure.ToMeasure(Measure.Grams) * Measure.Cups.ToMeasure(ingredient.DefaultMeasure) / ingredient.GramsPerCup,

                _ => throw new MissingMeasureException($"Missing measure: {fromMeasure}, {ingredient.DefaultMeasure}")
            };
        }
        catch (MissingMeasureException ex)
        {
            ex.Data[nameof(ingredient)] = ingredient.Name;
            throw;
        }
    }
}
