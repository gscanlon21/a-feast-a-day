
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Code.Extensions;

public static class StringExtensions
{
    public static string? NullIfWhiteSpace(this string? str)
    {
        return string.IsNullOrWhiteSpace(str) ? null : str;
    }

    public static string? NullIfEmpty(this string? str)
    {
        return string.IsNullOrEmpty(str) ? null : str;
    }

    public static bool IsWhiteSpace(this string? str)
    {
        return !string.IsNullOrEmpty(str) && string.IsNullOrWhiteSpace(str);
    }

    /// <summary>
    /// Model.BooLean.ToCssClass() -> "boo-lean";
    /// </summary>
    public static string ToCssClass(this bool boolean, [CallerArgumentExpression(nameof(boolean))] string valueExp = "")
    {
        return boolean ? valueExp.Split('.')[^1].ToHtmlSlug() : string.Empty;
    }

    public static string ToHtmlSlug(this string str)
    {
        var stringBuilder = new StringBuilder();
        char previousChar = char.MinValue;
        foreach (char c in str)
        {
            if (char.IsUpper(c) || c == ' ' || c == '_')
            {
                if (stringBuilder.Length != 0 && previousChar != '-')
                {
                    stringBuilder.Append('-');
                }
            }

            stringBuilder.Append(c);
            previousChar = c;
        }

        return stringBuilder.ToString().ToLowerInvariant();
    }
}
