using Core.Models.Newsletter;
using Data.Query.Options;
using Data.Query.Runners;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class SystemQueryBuilder : BaseQueryBuilder<SystemQueryBuilder>
{
    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public SystemQueryBuilder(Section section) : base(section) { }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override BaseQueryRunner Build()
    {
        return new SystemQueryRunner(Section)
        {
            RecipeOptions = RecipeOptions ?? new RecipeOptions(),
            ServingOptions = ServingOptions ?? new ServingOptions(),
            DurationOptions = DurationOptions ?? new DurationOptions(),
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            IngredientOptions = IngredientOptions ?? new IngredientOptions(),
        };
    }
}