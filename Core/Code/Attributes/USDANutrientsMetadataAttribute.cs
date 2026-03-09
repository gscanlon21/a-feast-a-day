using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class USDANutrientsMetadataAttribute : Attribute
{
    public const string Name = "USDANutrientsMetadata";

    public Measure Measure { get; }
    public double? NutrientNumber { get; }
    public double? Rank { get; }

    public USDANutrientsMetadataAttribute(Measure measure, double nutrientNumber, double rank)
    {
        Measure = measure;
        NutrientNumber = nutrientNumber >= 0 ? nutrientNumber : null;
        Rank = rank >= 0 ? rank : null;
    }
}


public static class USDANutrientsMetadataAttributeExtensions
{
    private static USDANutrientsMetadataAttribute? GetMetadata(this USDANutrients nutrient)
    {
        var memberInfo = nutrient.GetType().GetMember(nutrient.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute<USDANutrientsMetadataAttribute>(true);
        }

        return null;
    }

    public static Measure? GetMeasure(this USDANutrients nutrient)
    {
        return nutrient.GetMetadata()?.Measure;
    }

    public static double? GetNutrientNumber(this USDANutrients nutrient)
    {
        return nutrient.GetMetadata()?.NutrientNumber;
    }

    public static double? GetRank(this USDANutrients nutrient)
    {
        return nutrient.GetMetadata()?.Rank;
    }
}
