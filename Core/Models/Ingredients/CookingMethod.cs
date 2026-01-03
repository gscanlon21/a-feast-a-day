using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

public enum CookingMethod
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Fried", ShortName = "Fry")]
    Fry = 1,

    [Display(Name = "Baked", ShortName = "Bake")]
    Bake = 2,

    [Display(Name = "Roasted", ShortName = "Roast")]
    Roast = 3,

    [Display(Name = "Broiled", ShortName = "Broil")]
    Broil = 4,
}
