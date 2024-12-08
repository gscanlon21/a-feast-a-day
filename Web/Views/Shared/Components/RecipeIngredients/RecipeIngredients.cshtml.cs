using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using Web.Views.Recipe;

namespace Web.Views.Shared.Components.RecipeIngredients;

public class RecipeIngredientsViewModel
{
    public required UserManageRecipeViewModel.Params Parameters { get; init; }

    [Display(Name = "Ignored Ingredients")]
    public required IList<IngredientDto> IgnoredIngredients { get; init; }

    [Display(Name = "Ingredients")]
    public required IList<IngredientDto> Ingredients { get; init; }

    public required UserNewsletterDto User { get; init; }

    public Verbosity IngredientVerbosity => User?.Verbosity ?? Verbosity.Images;
}
