using Core.Code.Attributes;
using Core.Models.User;
using System.Reflection;

namespace Core.Code.Extensions;

public static class DefaultMeasureExtensions
{
    public static Measure DefaultMeasure(this Nutrients nutrients)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attribute = memberInfo[0].GetCustomAttribute<DefaultMeasureAttribute>(true);
            if (attribute != null)
            {
                return attribute.Measure;
            }
        }

        return Measure.Milligrams;
    }
}
