using Core.Code.Attributes;
using Core.Models.User;
using System.Reflection;

namespace Core.Code.Extensions;

public static class NutrientExtensions
{
    public static SubNutrientsAttributeInternal? GetSkillType(this Nutrients nutrients)
    {
        var memberInfo = nutrients.GetType().GetMember(nutrients.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute(typeof(SubNutrientsAttribute<>), true) as SubNutrientsAttributeInternal;
        }

        return null;
    }
}
