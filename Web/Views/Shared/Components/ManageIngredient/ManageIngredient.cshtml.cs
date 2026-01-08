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

    [Required, Range(RecipeConsts.ServingsMin, RecipeConsts.ServingsMax)]
    [Display(Name = "Minimum Servings", Description = "Minimum servings the recipe should be scaled for.")]
    public int Servings { get; init; } = RecipeConsts.ServingsDefault;

    [Display(Name = "Notes")]
    public string? Notes { get; init; }
}
