using Core.Models.Newsletter;

namespace Web.Views.Recipe;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public record Params(string Email, string Token, int RecipeId, Section Section);

    public required Data.Entities.Recipe.Recipe Recipe { get; init; }

    public Data.Entities.User.User User { get; init; } = null!;

    public required Params Parameters { get; init; }

    public required bool HasUserRecipe { get; init; }

    public bool? WasUpdated { get; init; }
}
