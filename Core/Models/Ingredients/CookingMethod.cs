using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

/// <summary>
/// How is an ingredient cooked?
/// Grilled is not included and can be covered by Roast/Broil.
/// </summary>
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

    [Display(Name = "Braised", ShortName = "Braise", Order = 4)]
    Braise = 4,

    [Display(Name = "Simmered", ShortName = "Simmer", Order = 5)]
    Simmer = 5,

    [Display(Name = "Steamed", ShortName = "Steam", Order = 6)]
    Steam = 6,

    [Display(Name = "Poached", ShortName = "Poach", Order = 7)]
    Poach = 7,

    [Display(Name = "Boiled", ShortName = "Boil", Order = 8)]
    Boil = 8,

    [Display(Name = "Stewed", ShortName = "Stew", Order = 9)]
    Stew = 9,

    [Display(Name = "Seared", ShortName = "Sear", Order = 10)]
    Sear = 10,

    [Display(Name = "Sautéd", ShortName = "Sauté", Order = 11)]
    Saute = 11,

    [Display(Name = "Pan Fried", ShortName = "Pan Fry", Order = 12)]
    PanFry = 12,

    [Display(Name = "Pan Fried", ShortName = "Pan Fry", Order = 13)]
    StirFry = 13,
}