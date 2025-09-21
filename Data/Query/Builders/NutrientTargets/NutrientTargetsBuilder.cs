using Core.Models.Newsletter;
using Core.Models.User;
using Data.Query.Options;

namespace Data.Query.Builders.NutrientTargets;

public interface INutrientTargetsBuilder
{
    NutrientOptions Build(Section section);
}

/// <summary>
/// Step-builder pattern for Nutrient target options.
/// </summary>
public class NutrientTargetsBuilder : INutrientTargetsBuilder
{
    /// <summary>
    /// Filters variations to only those that target these Nutrient groups.
    /// </summary>
    public IList<Nutrients> Nutrients = [];

    private NutrientTargetsBuilder(IList<Nutrients> nutrients)
    {
        Nutrients = nutrients;
    }

    public static INutrientTargetsBuilder WithNutrients(IList<Nutrients> Nutrients)
    {
        return new NutrientTargetsBuilder(Nutrients);
    }

    public NutrientOptions Build(Section section)
    {
        return new NutrientOptions(Nutrients, [], []);
    }
}