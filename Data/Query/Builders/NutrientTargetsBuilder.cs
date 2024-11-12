using Core.Code;
using Core.Consts;
using Core.Models.Newsletter;
using Core.Models.User;
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
    NutrientOptions Build(Section section);
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
    public IDictionary<Nutrients, double> NutrientTargetsRDA = new Dictionary<Nutrients, double>();

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IDictionary<Nutrients, double> NutrientTargetsTUL = new Dictionary<Nutrients, double>();

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
        NutrientTargetsRDA = NutrientHelpers.All.ToDictionary(mt => mt, mt => Nutrients.Any(mg => mt.HasFlag(mg)) ? 1d : 0);

        // Base 1 target for each targeted Nutrient group. If we've already worked this Nutrient, reduce the Nutrient target volume.
        // Keep all Nutrient groups in our target dict so we exclude overworked Nutrients.
        NutrientTargetsTUL = NutrientHelpers.All.ToDictionary(mt => mt, mt => Nutrients.Any(mg => mt.HasFlag(mg)) ? 1d : 0);

        return this;
    }

    /// <summary>
    /// Adjustments to the Nutrient groups to reduce Nutrient imbalances.
    /// Note: Don't change too much during deload weeks or they don't throw off the weekly Nutrient target tracking.
    /// </summary>
    public INutrientBuilderFinal AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true, double scale = 1)
    {
        // Add some padding to the upper-bounds of the RDA and TUL since targets are split into groups,
        // ... makes it harder to choose recipes that are heavy in one or two nutrients.
        if (Context?.WeeklyNutrientsWeeks > UserConsts.NutrientTargetsTakeEffectAfterXWeeks)
        {
            scale += scale * UserConsts.IncrementNutrientTargetBy / 100d;
        }

        if (Context?.WeeklyNutrientsRDA != null)
        {
            foreach (var key in NutrientTargetsRDA.Keys)
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                if (Context.WeeklyNutrientsRDA[key].HasValue)
                {
                    NutrientTargetsRDA[key] = Context.WeeklyNutrientsRDA[key]!.Value * Math.Min(1, scale);
                }
            }
        }

        if (Context?.WeeklyNutrientsTUL != null)
        {
            foreach (var key in NutrientTargetsTUL.Keys)
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                if (Context.WeeklyNutrientsTUL[key].HasValue)
                {
                    NutrientTargetsTUL[key] = Context.WeeklyNutrientsTUL[key]!.Value * Math.Min(1, scale);
                }
            }
        }

        return this;
    }

    public NutrientOptions Build(Section section)
    {
        if (Context?.User != null)
        {
            if (Nutrients.Any())
            {
                Logs.AppendLog(Context.User, $"Nutrients for {section}:{Environment.NewLine}{string.Join(", ", Nutrients)}");
            }

            if (NutrientTargetsRDA.Any())
            {
                Logs.AppendLog(Context.User, $"Nutrient targets RDA for {section}:{Environment.NewLine}{string.Join(Environment.NewLine, NutrientTargetsRDA)}");
            }

            if (NutrientTargetsTUL.Any())
            {
                Logs.AppendLog(Context.User, $"Nutrient targets TUL for {section}:{Environment.NewLine}{string.Join(Environment.NewLine, NutrientTargetsTUL)}");
            }
        }

        return new NutrientOptions(Nutrients, NutrientTargetsRDA, NutrientTargetsTUL);
    }
}