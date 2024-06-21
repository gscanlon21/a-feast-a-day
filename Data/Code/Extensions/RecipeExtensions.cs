using Core.Code.Extensions;
using Core.Models.User;
using Data.Query;

namespace Data.Code.Extensions;

public static class RecipeExtensions
{
    /// <summary>
    /// Returns the bitwise ORed result of muscles targeted by any of the items in the list.
    /// </summary>
    internal static Nutrients WorkedNutrients<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> nutrientTarget, Nutrients? addition = null) where T : IRecipeCombo
    {
        return list.Aggregate(addition ?? Nutrients.None, (acc, curr) => acc | nutrientTarget(curr));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    internal static int WorkedAnyNutrientCount<T>(this IEnumerable<T> list, Nutrients nutrients, Func<IRecipeCombo, Nutrients> nutrientTarget, int weightDivisor = 1) where T : IRecipeCombo
    {
        return list.Sum(r => nutrientTarget(r).HasAnyFlag32(nutrients) ? 1 : 0) / weightDivisor;
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    internal static IDictionary<Nutrients, int> WorkedNutrientsDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> nutrientTarget, int weightDivisor = 1, IDictionary<Nutrients, int>? addition = null) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrients>().ToDictionary(k => k, v => ((addition?.TryGetValue(v, out int s) ?? false) ? s : 0) + (list.Sum(r => nutrientTarget(r).HasFlag(v) ? 1 : 0) / weightDivisor));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    internal static IDictionary<Nutrients, int> WorkedNutrientsDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> nutrientTarget, Nutrients addition) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrients>().ToDictionary(k => k, v => (addition.HasFlag(v) ? 1 : 0) + list.Sum(r => nutrientTarget(r).HasFlag(v) ? 1 : 0));
    }
}
