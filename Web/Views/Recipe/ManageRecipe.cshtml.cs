using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.User;

namespace Web.Views.Recipe;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public record Params(string Email, string Token, int RecipeId, Section Section);

    public bool? WasUpdated { get; init; }

    public required Params Parameters { get; init; }

    public Data.Entities.Users.User User { get; init; } = null!;

    public required UserNewsletterDto UserNewsletter { get; init; }

    public required Data.Entities.Recipes.Recipe Recipe { get; init; }

    public required NewsletterRecipeDto? NewsletterRecipe { get; init; }

    public required IList<NewsletterRecipeDto> PrepRecipes { get; init; }

    /// <summary>
    /// Verbosity of the recipe.
    /// Notes are always included.
    /// </summary>
    public Verbosity Verbosity => (User?.Verbosity ?? Verbosity.Images) | Verbosity.Notes;

    /// <summary>
    /// User must have created the recipe to be able to edit it.
    /// </summary>
    public bool CanManage => User.Id == Recipe.UserId || User.Features.HasFlag(Features.Admin);
}
