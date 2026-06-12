using System.Numerics;

namespace Core.Code.Extensions;

public static class NumberExtensions
{
    public static T? NullIfDefault<T>(this T source) where T : struct, INumber<T>
    {
        return source == default ? null : source;
    }
}
