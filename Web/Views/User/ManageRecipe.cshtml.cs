using Core.Models.Newsletter;

namespace Web.Views.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public record Params(string Email, string Token, int RecipeId);

    public required Params Parameters { get; init; }

    public Data.Entities.User.User User { get; init; } = null!;

    public required Data.Entities.User.Recipe Recipe { get; init; }

    public required bool HasUserRecipe { get; init; }

    public bool? WasUpdated { get; init; }
}
