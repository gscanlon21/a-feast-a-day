using Core.Models.Newsletter;
using Core.Models.User;
using Data.Models.Newsletter;
using Data.Query.Builders.NutrientTargets;
using Data.Query.Options;

namespace Data.Query.Builders;

public interface INutrientTargetsContextBuilderStep1 : INutrientTargetsBuilder
{
    INutrientTargetsBuilder AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true, double scale = 1);
}

/// <summary>
/// Step-builder pattern for Nutrient target options.
/// </summary>
public class NutrientTargetsContextBuilder : IOptions, INutrientTargetsBuilder, INutrientTargetsContextBuilderStep1
{
    private readonly FeastContext Context;

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IList<Nutrients> Nutrients = [];

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public Dictionary<Nutrients, double> NutrientTargetsRDA = [];

    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public Dictionary<Nutrients, double> NutrientTargetsTUL = [];

    private NutrientTargetsContextBuilder(FeastContext context, IList<Nutrients> nutrients)
    {
        Nutrients = nutrients;
        Context = context;
    }

    public static INutrientTargetsContextBuilderStep1 WithNutrients(FeastContext context, IList<Nutrients> nutrients)
    {
        return new NutrientTargetsContextBuilder(context, nutrients);
    }

    /// <summary>
    /// Adjustments to the Nutrient groups to reduce Nutrient imbalances.
    /// Note: Don't change too much during deload weeks or they don't throw off the weekly Nutrient target tracking.
    /// </summary>
    public INutrientTargetsBuilder AdjustNutrientTargets(bool adjustUp = true, bool adjustDown = true, bool adjustDownBuffer = true, double scale = 1)
    {
        // Add some padding to the upper-bounds of the RDA and TUL since targets are split into groups,
        // ... makes it harder to choose recipes that are heavy in one or two nutrients.
        if (Context.WeeklyNutrientsWeeks > UserConsts.NutrientTargetsTakeEffectAfterXWeeks)
        {
            scale *= UserConsts.NutrientTargetsScale;
        }

        if (Context.WeeklyNutrientsRDA != null)
        {
            foreach (var weeklyNutrientRDA in Context.WeeklyNutrientsRDA.Where(kv => kv.Value.HasValue))
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                NutrientTargetsRDA.Add(weeklyNutrientRDA.Key, weeklyNutrientRDA.Value.GetValueOrDefault() * Math.Min(1, scale));
            }
        }

        if (Context.WeeklyNutrientsTUL != null)
        {
            foreach (var weeklyNutrientTUL in Context.WeeklyNutrientsTUL.Where(kv => kv.Value.HasValue))
            {
                // Adjust Nutrient targets based on the user's weekly Nutrient volume averages over the last several weeks.
                NutrientTargetsTUL.Add(weeklyNutrientTUL.Key, weeklyNutrientTUL.Value.GetValueOrDefault() * Math.Min(1, scale));
            }
        }

        return this;
    }

    public NutrientOptions Build(Section section)
    {
        if (Nutrients.Any())
        {
            UserLogs.Log(Context.User, $"Nutrients for {section}:{Environment.NewLine}{string.Join(", ", Nutrients)}");
        }

        if (NutrientTargetsRDA.Any())
        {
            UserLogs.Log(Context.User, $"Nutrient targets RDA for {section}:{Environment.NewLine}{string.Join(Environment.NewLine, NutrientTargetsRDA)}");
        }

        if (NutrientTargetsTUL.Any())
        {
            UserLogs.Log(Context.User, $"Nutrient targets TUL for {section}:{Environment.NewLine}{string.Join(Environment.NewLine, NutrientTargetsTUL)}");
        }

        return new NutrientOptions(Nutrients, NutrientTargetsRDA, NutrientTargetsTUL);
    }
}