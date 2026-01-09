using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.Ingredient;

namespace Web.Views.Shared.Components.ManageIngredient;

public class ManageIngredientViewModel
{
    [ValidateNever]
    public required UserManageIngredientViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.Users.User User { get; init; }

    [ValidateNever, Display(Name = "Ingredient")]
    public required Data.Entities.Ingredients.Ingredient Ingredient { get; init; }

    [ValidateNever]
    public required UserIngredient UserIngredient { get; init; }

    [Display(Name = "Notes", Description = "These show for the shopping list.")]
    public string? Notes { get; init; }
}
