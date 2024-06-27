using Core.Code.Attributes;
using Core.Models.User;
using System;
using System.Reflection;
using static Core.Code.Extensions.EnumExtensions;

namespace Core.Code.Extensions;

public static class DailyAllowanceExtensions
{
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
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attribute = memberInfo[0].GetCustomAttribute<DailyAllowanceAttribute>(true);
            if (attribute != null)
            {
                return $@"({(attribute.RDA, attribute.TUL) switch
                {
                    (null, not null) => $"TUL={attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    (not null, null) => $"RDA={attribute.RDA}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    (not null, not null) => $"{attribute.RDA}-{attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    _ => string.Empty
                }} / {attribute.Multiplier.GetSingleDisplayName(DisplayNameType.ShortName)})";
            }
        }

        return string.Empty;
    }
}
