using Core.Code.Attributes;
using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Extensions;

public static class NutrientExtensions
{
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

    /* BROKEN:
    /// <summary>
    /// TODO/FIXME: Conversion ratios change with genetic variants?
    /// FromMeasure is required because Tryptophan is measured in Grams,
    /// while ToMeasure is the base nutrient's Niacin value measured in MG_NE.
    /// MG_NE would be selected in the daily allowance attribute for a nutrient.
    /// </summary>
    public static double GetEquivalentConversion(this Nutrients nutrients, Measure fromMeasure, Measure toMeasure)
    {
        try
        {
            return toMeasure switch
            {
                Measure.None or Measure.KCalorie => 1,
                // 60mg of Tryptophan converts to 1mg of Niacin.
                Measure.MG_NE => nutrients == Nutrients.Tryptophan ? 1 / 60d : 1,

                _ when MeasureConsts.DryMeasures.Contains(toMeasure) => 1,
                _ when MeasureConsts.LiquidMeasures.Contains(toMeasure) => 1,
                _ => throw new MissingMeasureException($"Missing measure {toMeasure}!"),
            };
        }
        catch (MissingMeasureException ex)
        {
            ex.Data[nameof(nutrients)] += nutrients.GetSingleDisplayName();
            throw;
        }
    }*/
}
