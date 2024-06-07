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
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DailyAllowanceAttribute), true).Cast<DailyAllowanceAttribute>().ToArray();
            if (attrs != null && attrs.Length > 0)
            {
                return attrs.FirstOrDefault(a => a.For.HasFlag(person)) ?? attrs[0];
            }
        }

        throw new NotImplementedException();
    }

    public static string DailyAllowanceDisplayName(this Nutrients nutrients)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DailyAllowanceAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                var attribute = (DailyAllowanceAttribute)attrs[0];
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
