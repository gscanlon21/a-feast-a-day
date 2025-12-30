using Core.Models.Newsletter;
using Data.Code.Exceptions;
using Data.Entities.Users;
using Data.Query.Options;
using Data.Query.Options.Users;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class UserQueryBuilder : QueryBuilderBase
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
    public UserQueryBuilder WithUser(Action<UserOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(UserOptions);
        UserOptions ??= new UserOptions(User);
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
            RecipeOptions = RecipeOptions ?? new RecipeOptions(),
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            UserOptions = UserOptions ?? new UserOptions(User),
        };
    }
}