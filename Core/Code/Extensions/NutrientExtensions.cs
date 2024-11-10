using Core.Code.Attributes;
using Core.Consts;
using Core.Models.User;
using System.Reflection;

namespace Core.Code.Extensions;

public static class NutrientExtensions
{
    public static Range DefaultRange(this Nutrients nutrient, Person person = Person.Adult)
    {
        var dailyAllowance = nutrient.DailyAllowance(person);
        return dailyAllowance.Measure switch
        {
            Measure.Percent => new Range(UserConsts.NutrientTargetDefaultPercent, dailyAllowance.TULPercent),
            _ => new Range(UserConsts.NutrientTargetDefaultPercent, Math.Min(UserConsts.NutrientTargetMaxPercent, dailyAllowance.TULPercent))
        };
    }

    public static SubNutrientsAttributeInternal? GetSkillType(this Nutrients nutrients)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute(typeof(SubNutrientsAttribute<>), true) as SubNutrientsAttributeInternal;
        }

        return null;
    }

    public static DailyAllowanceAttribute DailyAllowance(this Nutrients nutrients, Person person)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes<DailyAllowanceAttribute>(true).ToArray();
            if (attributes != null && attributes.Length > 0)
            {
                return attributes.FirstOrDefault(a => a.For == person)
                    ?? attributes.FirstOrDefault(a => a.For.HasFlag(person))
                    ?? attributes[0];
            }
        }

        throw new NotImplementedException();
    }

    public static string DailyAllowanceDisplayName(this Nutrients nutrients)
    {
        var attribute = nutrients.DailyAllowance(Person.Adult);
        if (attribute != null)
        {
            return $@"({(attribute.RDA, attribute.TUL) switch
            {
                (null, not null) => $"TUL={attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayType.ShortName)}",
                (not null, null) => $"RDA={attribute.RDA}{attribute.Measure.GetSingleDisplayName(DisplayType.ShortName)}",
                (not null, not null) => $"{attribute.RDA}-{attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayType.ShortName)}",
                _ => string.Empty
            }} / {attribute.Multiplier.GetSingleDisplayName(DisplayType.ShortName)})";
        }

        return string.Empty;
    }
}
