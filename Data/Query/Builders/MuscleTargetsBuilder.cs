﻿using Core.Consts;
using Core.Models.User;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query.Options;

namespace Data.Query.Builders;

public interface IMuscleGroupBuilderNoContext
{
    IMuscleGroupBuilderFinalNoContext WithoutMuscleTargets();
}

public interface IMuscleGroupBuilderTargets : IMuscleGroupBuilderNoContext
{
    IMuscleGroupBuilderFinal WithMuscleTargets(IDictionary<IngredientGroup, int> muscleTargets);
    IMuscleGroupBuilderFinal WithMuscleTargetsFromMuscleGroups(IDictionary<IngredientGroup, int>? workedMusclesDict = null);
}

public interface IMuscleGroupBuilderFinalNoContext
{
    IngredientGroupOptions Build();
}

public interface IMuscleGroupBuilderFinal : IMuscleGroupBuilderFinalNoContext
{
    IMuscleGroupBuilderFinal AdjustMuscleTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true);
}

/// <summary>
/// Step-builder pattern for muscle target options.
/// </summary>
public class MuscleTargetsBuilder : IOptions, IMuscleGroupBuilderNoContext, IMuscleGroupBuilderFinalNoContext, IMuscleGroupBuilderTargets, IMuscleGroupBuilderFinal
{
    private readonly WorkoutContext? Context;

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IList<IngredientGroup> MuscleGroups = [];

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IDictionary<IngredientGroup, int> MuscleTargets = new Dictionary<IngredientGroup, int>();

    private MuscleTargetsBuilder(IList<IngredientGroup> muscleGroups, WorkoutContext? context)
    {
        MuscleGroups = muscleGroups;
        Context = context;
    }

    public static IMuscleGroupBuilderNoContext WithMuscleGroups(IList<IngredientGroup> muscleGroups)
    {
        return new MuscleTargetsBuilder(muscleGroups, null);
    }

    public static IMuscleGroupBuilderTargets WithMuscleGroups(WorkoutContext context, IList<IngredientGroup> muscleGroups)
    {
        return new MuscleTargetsBuilder(muscleGroups, context);
    }

    public IMuscleGroupBuilderFinalNoContext WithoutMuscleTargets()
    {
        return this;
    }

    public IMuscleGroupBuilderFinal WithMuscleTargets(IDictionary<IngredientGroup, int> muscleTargets)
    {
        MuscleTargets = muscleTargets;

        return this;
    }

    public IMuscleGroupBuilderFinal WithMuscleTargetsFromMuscleGroups(IDictionary<IngredientGroup, int>? workedMusclesDict = null)
    {
        MuscleTargets = UserIngredientGroup.MuscleTargets.Keys
            // Base 1 target for each targeted muscle group. If we've already worked this muscle, reduce the muscle target volume.
            // Keep all muscle groups in our target dict so we exclude overworked muscles.
            .ToDictionary(mt => mt, mt => (MuscleGroups.Any(mg => mt.HasFlag(mg)) ? 1 : 0) - (workedMusclesDict?.TryGetValue(mt, out int workedAmt) ?? false ? workedAmt : 0));

        return this;
    }

    /// <summary>
    /// Adjustments to the muscle groups to reduce muscle imbalances.
    /// Note: Don't change too much during deload weeks or they don't throw off the weekly muscle target tracking.
    /// </summary>
    public IMuscleGroupBuilderFinal AdjustMuscleTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true)
    {
        if (Context?.WeeklyMuscles != null && Context.WeeklyMusclesWeeks > UserConsts.MuscleTargetsTakeEffectAfterXWeeks)
        {
            foreach (var key in MuscleTargets.Keys)
            {
                // Adjust muscle targets based on the user's weekly muscle volume averages over the last several weeks.
                if (Context.WeeklyMuscles[key].HasValue && UserIngredientGroup.MuscleTargets.TryGetValue(key, out Range defaultRange))
                {
                    // Use the default muscle target when the user's workout split never targets this muscle group--because they can't adjust this muscle group's muscle target.
                    var targetRange = (IngredientGroup.All.HasFlag(key)
                        ? Context.User.UserIngredientGroups.FirstOrDefault(um => um.Group == key)?.Range
                        : null) ?? defaultRange;

                    // Don't be so harsh about what constitutes an out-of-range value when there is not a lot of weekly data to work with.
                    var middle = targetRange.Start.Value + UserConsts.IncrementMuscleTargetBy;
                    var adjustBy = Math.Max(1, ExerciseConsts.TargetVolumePerExercise / Convert.ToInt32(Context.WeeklyMusclesWeeks));
                    var adjustmentRange = new Range(targetRange.Start.Value, Math.Max(middle, targetRange.End.Value - adjustBy));

                    // We don't work this muscle group often enough
                    if (adjustUp && Context.WeeklyMuscles[key] < adjustmentRange.Start.Value)
                    {
                        // Cap the muscle targets so we never get more than 3 accessory exercises a day for a specific muscle group.
                        // If we've already worked this muscle, lessen the volume we cap at.
                        MuscleTargets[key] = Math.Min(2 + MuscleTargets[key], MuscleTargets[key] + (adjustmentRange.Start.Value - Context.WeeklyMuscles[key].GetValueOrDefault()) / adjustBy + 1);
                    }
                    // We work this muscle group too often
                    else if (adjustDown && Context.WeeklyMuscles[key] > adjustmentRange.End.Value)
                    {
                        // -1 means we don't choose any exercises that work this muscle. 0 means we don't specifically target this muscle, but exercises working other muscles may still be picked.
                        MuscleTargets[key] = Math.Max(-1, MuscleTargets[key] - (Context.WeeklyMuscles[key].GetValueOrDefault() - adjustmentRange.End.Value) / adjustBy - 1);
                    }
                    // We want a buffer before excluding muscle groups to where we don't target the muscle group, but still allow exercises that target the muscle to be chosen.
                    // Forearms, for example, are rarely something we want to target directly, since they are worked in many functional movements.
                    else if (adjustDownBuffer && Context.WeeklyMuscles[key] > middle)
                    {
                        MuscleGroups.Remove(key);
                    }
                }
            }
        }

        return this;
    }

    public IngredientGroupOptions Build()
    {
        return new IngredientGroupOptions(MuscleGroups, MuscleTargets);
    }
}