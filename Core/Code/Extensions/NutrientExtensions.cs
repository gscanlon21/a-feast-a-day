using Core.Code.Attributes;
using Core.Code.Exceptions;
using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Extensions;

public static class NutrientExtensions
{
    /// <summary>
    /// TODO/FIXME: Conversion ratios change with genetic variants?
    /// </summary>
    public static double GetEquivalentConversion(this Nutrients nutrients, Measure measure)
    {
        try
        {
            return measure switch
            {
                Measure.None or Measure.KCalorie => 1,
                // 60mg of Tryptophan converts to 1mg of Niacin.
                Measure.MG_NE => nutrients == Nutrients.Tryptophan ? 1 / 60d : 1,

                _ when MeasureConsts.DryMeasures.Contains(measure) => 1,
                _ when MeasureConsts.LiquidMeasures.Contains(measure) => 1,
                _ => throw new MissingMeasureException($"Missing measure {measure}!"),
            };
        }
        catch (MissingMeasureException ex)
        {
            ex.Data[nameof(nutrients)] += nutrients.GetSingleDisplayName();
            throw;
        }
    }

    /// <summary>
    /// Returns null for nutrient if there's no reference data.
    /// </summary>
    public static DailyAllowanceAttribute? DailyAllowance(this Nutrients nutrients, Person person)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes<DailyAllowanceAttribute>(true).ToArray();
            if (attributes != null && attributes.Length > 0)
            {
                // Don't restrict this nutrient if there's no reference data.
                return attributes.FirstOrDefault(a => a.For == person) ?? attributes.FirstOrDefault(a => a.For.HasFlag(person));
            }
        }

        // Don't restrict this nutrient if there's no reference data.
        return null;
    }
}
