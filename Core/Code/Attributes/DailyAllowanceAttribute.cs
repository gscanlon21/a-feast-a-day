
using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Recommended Daily Allowance.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DailyAllowanceAttribute(double rda, double tul, Measure measure, Multiplier multiplier)
    : Attribute
{
    public Person For { get; set; } = Person.All;
    public Multiplier Multiplier { get; set; } = multiplier;
    public Measure Measure { get; set; } = measure;
    public double InternalRDA { private get; set; } = rda;
    public double InternalTUL { private get; set; } = tul;
    public double? RDA => InternalRDA >= 0 ? InternalRDA : null;
    public double? TUL => InternalTUL >= 0 ? InternalTUL : null;
}
