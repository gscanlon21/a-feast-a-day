
using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Validation attribute for boolean == true
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DailyAllowanceAttribute : Attribute
{
    public DailyAllowanceAttribute(int rda, int tul, Measure measure = Measure.Grams)
    {
        RDA = rda;
        TUL = tul;
        Measure = measure;
    }

    public Measure Measure { get; set; }
    public int RDA { get; set; }
    public int TUL { get; set; }
}
