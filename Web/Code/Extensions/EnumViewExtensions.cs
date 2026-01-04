using Microsoft.AspNetCore.Mvc.Rendering;

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
    public static IList<SelectListItem> AsSelectListItems<T>(this IEnumerable<T?> values, EnumOrdering order = EnumOrdering.Value, T? defaultValue = default, T? selectedValue = default, string? nullValueText = null, string? noValueText = null)
        where T : struct, Enum
    {
        var orderedValues = values.OrderByDescending(v => v.HasValue ? Convert.ToInt64(v) == Convert.ToInt64(defaultValue) : (bool?)null, EnumerableExtensions.NullOrder.NullsFirst);
        switch (order)
        {
            case EnumOrdering.Order:
                orderedValues = orderedValues.ThenBy(v => v?.GetOrder(), EnumerableExtensions.NullOrder.NullsFirst);
                break;
            case EnumOrdering.Value:
                orderedValues = orderedValues.ThenBy(v => v.HasValue ? Convert.ToInt64(v) : (long?)null, EnumerableExtensions.NullOrder.NullsFirst);
                break;
            case EnumOrdering.Text:
                orderedValues = orderedValues.ThenBy(v => v?.GetSingleDisplayName(), EnumerableExtensions.NullOrder.NullsFirst);
                break;
            case EnumOrdering.GroupText:
                orderedValues = orderedValues
                    .ThenBy(v => v?.GetSingleDisplayName(DisplayType.GroupName), EnumerableExtensions.NullOrder.NullsFirst)
                    .ThenBy(v => v?.GetSingleDisplayName(), EnumerableExtensions.NullOrder.NullsFirst);
                break;
        }

        return orderedValues.Select(v => new SelectListItem()
        {
            // Need to use an empty string so it posts null and not the name.
            Value = v == null ? string.Empty : Convert.ToInt64(v).ToString(),
            // We have to fallback and use the member's name for system enums. sa. DayOfWeek.
            Text = v == null ? nullValueText : v.GetSingleDisplayName().NullIfEmpty() ?? noValueText,
            Selected = selectedValue.HasValue ? Convert.ToInt64(v) == Convert.ToInt64(selectedValue) : !v.HasValue,
        })
        .ToList();
    }
}
