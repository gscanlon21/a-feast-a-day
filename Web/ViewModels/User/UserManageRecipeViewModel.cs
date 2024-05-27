using Core.Models.Newsletter;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public Data.Entities.User.User User { get; set; } = null!;

    public record Parameters(Section Section, string Email, string Token, int RecipeId);

    public required Data.Entities.User.Recipe Recipe { get; set; }

    public required Shared.UserManageRecipeViewModel RecipeViewModel { get; init; }

    public bool? WasUpdated { get; init; }
}
