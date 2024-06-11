using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

public class UserIngredientViewModel
{
    public int UserId { get; set; }

    [Display(ShortName = "Ingredient", Name = "Base Ingredient")]
    public int IngredientId { get; init; }

    [Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public int SubstituteIngredientId { get; init; }
}
