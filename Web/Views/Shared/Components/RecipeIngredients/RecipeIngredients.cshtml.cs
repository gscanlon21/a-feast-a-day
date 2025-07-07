using System.ComponentModel.DataAnnotations;
using Web.Views.Recipe;

namespace Web.Views.Shared.Components.RecipeIngredients;

public class RecipeIngredientsViewModel
{
    public required UserManageRecipeViewModel.Params Parameters { get; init; }

    [Display(Name = "Recipe Ingredients")]
    public required IList<Data.Entities.User.UserRecipeIngredient> UserRecipeIngredients { get; init; }
}
