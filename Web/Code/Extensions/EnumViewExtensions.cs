using Microsoft.AspNetCore.Mvc.Rendering;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Web.Code.Extensions;

public static class EnumViewExtensions
{
    public enum EnumOrdering
    {
        Value = 0,
        Text = 1,
        GroupText = 2,
        Order = 3,
    }

    /// <summary>
    /// Converts enum values to a select list for views.
    /// 
    /// The default value for the enum, 0, will always come first.
    /// </summary>
    public static IList<SelectListItem> AsSelectListItems<T>(this IEnumerable<T> values, EnumOrdering order = EnumOrdering.Value, T defaultValue = default, T selectedValue = default)
        where T : struct, Enum
    {
        return values.Cast<T?>().AsSelectListItems(order: order, defaultValue: defaultValue, selectedValue: selectedValue);
    }

    /// <summary>
    /// Converts enum values to a select list for views.
    /// 
    /// The default value for the enum, 0, will always come first.
    /// </summary>
    public static IList<SelectListItem> AsSelectListItems<T>(this IEnumerable<T?> values, EnumOrdering order = EnumOrdering.Value, T? defaultValue = default, T? selectedValue = default)
        where T : struct, Enum
    {
        var orderedValues = values.OrderByDescending(v => v.HasValue ? Convert.ToInt64(v) == Convert.ToInt64(defaultValue) : (bool?)null, NullOrder.NullsFirst);
        switch (order)
        {
            case EnumOrdering.Order:
                orderedValues = orderedValues.ThenBy(v => v?.GetOrder(), NullOrder.NullsFirst);
                break;
            case EnumOrdering.Value:
                orderedValues = orderedValues.ThenBy(v => v.HasValue ? Convert.ToInt64(v) : (long?)null, NullOrder.NullsFirst);
                break;
            case EnumOrdering.Text:
                orderedValues = orderedValues.ThenBy(v => v?.GetSingleDisplayName(), NullOrder.NullsFirst);
                break;
            case EnumOrdering.GroupText:
                orderedValues = orderedValues
                    .ThenBy(v => v?.GetSingleDisplayNameOrNull(DisplayType.GroupName), NullOrder.NullsFirst)
                    .ThenBy(v => v?.GetOrder(), NullOrder.NullsFirst)
                    .ThenBy(v => v?.GetSingleDisplayName(), NullOrder.NullsFirst);
                break;
        }

        return orderedValues.Select(v => new SelectListItem()
        {
            // No OrNull for DayOfWeek enum.
            Text = v?.GetSingleDisplayName(),
            // Need to use an empty string so it posts null and not the name.
            Value = v == null ? string.Empty : Convert.ToInt64(v).ToString(),
            Selected = selectedValue.HasValue ? Convert.ToInt64(v) == Convert.ToInt64(selectedValue) : !v.HasValue,
        })
        .ToList();
    }
}
