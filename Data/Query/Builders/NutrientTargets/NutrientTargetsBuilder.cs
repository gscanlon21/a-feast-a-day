using Core.Models.Newsletter;
using Core.Models.Nutrients;
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
    public DataSource DataSource { get; }

    private NutrientTargetsBuilder(IList<Nutrients> nutrients, DataSource dataSource)
    {
        Nutrients = nutrients;
    }

    public static INutrientTargetsBuilder WithNutrients(IList<Nutrients> Nutrients, DataSource dataSource)
    {
        return new NutrientTargetsBuilder(Nutrients, dataSource);
    }

    public NutrientOptions Build(Section section)
    {
        return new NutrientOptions(Nutrients, [], [], DataSource);
    }
}