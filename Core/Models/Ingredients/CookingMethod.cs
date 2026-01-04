using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

public enum CookingMethod
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Fried", ShortName = "Fry", Order = 1)]
    Fry = 1,

    [Display(Name = "Baked", ShortName = "Bake", Order = 2)]
    Bake = 2,

    [Display(Name = "Roasted", ShortName = "Roast", Order = 3)]
    Roast = 3,

    [Display(Name = "Broiled", ShortName = "Broil", Order = 4)]
    Broil = 4,
}
