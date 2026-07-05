using Lib.Code.Extensions;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Reflection;

namespace Lib.Code.Helpers;

public static class Formatter
{
    /// <summary>
    /// var displayFormat = prop.IsDefined(typeof(DisplayFormatAttribute), false);
    /// </summary>
    public static RenderFragment For<T, TValue>(T model, Expression<Func<T, TValue>> expr)
    {
        return builder =>
        {
            var member = (MemberExpression)expr.Body;
            var prop = (PropertyInfo)member.Member;

            var value = prop.GetValue(model)?.ToString() ?? "";
            builder.AddMarkupContent(0, value.FormatSymbols(Temperature.Fahrenheit));
        };
    }
}