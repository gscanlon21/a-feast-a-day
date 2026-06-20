using System.Runtime.CompilerServices;

namespace Core.Code.Extensions;

public static class BooleanExtensions
{
    /// <summary>
    /// Model.BooLean.ToCssClass() -> "boo-lean";
    /// </summary>
    public static string? ToClass(this bool boolean, string? trueString = null, string? falseString = null, [CallerArgumentExpression(nameof(boolean))] string valueExp = "")
    {
        return boolean ? (trueString ?? valueExp.Split('.')[^1].ToHtmlSlug()) : falseString;
    }

    public static string? ToStyle(this bool boolean, string trueString, string? falseString = null)
    {
        return boolean ? trueString?.EndWith(';') : falseString?.EndWith(';');
    }

    public static string? ToClass(this bool? boolean, string? trueString = null, string? falseString = null, string? nullString = null, [CallerArgumentExpression(nameof(boolean))] string valueExp = "")
    {
        return boolean switch
        {
            null => nullString,
            false => falseString,
            true => trueString ?? valueExp.Split('.')[^1].ToHtmlSlug(),
        };
    }
}
