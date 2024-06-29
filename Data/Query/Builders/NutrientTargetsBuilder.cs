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
    INutrientBuilderFinal WithNutrientTargets();
}

public interface INutrientBuilderFinalNoContext
{
    NutrientOptions Build();
}

public interface INutrientBuilderFinal : INutrientBuilderFinalNoContext
{
    INutrientBuilderFinal AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true, double scale = 1);
}

/// <summary>
/// Step-builder pattern for Nutrient target options.
/// </summary>
public class NutrientTargetsBuilder : IOptions, INutrientBuilderNoContext, INutrientBuilderFinalNoContext, INutrientBuilderTargets, INutrientBuilderFinal
{
    private readonly FeastContext? Context;

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IList<Nutrients> Nutrients = [];

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IDictionary<Nutrients, double> NutrientTargets = new Dictionary<Nutrients, double>();

    private NutrientTargetsBuilder(IList<Nutrients> nutrients, FeastContext? context)
    {
        Nutrients = nutrients;
        Context = context;
    }

    public static INutrientBuilderNoContext WithNutrients(IList<Nutrients> Nutrients)
    {
        return new NutrientTargetsBuilder(Nutrients, null);
    }

    public static INutrientBuilderTargets WithNutrients(FeastContext context, IList<Nutrients> Nutrients)
    {
        return new NutrientTargetsBuilder(Nutrients, context);
    }

    public INutrientBuilderFinalNoContext WithoutNutrientTargets()
    {
        return this;
    }

    public INutrientBuilderFinal WithNutrientTargets()
    {
        // Base 1 target for each targeted Nutrient group. If we've already worked this Nutrient, reduce the Nutrient target volume.
        // Keep all Nutrient groups in our target dict so we exclude overworked Nutrients.
        NutrientTargets = UserNutrient.NutrientTargets.Keys.ToDictionary(mt => mt, mt => Nutrients.Any(mg => mt.HasFlag(mg)) ? 1d : 0);

        return this;
    }

    /// <summary>
    /// Adjustments to the Nutrient groups to reduce Nutrient imbalances.
    /// Note: Don't change too much during deload weeks or they don't throw off the weekly Nutrient target tracking.
    /// </summary>
    public INutrientBuilderFinal AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true, double scale = 1)
    {
        if (Context?.WeeklyNutrientsRDA != null && Context.WeeklyNutrientsTUL != null)
        {
            foreach (var key in NutrientTargets.Keys)
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                if (Context.WeeklyNutrientsRDA[key].HasValue && Context.WeeklyNutrientsTUL[key].HasValue && UserNutrient.NutrientTargets.TryGetValue(key, out Range defaultRange))
                {
                    var gramsUntilRDA = Context.WeeklyNutrientsRDA[key]!.Value * scale;
                    var gramsUntilTUL = Context.WeeklyNutrientsTUL[key]!.Value * scale;

                    NutrientTargets[key] = gramsUntilRDA;

                    // We want a buffer before excluding Nutrient groups to where we don't target the Nutrient group, but still allow exercises that target the Nutrient to be chosen.
                    // Forearms, for example, are rarely something we want to target directly, since they are worked in many functional movements.
                    if (adjustDownBuffer && gramsUntilRDA <= 0 && gramsUntilTUL >= 0)
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