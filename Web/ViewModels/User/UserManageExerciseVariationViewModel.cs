using Core.Models.Newsletter;
using Data.Entities.User;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public Data.Entities.User.User User { get; set; } = null!;

    public record Parameters(Section Section, string Email, string Token, int RecipeId);

    public required UserRecipe Recipe { get; set; }

    public bool? WasUpdated { get; init; }
}
