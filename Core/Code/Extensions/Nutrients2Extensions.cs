using Core.Code.Attributes;
using Core.Models.User;
using System.Reflection;

namespace Core.Code.Extensions;

public static class Nutrients2Extensions
{
    private static Nutrients2MetadataAttribute? GetMetadata(this Nutrients2 nutrient)
    {
        var memberInfo = nutrient.GetType().GetMember(nutrient.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute<Nutrients2MetadataAttribute>(true);
        }

        return null;
    }

    public static Measure? GetMeasure(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.Measure;
    }

    public static double? GetNutrientNumber(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.NutrientNumber;
    }

    public static double? GetRank(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.Rank;
    }
}
