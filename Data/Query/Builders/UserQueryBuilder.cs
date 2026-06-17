using Core.Models.Newsletter;
using Data.Code.Exceptions;
using Data.Entities.Users;
using Data.Query.Filters;
using Data.Query.Options;
using Data.Query.Options.Users;
using Data.Query.Runners;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class UserQueryBuilder<TFilter> : BaseQueryBuilder<UserQueryBuilder<TFilter>>
    where TFilter : BaseQueryFilter
{
    private readonly User User;

    private UserOptions? UserOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public UserQueryBuilder(User user, Section section) : base(section)
    {
        User = user;
    }

    /// <summary>
    /// Filter recipes according to the user's preferences.
    /// </summary>
    public UserQueryBuilder<TFilter> WithUser(Action<UserOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(UserOptions);
        UserOptions ??= new UserOptions(User);
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
            RecipeOptions = RecipeOptions ?? new RecipeOptions(),
            ServingOptions = ServingOptions ?? new ServingOptions(),
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            DurationOptions = DurationOptions ?? new DurationOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            IngredientOptions = IngredientOptions ?? new IngredientOptions(),
            UserOptions = UserOptions ?? new UserOptions(User),
            QueryFilter = CreateFilter(),
        };
    }

    private BaseQueryFilter CreateFilter()
    {
        if (typeof(TFilter) == typeof(UserQueryFilter))
        {
            return new UserQueryFilter(Section)
            {
                UserOptions = UserOptions ?? new UserOptions(User),
                NutrientOptions = NutrientOptions ?? new NutrientOptions(),
                ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
                SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            };
        }

        if (typeof(TFilter) == typeof(RecipeQueryFilter))
        {
            return new RecipeQueryFilter(Section)
            {
                RecipeOptions = RecipeOptions ?? new RecipeOptions(),
                SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            };
        }

        throw new NotImplementedException();
    }
}