using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

public enum CookingMethod
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Fry")]
    Fry = 1,

    [Display(Name = "Bake")]
    Bake = 2,

    [Display(Name = "Roast")]
    Roast = 3,
}
