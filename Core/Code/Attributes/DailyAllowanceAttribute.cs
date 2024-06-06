
using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Recommended Daily Allowance.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DailyAllowanceAttribute : Attribute
{
    public DailyAllowanceAttribute(double rda, double tul, Measure measure, Multiplier multiplier)
    {
        InternalRDA = rda;
        InternalTUL = tul;
        Measure = measure;
        Multiplier = multiplier;
    }

    public Person For { get; set; } = Person.All;
    public Multiplier Multiplier { get; set; }
    public Measure Measure { get; set; }
    public double InternalRDA { private get; set; }
    public double InternalTUL { private get; set; }
    public double? RDA => InternalRDA >= 0 ? InternalRDA : null;
    public double? TUL => InternalTUL >= 0 ? InternalTUL : null;
}
