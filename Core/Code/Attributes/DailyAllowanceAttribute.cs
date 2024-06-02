
using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Validation attribute for boolean == true
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DailyAllowanceAttribute : Attribute
{
    public DailyAllowanceAttribute(double rda, double tul, Measure measure = Measure.Grams)
    {
        RDA = rda;
        TUL = tul;
        Measure = measure;
    }

    public Measure Measure { get; set; }
    public double RDA { get; set; }
    public double TUL { get; set; }
}
