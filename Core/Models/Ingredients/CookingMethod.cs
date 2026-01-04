using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

public enum CookingMethod
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Baked", ShortName = "Bake", Order = 1)]
    Bake = 1,

    [Display(Name = "Roasted", ShortName = "Roast", Order = 2)]
    Roast = 2,

    [Display(Name = "Broiled", ShortName = "Broil", Order = 3)]
    Broil = 3,

    [Display(Name = "Sautéd", ShortName = "Sauté", Order = 4)]
    Saute = 4,

    [Display(Name = "Fried", ShortName = "Fry", Order = 5)]
    Fry = 5,
}
