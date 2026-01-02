using Core.Code.Exceptions;
using Core.Models.User;
using Data.Entities.Ingredients;

namespace Data.Code.Extensions;

public static class MeasureExtensions
{
    /// <summary>
    /// Finds the approximate conversion factor from a measure to the ingredient's default measure.
    /// </summary>
    public static double ToDefaultMeasure(this Measure fromMeasure, Ingredient ingredient, bool coarseCut = false)
    {
        return fromMeasure.ToGramsWithContext(ingredient, coarseCut) / ingredient.DefaultMeasure.ToGramsWithContext(ingredient, coarseCut);
    }

    /// <summary>
    /// Finds the approximate conversion factor of a measure to grams using the ingredient's weight and volume as context.
    /// </summary>
    public static double ToGramsWithContext(this Measure measure, Ingredient ingredient, bool coarseCut = false)
    {
        try
        {
            return measure switch
            {
                Measure.None => ingredient.GramsPerMeasure,
                _ when MeasureConsts.DryMeasures.Contains(measure) => measure.ToMeasure(Measure.Grams),
                _ when MeasureConsts.LiquidMeasures.Contains(measure) => measure.ToMeasure(Measure.Cups) * (coarseCut ? ingredient.GramsPerCoarseCup : ingredient.GramsPerFineCup),
                _ => throw new MissingMeasureException($"Missing measure: {measure}")
            };
        }
        catch (MissingMeasureException ex)
        {
            ex.Data[nameof(ingredient)] += ingredient.Name;
            throw;
        }
    }
}
