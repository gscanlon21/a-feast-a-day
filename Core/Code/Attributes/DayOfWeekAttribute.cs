
namespace Core.Code.Attributes;

/// <summary>
/// Recommended Daily Allowance.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class DayOfWeekAttribute(DayOfWeek dayOfWeek) : Attribute
{
    public DayOfWeek DayOfWeek { get; set; } = dayOfWeek;
}
