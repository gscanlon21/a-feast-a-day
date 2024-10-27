using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

public enum IngredientOrder
{
    [Display(Name = "Order Used")]
    OrderUsed = 0,

    [Display(Name = "Large to Small")]
    LargeToSmall = 1,
}
