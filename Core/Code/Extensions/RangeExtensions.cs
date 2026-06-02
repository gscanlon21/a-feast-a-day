namespace Core.Code.Extensions;

public static class RangeExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double GetMiddle(this Range range)
    {
        return (range.Start.Value + range.End.Value) / 2d;
    }

    /// <summary>
    /// Converts an int Range into a DoubleRange.
    /// </summary>
    public static DoubleRange ToDouble(this Range range)
    {
        return new DoubleRange(range.Start.Value, range.End.Value);
    }
}
