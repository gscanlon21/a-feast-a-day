using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Shared;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageRecipeViewModel
{
    public required User.UserManageRecipeViewModel.Parameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(Name = "Recipe", Description = "Ignore this recipe.")]
    public required Data.Entities.User.Recipe Recipe { get; init; }

    public required Data.Entities.User.UserRecipe UserRecipe { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;

    public required Section RecipeSection { get; init; }
}
