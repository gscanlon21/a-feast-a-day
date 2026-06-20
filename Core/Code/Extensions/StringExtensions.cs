using System.Text;

namespace Core.Code.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Replace double spaces with single spaces.
    /// </summary>
    public static string TrimSpaces(this string str)
    {
        return str.Replace("  ", " ");
    }

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

    public static string? EndWith(this string? str, char append)
    {
        return str == null ? str : str.TrimEnd(append) + append;
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
