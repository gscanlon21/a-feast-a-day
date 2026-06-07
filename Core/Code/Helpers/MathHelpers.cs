
namespace Core.Code.Helpers;

public class MathHelpers
{
    /// <summary>
    /// Find the difference between two integers.
    /// </summary>
    public static int? Diff(int? val1, int? val2)
    {
        if (!val1.HasValue || !val2.HasValue)
        {
            return null;
        }

        return Math.Abs(val1.Value - val2.Value);
    }

    /// <summary>
    /// Rounds a number down if decimal is less than the cutoff.
    /// If the decimal is equal to cutoff, then we round up.
    /// </summary>
    /// <param name="cutoff">A number between 0 and 1.</param>
    public static int RoundDownUnder(double number, double cutoff)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(cutoff, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(cutoff, 1);

        return (int)Math.Floor(number + (1 - cutoff));
    }

    /// <summary>
    /// Rounds a number up if decimal is greater than the cutoff.
    /// If the decimal is equal to cutoff, then we round down.
    /// </summary>
    /// <param name="cutoff">A number between 0 and 1.</param>
    public static int RoundUpAbove(double number, double cutoff)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(cutoff, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(cutoff, 1);

        return (int)Math.Ceiling(number - cutoff);
    }
}
