using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class NutrientsMetadataAttribute : Attribute
{
    public const string Name = "NutrientsMetadata";

    public Measure Measure { get; }
    public double? NutrientNumber { get; }
    public double? Rank { get; }

    public NutrientsMetadataAttribute(Measure measure, double nutrientNumber, double rank)
    {
        Measure = measure;
        NutrientNumber = nutrientNumber >= 0 ? nutrientNumber : null;
        Rank = rank >= 0 ? rank : null;
    }
}


public static class NutrientsMetadataAttributeExtensions
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
