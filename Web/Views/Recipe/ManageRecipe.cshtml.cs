using Core.Dtos.Newsletter;
using Core.Dtos.User;
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

    public bool? WasUpdated { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public required NewsletterRecipeDto NewsletterRecipe { get; init; }

    public required IList<NewsletterRecipeDto> PrepRecipes { get; init; }

    /// <summary>
    /// Verbosity of the recipe.
    /// Notes are always included.
    /// </summary>
    public Verbosity Verbosity => (User?.Verbosity ?? Verbosity.Images) | Verbosity.Notes;
}
