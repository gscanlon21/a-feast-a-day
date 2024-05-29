using Core.Code.Extensions;
using Core.Models.User;
using Data.Query;

namespace Data.Code.Extensions;

public static class RecipeExtensions
{
    /// <summary>
    /// Returns the bitwise ORed result of muscles targeted by any of the items in the list.
    /// </summary>
    public static Nutrient WorkedMuscles<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrient> muscleTarget, Nutrient? addition = null) where T : IRecipeCombo
    {
        return list.Aggregate(addition ?? Nutrient.None, (acc, curr) => acc | muscleTarget(curr));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static int WorkedAnyMuscleCount<T>(this IEnumerable<T> list, Nutrient muscleGroup, Func<IRecipeCombo, Nutrient> muscleTarget, int weightDivisor = 1) where T : IRecipeCombo
    {
        return list.Sum(r => muscleTarget(r).HasAnyFlag32(muscleGroup) ? 1 : 0) / weightDivisor;
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<Nutrient, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrient> muscleTarget, int weightDivisor = 1, IDictionary<Nutrient, int>? addition = null) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrient>().ToDictionary(k => k, v => ((addition?.TryGetValue(v, out int s) ?? false) ? s : 0) + (list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0) / weightDivisor));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<Nutrient, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IRecipeCombo, Nutrient> muscleTarget, Nutrient addition) where T : IRecipeCombo
    {
        return EnumExtensions.GetSingleValues32<Nutrient>().ToDictionary(k => k, v => (addition.HasFlag(v) ? 1 : 0) + list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0));
    }
}
