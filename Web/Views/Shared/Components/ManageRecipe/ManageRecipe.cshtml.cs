using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageRecipe;


public class ManageRecipeViewModel
{
    public required User.UserManageRecipeViewModel.Params Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(Name = "Recipe", Description = "Ignore this recipe.")]
    public required Data.Entities.User.Recipe Recipe { get; init; }

    public required Data.Entities.User.UserRecipe UserRecipe { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;
}
