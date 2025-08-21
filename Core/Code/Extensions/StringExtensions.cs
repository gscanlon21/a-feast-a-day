
namespace Core.Code.Extensions;

public static class StringExtensions
{
    public static string? NullIfEmpty(this string? str)
    {
        return str == "" ? null : str;
    }
}
