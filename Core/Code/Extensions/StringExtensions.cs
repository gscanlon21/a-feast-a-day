
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
}
