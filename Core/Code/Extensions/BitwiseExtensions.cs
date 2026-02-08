using System.Linq.Expressions;

namespace Core.Code.Extensions;

public static class GenericBitwise<TFlagEnum> where TFlagEnum : struct, Enum
{
    private readonly static Func<TFlagEnum, TFlagEnum, TFlagEnum> _and;
    private readonly static Func<TFlagEnum, TFlagEnum, TFlagEnum> _or;
    private readonly static Func<TFlagEnum, TFlagEnum, TFlagEnum> _xor;
    private readonly static Func<TFlagEnum, TFlagEnum> _not;

    static GenericBitwise()
    {
        _and = And().Compile();
        _not = Not().Compile();
        _or = Or().Compile();
        _xor = Xor().Compile();
    }

    public static TFlagEnum And(TFlagEnum value1, TFlagEnum value2) => _and(value1, value2);
    public static TFlagEnum And(IEnumerable<TFlagEnum> list) => list.Aggregate(default(TFlagEnum), And);
    public static TFlagEnum Or(TFlagEnum value1, TFlagEnum value2) => _or(value1, value2);
    public static TFlagEnum Or(IEnumerable<TFlagEnum> list) => list.Aggregate(default(TFlagEnum), Or);
    public static TFlagEnum Xor(TFlagEnum value1, TFlagEnum value2) => _xor(value1, value2);
    public static TFlagEnum Xor(IEnumerable<TFlagEnum> list) => list.Aggregate(default(TFlagEnum), Xor);
    public static TFlagEnum Not(TFlagEnum value) => _not(value);

    public static TFlagEnum All()
    {
        var allFlags = Enum.GetValues(typeof(TFlagEnum)).Cast<TFlagEnum>();
        return Or(allFlags);
    }

    private static Expression<Func<TFlagEnum, TFlagEnum>> Not()
    {
        Type underlyingType = Enum.GetUnderlyingType(typeof(TFlagEnum));
        var arg1 = Expression.Parameter(typeof(TFlagEnum));

        return Expression.Lambda<Func<TFlagEnum, TFlagEnum>>(
            Expression.Convert(
                Expression.Not( // ~
                    Expression.Convert(arg1, underlyingType)
                ),
                // Convert the result of the tilde back into the enum type
                typeof(TFlagEnum)
            ),
            arg1
        );
    }

    private static Expression<Func<TFlagEnum, TFlagEnum, TFlagEnum>> And()
    {
        Type underlyingType = Enum.GetUnderlyingType(typeof(TFlagEnum));
        var arg1 = Expression.Parameter(typeof(TFlagEnum));
        var arg2 = Expression.Parameter(typeof(TFlagEnum));

        return Expression.Lambda<Func<TFlagEnum, TFlagEnum, TFlagEnum>>(
            Expression.Convert(
                // Combine the flags with an AND
                Expression.And(
                    // Convert the values to a bit maskable type (i.e. the underlying numeric type of the enum)
                    Expression.Convert(arg1, underlyingType),
                    Expression.Convert(arg2, underlyingType)
                ),
                // Convert the result of the AND back into the enum type
                typeof(TFlagEnum)
            ),
            arg1,
            arg2
        );
    }

    private static Expression<Func<TFlagEnum, TFlagEnum, TFlagEnum>> Or()
    {
        Type underlyingType = Enum.GetUnderlyingType(typeof(TFlagEnum));
        var arg1 = Expression.Parameter(typeof(TFlagEnum));
        var arg2 = Expression.Parameter(typeof(TFlagEnum));

        return Expression.Lambda<Func<TFlagEnum, TFlagEnum, TFlagEnum>>(
            Expression.Convert(
                // Combine the flags with an OR
                Expression.Or(
                    // Convert the values to a bit maskable type (i.e. the underlying numeric type of the enum)
                    Expression.Convert(arg1, underlyingType),
                    Expression.Convert(arg2, underlyingType)
                ),
                // Convert the result of the OR back into the enum type
                typeof(TFlagEnum)
            ),
            arg1,
            arg2
        );
    }

    private static Expression<Func<TFlagEnum, TFlagEnum, TFlagEnum>> Xor()
    {
        Type underlyingType = Enum.GetUnderlyingType(typeof(TFlagEnum));
        var arg1 = Expression.Parameter(typeof(TFlagEnum));
        var arg2 = Expression.Parameter(typeof(TFlagEnum));

        return Expression.Lambda<Func<TFlagEnum, TFlagEnum, TFlagEnum>>(
            Expression.Convert(
                // Combine the flags with an XOR
                Expression.ExclusiveOr(
                    // Convert the values to a bit maskable type (i.e. the underlying numeric type of the enum)
                    Expression.Convert(arg1, underlyingType),
                    Expression.Convert(arg2, underlyingType)
                ),
                // Convert the result of the OR back into the enum type
                typeof(TFlagEnum)
            ),
            arg1,
            arg2
        );
    }
}