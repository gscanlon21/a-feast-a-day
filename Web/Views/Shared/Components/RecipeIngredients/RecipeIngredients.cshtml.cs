using Data.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.RecipeIngredients;

public class RecipeIngredientsViewModel
{
    public required string Token { get; init; }

    public required Data.Entities.Users.User User { get; init; }

    [Display(Name = "Recipe Ingredients")]
    public required IList<UserRecipeIngredient> UserRecipeIngredients { get; init; }
}
