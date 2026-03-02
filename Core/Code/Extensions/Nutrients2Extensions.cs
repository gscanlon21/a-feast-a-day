using Core.Code.Attributes;
using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Extensions;

public static class NutrientsExtensions
{
    private static NutrientsMetadataAttribute? GetMetadata(this Nutrients nutrient)
    {
        var memberInfo = nutrient.GetType().GetMember(nutrient.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute<NutrientsMetadataAttribute>(true);
        }

        return null;
    }

    public static Measure? GetMeasure(this Nutrients nutrient)
    {
        return nutrient.GetMetadata()?.Measure;
    }

    public static double? GetNutrientNumber(this Nutrients nutrient)
    {
        return nutrient.GetMetadata()?.NutrientNumber;
    }

    public static double? GetRank(this Nutrients nutrient)
    {
        return nutrient.GetMetadata()?.Rank;
    }
}
