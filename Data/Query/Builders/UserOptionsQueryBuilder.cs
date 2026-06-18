using Core.Models.Newsletter;
using Data.Query.Filters;
using Data.Query.Options;
using Data.Query.Options.Users;
using Data.Query.Runners;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class UserOptionsQueryBuilder<TFilter> : BaseQueryBuilder<UserOptionsQueryBuilder<TFilter>>
    where TFilter : BaseQueryFilter
{
    private readonly UserOptions UserOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public UserOptionsQueryBuilder(UserOptions userOptions, Section section) : base(section)
    {
        UserOptions = userOptions;
    }

    public UserOptionsQueryBuilder<TFilter> WithUser(Action<UserOptions>? builder = null)
    {
        builder?.Invoke(UserOptions);
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public override BaseQueryRunner Build()
    {
        return new UserQueryRunner(Section)
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
            QueryFilter = CreateFilter(),
        };
    }

    private BaseQueryFilter CreateFilter()
    {
        if (typeof(TFilter) == typeof(UserQueryFilter))
        {
            return new UserQueryFilter(Section)
            {
                UserOptions = UserOptions,
                NutrientOptions = NutrientOptions ?? new NutrientOptions(),
                ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
                SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            };
        }

        if (typeof(TFilter) == typeof(RecipeQueryFilter))
        {
            return new RecipeQueryFilter()
            {
                SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            };
        }

        throw new NotImplementedException();
    }
}