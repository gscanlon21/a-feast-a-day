using Core.Models.Newsletter;
using Data.Query.Options;
using Data.Query.Options.Users;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder : QueryBuilderBase
{
    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public QueryBuilder(Section section) : base(section) { }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            UserOptions = new UserOptions(),
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