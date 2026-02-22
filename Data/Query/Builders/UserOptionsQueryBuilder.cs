using Core.Models.Newsletter;
using Data.Query.Options;
using Data.Query.Options.Users;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class UserOptionsQueryBuilder : QueryBuilderBase
{
    private readonly UserOptions UserOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public UserOptionsQueryBuilder(UserOptions userOptions, Section section) : base(section)
    {
        UserOptions = userOptions;
    }

    public UserOptionsQueryBuilder WithUser(Action<UserOptions>? builder = null)
    {
        builder?.Invoke(UserOptions);
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            UserOptions = UserOptions,
            RecipeOptions = RecipeOptions ?? new RecipeOptions(),
            ServingOptions = ServingOptions ?? new ServingOptions(),
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            DurationOptions = DurationOptions ?? new DurationOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            IngredientOptions = IngredientOptions ?? new IngredientOptions(),
        };
    }
}