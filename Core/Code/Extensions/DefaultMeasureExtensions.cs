using Core.Code.Attributes;
using Core.Models.User;

namespace Core.Code.Extensions;

public static class DefaultMeasureExtensions
{
    public static Measure DefaultMeasure(this Nutrients nutrients)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DefaultMeasureAttribute), true).Cast<DefaultMeasureAttribute>().ToArray();
            if (attrs != null && attrs.Length > 0)
            {
                return attrs[0].Measure;
            }
        }

        return Measure.Milligrams;
    }
}
