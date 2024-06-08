using Core.Consts;
using Core.Models.User;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query.Options;

namespace Data.Query.Builders;

public interface INutrientBuilderNoContext
{
    INutrientBuilderFinalNoContext WithoutNutrientTargets();
}

public interface INutrientBuilderTargets : INutrientBuilderNoContext
{
    INutrientBuilderFinal WithNutrientTargets(IDictionary<Nutrients, int> NutrientTargets);
    INutrientBuilderFinal WithNutrientTargetsFromNutrients(IDictionary<Nutrients, int>? workedNutrientsDict = null);
}

public interface INutrientBuilderFinalNoContext
{
    NutrientOptions Build();
}

public interface INutrientBuilderFinal : INutrientBuilderFinalNoContext
{
    INutrientBuilderFinal AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true);
}

/// <summary>
/// Step-builder pattern for Nutrient target options.
/// </summary>
public class NutrientTargetsBuilder : IOptions, INutrientBuilderNoContext, INutrientBuilderFinalNoContext, INutrientBuilderTargets, INutrientBuilderFinal
{
    private readonly WorkoutContext? Context;

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IList<Nutrients> Nutrients = [];

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IDictionary<Nutrients, int> NutrientTargets = new Dictionary<Nutrients, int>();

    private NutrientTargetsBuilder(IList<Nutrients> nutrients, WorkoutContext? context)
    {
        Nutrients = nutrients;
        Context = context;
    }

    public static INutrientBuilderNoContext WithNutrients(IList<Nutrients> Nutrients)
    {
        return new NutrientTargetsBuilder(Nutrients, null);
    }

    public static INutrientBuilderTargets WithNutrients(WorkoutContext context, IList<Nutrients> Nutrients)
    {
        return new NutrientTargetsBuilder(Nutrients, context);
    }

    public INutrientBuilderFinalNoContext WithoutNutrientTargets()
    {
        return this;
    }

    public INutrientBuilderFinal WithNutrientTargets(IDictionary<Nutrients, int> nutrientTargets)
    {
        NutrientTargets = nutrientTargets;

        return this;
    }

    public INutrientBuilderFinal WithNutrientTargetsFromNutrients(IDictionary<Nutrients, int>? workedNutrientsDict = null)
    {
        NutrientTargets = UserNutrient.NutrientTargets.Keys
            // Base 1 target for each targeted Nutrient group. If we've already worked this Nutrient, reduce the Nutrient target volume.
            // Keep all Nutrient groups in our target dict so we exclude overworked Nutrients.
            .ToDictionary(mt => mt, mt => (Nutrients.Any(mg => mt.HasFlag(mg)) ? 1 : 0) - (workedNutrientsDict?.TryGetValue(mt, out int workedAmt) ?? false ? workedAmt : 0));

        return this;
    }

    /// <summary>
    /// Adjustments to the Nutrient groups to reduce Nutrient imbalances.
    /// Note: Don't change too much during deload weeks or they don't throw off the weekly Nutrient target tracking.
    /// </summary>
    public INutrientBuilderFinal AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true)
    {
        if (Context?.WeeklyNutrients != null && Context.WeeklyNutrientsWeeks > UserConsts.NutrientTargetsTakeEffectAfterXWeeks)
        {
            foreach (var key in NutrientTargets.Keys)
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                if (Context.WeeklyNutrients[key].HasValue && UserNutrient.NutrientTargets.TryGetValue(key, out Range defaultRange))
                {
                    // Use the default Nutrient target when the user's workout split never targets this Nutrient group--because they can't adjust this Nutrient group's Nutrient target.
                    var targetRange = (Core.Models.User.Nutrients.All.HasFlag(key)
                        ? Context.User.UserNutreints.FirstOrDefault(um => um.Nutrient == key)?.Range
                        : null) ?? defaultRange;

                    // Don't be so harsh about what constitutes an out-of-range value when there is not a lot of weekly data to work with.
                    var middle = targetRange.Start.Value + UserConsts.IncrementNutrientTargetBy;
                    var adjustBy = Math.Max(1, UserConsts.IncrementNutrientTargetBy / Convert.ToInt32(Context.WeeklyNutrientsWeeks));
                    var adjustmentRange = new Range(targetRange.Start.Value, Math.Max(middle, targetRange.End.Value - adjustBy));

                    // We don't work this Nutrient group often enough
                    if (adjustUp && Context.WeeklyNutrients[key] < adjustmentRange.Start.Value)
                    {
                        // Cap the Nutrient targets so we never get more than 3 accessory exercises a day for a specific Nutrient group.
                        // If we've already worked this Nutrient, lessen the volume we cap at.
                        NutrientTargets[key] = Math.Min(2 + NutrientTargets[key], NutrientTargets[key] + (adjustmentRange.Start.Value - Context.WeeklyNutrients[key].GetValueOrDefault()) / adjustBy + 1);
                    }
                    // We work this Nutrient group too often
                    else if (adjustDown && Context.WeeklyNutrients[key] > adjustmentRange.End.Value)
                    {
                        // -1 means we don't choose any exercises that work this Nutrient. 0 means we don't specifically target this Nutrient, but exercises working other Nutrients may still be picked.
                        NutrientTargets[key] = Math.Max(-1, NutrientTargets[key] - (Context.WeeklyNutrients[key].GetValueOrDefault() - adjustmentRange.End.Value) / adjustBy - 1);
                    }
                    // We want a buffer before excluding Nutrient groups to where we don't target the Nutrient group, but still allow exercises that target the Nutrient to be chosen.
                    // Forearms, for example, are rarely something we want to target directly, since they are worked in many functional movements.
                    else if (adjustDownBuffer && Context.WeeklyNutrients[key] > middle)
                    {
                        Nutrients.Remove(key);
                    }
                }
            }
        }

        return this;
    }

    public NutrientOptions Build()
    {
        return new NutrientOptions(Nutrients, NutrientTargets);
    }
}