using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

/// <summary>
/// Order of ingredients in a recipe.
/// </summary>
public enum IngredientOrder
{
    [Display(Name = "Order Used")]
    OrderUsed = 0,

    [Display(Name = "Large to Small")]
    LargeToSmall = 1,

    [Display(Name = "Optional Last")]
    OptionalLast = 2,
}
