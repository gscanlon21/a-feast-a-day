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
}
