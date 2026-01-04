namespace Core.Code.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Orders an enum by it's [Display(Order = #)] attribute.
    /// </summary>
    public static IOrderedEnumerable<T> ThenByOrder<T>(this IOrderedEnumerable<T> list) where T : struct, Enum
    {
        return list.ThenBy(l => l.GetOrder(), NullOrder.NullsLast).ThenBy(l => Convert.ToInt64(l));
    }

    /// <summary>
    /// Orders an enum by it's [Display(Order = #)] attribute.
    /// </summary>
    public static IOrderedEnumerable<T> OrderByOrder<T>(this IEnumerable<T> list) where T : struct, Enum
    {
        return list.OrderBy(l => l.GetOrder(), NullOrder.NullsLast).ThenBy(l => Convert.ToInt64(l));
    }

    /// <summary>
    /// Orders an enum by it's [Display(Order = #)] attribute.
    /// </summary>
    public static IOrderedEnumerable<T> ThenByOrder<T, E>(this IOrderedEnumerable<T> list, Func<T, E> prop) where T : class where E : struct, Enum
    {
        return list.OrderBy(l => prop(l).GetOrder(), NullOrder.NullsLast).ThenBy(l => Convert.ToInt64(prop(l)));
    }

    /// <summary>
    /// Orders an enum by it's [Display(Order = #)] attribute.
    /// </summary>
    public static IOrderedEnumerable<T> OrderByOrder<T, E>(this IEnumerable<T> list, Func<T, E> prop) where T : class where E : struct, Enum
    {
        return list.OrderBy(l => prop(l).GetOrder(), NullOrder.NullsLast).ThenBy(l => Convert.ToInt64(prop(l)));
    }

    /// <summary>
    /// Returns the only element in the sequence if it exists, otherwise returns default.
    /// Does not throw an exception if there is more than one matching element in the set.
    /// </summary>
    public static TSource? OnlyOrDefault<TSource>(this IEnumerable<TSource> source)
    {
        return source.Count() == 1 ? source.Single() : default;
    }

    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static IEnumerable<TSource>? NullIfEmpty<TSource>(this IEnumerable<TSource>? source)
    {
        return source?.Any() == true ? source : null;
    }

    /// <summary>
    /// Returns true if the source list has any elements and matches the predicate.
    /// </summary>
    public static bool AllIfAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        return source.Any() && source.All(predicate);
    }

    public static IOrderedEnumerable<T> OrderByFalseToTrue<T>(this IEnumerable<T> list, Func<T, bool> keySelector)
    {
        return list.OrderBy(keySelector);
    }

    public static IOrderedEnumerable<T> OrderByTrueToFalse<T>(this IEnumerable<T> list, Func<T, bool> keySelector)
    {
        return list.OrderByDescending(keySelector);
    }

    public static IOrderedEnumerable<T> ThenByFalseToTrue<T>(this IOrderedEnumerable<T> list, Func<T, bool> keySelector)
    {
        return list.ThenBy(keySelector);
    }

    public static IOrderedEnumerable<T> ThenByTrueToFalse<T>(this IOrderedEnumerable<T> list, Func<T, bool> keySelector)
    {
        return list.ThenByDescending(keySelector);
    }

    public static IOrderedEnumerable<T> OrderByFalseToTrue<T>(this IEnumerable<T> list, Func<T, bool?> keySelector, NullOrder nullOrder)
    {
        return list.OrderBy(keySelector, nullOrder);
    }

    public static IOrderedEnumerable<T> OrderByTrueToFalse<T>(this IEnumerable<T> list, Func<T, bool?> keySelector, NullOrder nullOrder)
    {
        return list.OrderByDescending(keySelector, nullOrder);
    }

    public static IOrderedEnumerable<T> ThenByFalseToTrue<T>(this IOrderedEnumerable<T> list, Func<T, bool?> keySelector, NullOrder nullOrder)
    {
        return list.ThenBy(keySelector, nullOrder);
    }

    public static IOrderedEnumerable<T> ThenByTrueToFalse<T>(this IOrderedEnumerable<T> list, Func<T, bool?> keySelector, NullOrder nullOrder)
    {
        return list.ThenByDescending(keySelector, nullOrder);
    }

    public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.OrderBy(keySelector, NullableComparer<TKey>.Larger),
            NullOrder.NullsFirst => list.OrderBy(keySelector, NullableComparer<TKey>.Smaller),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.ThenBy(keySelector, NullableComparer<TKey>.Larger),
            NullOrder.NullsFirst => list.ThenBy(keySelector, NullableComparer<TKey>.Smaller),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.OrderByDescending(keySelector, NullableComparer<TKey>.Smaller),
            NullOrder.NullsFirst => list.OrderByDescending(keySelector, NullableComparer<TKey>.Larger),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> ThenByDescending<T, TKey>(this IOrderedEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : struct
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.ThenByDescending(keySelector, NullableComparer<TKey>.Smaller),
            NullOrder.NullsFirst => list.ThenByDescending(keySelector, NullableComparer<TKey>.Larger),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : class
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.OrderBy(keySelector, ClassComparer<TKey>.Larger),
            NullOrder.NullsFirst => list.OrderBy(keySelector, ClassComparer<TKey>.Smaller),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : class
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.ThenBy(keySelector, ClassComparer<TKey>.Larger),
            NullOrder.NullsFirst => list.ThenBy(keySelector, ClassComparer<TKey>.Smaller),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : class
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.OrderByDescending(keySelector, ClassComparer<TKey>.Smaller),
            NullOrder.NullsFirst => list.OrderByDescending(keySelector, ClassComparer<TKey>.Larger),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    public static IOrderedEnumerable<T> ThenByDescending<T, TKey>(this IOrderedEnumerable<T> list, Func<T, TKey?> keySelector, NullOrder nullOrder)
        where TKey : class
    {
        return nullOrder switch
        {
            NullOrder.NullsLast => list.ThenByDescending(keySelector, ClassComparer<TKey>.Smaller),
            NullOrder.NullsFirst => list.ThenByDescending(keySelector, ClassComparer<TKey>.Larger),
            _ => throw new ArgumentOutOfRangeException(nameof(nullOrder), nullOrder, null),
        };
    }

    internal class ClassComparer<T> : IComparer<T?> where T : class
    {
        public static ClassComparer<T> Larger => new ClassComparer<T>(true);
        public static ClassComparer<T> Smaller => new ClassComparer<T>(false);

        private readonly bool _isLarger;

        private ClassComparer(bool isLarger)
        {
            _isLarger = isLarger;
        }

        public int Compare(T? x, T? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return _isLarger ? 1 : -1;
            }

            if (y == null)
            {
                return _isLarger ? -1 : 1;
            }

            return Comparer<T>.Default.Compare(x, y);
        }
    }

    internal class NullableComparer<T> : IComparer<T?> where T : struct
    {
        public static NullableComparer<T> Larger => new NullableComparer<T>(true);
        public static NullableComparer<T> Smaller => new NullableComparer<T>(false);

        private readonly bool _isLarger;

        private NullableComparer(bool isLarger)
        {
            _isLarger = isLarger;
        }

        public int Compare(T? x, T? y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return _isLarger ? 1 : -1;
            }

            if (y == null)
            {
                return _isLarger ? -1 : 1;
            }

            return Comparer<T>.Default.Compare(x.Value, y.Value);
        }
    }

    public enum NullOrder
    {
        NullsLast,
        NullsFirst,
    }
}
