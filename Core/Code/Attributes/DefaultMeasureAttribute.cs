using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Recommended Daily Allowance.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DefaultMeasureAttribute(Measure measure)
    : Attribute
{
    public Measure Measure { get; set; } = measure;
}
