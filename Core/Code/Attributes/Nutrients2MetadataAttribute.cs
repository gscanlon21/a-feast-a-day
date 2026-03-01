using Core.Models.User;

namespace Core.Code.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class Nutrients2MetadataAttribute : Attribute
{
    public Measure Measure { get; }
    public double? NutrientNumber { get; }
    public double? Rank { get; }

    public Nutrients2MetadataAttribute(Measure measure, double nutrientNumber, double rank)
    {
        Measure = measure;
        NutrientNumber = nutrientNumber >= 0 ? nutrientNumber : null;
        Rank = rank >= 0 ? rank : null;
    }
}
