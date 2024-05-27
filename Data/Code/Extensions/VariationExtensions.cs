﻿using Core.Code.Extensions;
using Core.Models.User;
using Data.Query;

namespace Data.Code.Extensions;

public static class VariationExtensions
{
    /// <summary>
    /// Returns the bitwise ORed result of muscles targeted by any of the items in the list.
    /// </summary>
    public static IngredientGroup WorkedMuscles<T>(this IEnumerable<T> list, Func<IExerciseVariationCombo, IngredientGroup> muscleTarget, IngredientGroup? addition = null) where T : IExerciseVariationCombo
    {
        return list.Aggregate(addition ?? IngredientGroup.None, (acc, curr) => acc | muscleTarget(curr));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static int WorkedAnyMuscleCount<T>(this IEnumerable<T> list, IngredientGroup muscleGroup, Func<IExerciseVariationCombo, IngredientGroup> muscleTarget, int weightDivisor = 1) where T : IExerciseVariationCombo
    {
        return list.Sum(r => muscleTarget(r).HasAnyFlag32(muscleGroup) ? 1 : 0) / weightDivisor;
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<IngredientGroup, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IExerciseVariationCombo, IngredientGroup> muscleTarget, int weightDivisor = 1, IDictionary<IngredientGroup, int>? addition = null) where T : IExerciseVariationCombo
    {
        return EnumExtensions.GetSingleValues32<IngredientGroup>().ToDictionary(k => k, v => ((addition?.TryGetValue(v, out int s) ?? false) ? s : 0) + (list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0) / weightDivisor));
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    public static IDictionary<IngredientGroup, int> WorkedMusclesDict<T>(this IEnumerable<T> list, Func<IExerciseVariationCombo, IngredientGroup> muscleTarget, IngredientGroup addition) where T : IExerciseVariationCombo
    {
        return EnumExtensions.GetSingleValues32<IngredientGroup>().ToDictionary(k => k, v => (addition.HasFlag(v) ? 1 : 0) + list.Sum(r => muscleTarget(r).HasFlag(v) ? 1 : 0));
    }
}