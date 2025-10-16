
namespace Core.Code.Extensions;

public static class MathExtensions
{
    public static int? Diff(int? val1, int? val2)
    {
        if (!val1.HasValue || !val2.HasValue)
        {
            return null;
        }

        return Math.Abs(val1.Value - val2.Value);
    }
}
