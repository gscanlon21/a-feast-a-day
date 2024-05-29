using Core.Code.Extensions;
using Core.Models.User;
using Data.Query;

namespace Data.Code.Extensions;

public static class RecipeExtensions
{
    /// <summary>
    /// Returns the bitwise ORed result of muscles targeted by any of the items in the list.
    /// </summary>
    public static Nutrients WorkedMuscles<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> muscleTarget, Nutrients? addition = null) where T : IRecipeCombo
    {
        return list.Aggregate(addition ?? Nutrients.None, (acc, curr) => acc | muscleTarget(curr));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static int WorkedAnyMuscleCount<T>(this IEnumerable<T> list, Nutrients muscleGroup, Func<IRecipeCombo, Nutrients> muscleTarget, int weightDivisor = 1) where T : IRecipeCombo
    {
        return list.Sum(r => muscleTarget(r).HasAnyFlag32(muscleGroup) ? 1 : 0) / weightDivisor;
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<Nutrients, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> muscleTarget, int weightDivisor = 1, IDictionary<Nutrients, int>? addition = null) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrients>().ToDictionary(k => k, v => ((addition?.TryGetValue(v, out int s) ?? false) ? s : 0) + (list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0) / weightDivisor));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<Nutrients, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrients> muscleTarget, Nutrients addition) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrients>().ToDictionary(k => k, v => (addition.HasFlag(v) ? 1 : 0) + list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0));
    }
}
