using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.RecipeIngredients;

public class RecipeIngredientsViewModel
{
    public required string Token { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(Name = "Recipe Ingredients")]
    public required IList<Data.Entities.User.UserRecipeIngredient> UserRecipeIngredients { get; init; }
}
