using Core.Dtos.User;
using System.ComponentModel.DataAnnotations;
using Web.Views.Recipe;

namespace Web.Views.Shared.Components.RecipeIngredients;

public class RecipeIngredientsViewModel
{
    public required UserManageRecipeViewModel.Params Parameters { get; init; }

    [Display(Name = "Recipe Ingredients")]
    public required IList<Data.Entities.Recipe.RecipeIngredient> RecipeIngredients { get; init; }

    public required UserNewsletterDto User { get; init; }
}
