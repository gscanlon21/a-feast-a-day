
using static Core.Code.DoubleRange;

namespace Core.Code;

public readonly record struct DoubleRange(DoubleIndex Start, DoubleIndex End)
{
    public bool Contains(double value) => value >= Start.Value && value <= End.Value;

    public readonly struct DoubleIndex
    {
        public double Value { get; }

        public DoubleIndex(double value)
        {
            Value = value;
        }

        public static implicit operator DoubleIndex(int value) => new(value);
        public static implicit operator DoubleIndex(double value) => new(value);
    }
}
