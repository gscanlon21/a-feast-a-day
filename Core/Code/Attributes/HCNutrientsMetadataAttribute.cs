using Core.Models.Nutrients;
using System.Reflection;

namespace Core.Code.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class HCNutrientsMetadataAttribute : Attribute
{
    public const string Name = "HCNutrientsMetadata";

    public Measure Measure { get; }
    public int NutrientCode { get; }
    public string? NutrientSymbol { get; }

    public HCNutrientsMetadataAttribute(Measure measure, int nutrientCode, string nutrientSymbol)
    {
        Measure = measure;
        NutrientCode = nutrientCode;
        NutrientSymbol = nutrientSymbol;
    }
}

public static class HCNutrientsMetadataAttributeExtensions
{
    private static HCNutrientsMetadataAttribute? GetMetadata(this CanadaNutrients nutrient)
    {
        var memberInfo = nutrient.GetType().GetMember(nutrient.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute<HCNutrientsMetadataAttribute>(true);
        }

        return null;
    }

    public static Measure? GetMeasure(this CanadaNutrients nutrient)
    {
        return nutrient.GetMetadata()?.Measure;
    }
}
