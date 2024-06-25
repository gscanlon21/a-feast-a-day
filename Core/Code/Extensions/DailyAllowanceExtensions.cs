using Core.Code.Attributes;
using Core.Models.User;
using static Core.Code.Extensions.EnumExtensions;

namespace Core.Code.Extensions;

public static class DailyAllowanceExtensions
{
    public static DailyAllowanceAttribute DailyAllowance(this Nutrients nutrients, Person person)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DailyAllowanceAttribute), true).Cast<DailyAllowanceAttribute>().ToArray();
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
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DailyAllowanceAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                var attribute = (DailyAllowanceAttribute)attributes[0];
                return $@"({(attribute.RDA, attribute.TUL) switch
                {
                    (null, not null) => $"TUL = {attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    (not null, null) => $"RDA = {attribute.RDA}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    (not null, not null) => $"RDA = {attribute.RDA}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}, TUL = {attribute.TUL}{attribute.Measure.GetSingleDisplayName(DisplayNameType.ShortName)}",
                    _ => string.Empty
                }} / {attribute.Multiplier.GetSingleDisplayName()})";
            }
        }

        return string.Empty;
    }
}
