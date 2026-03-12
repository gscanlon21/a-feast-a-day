using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum Multiplier
{
    [Display(Name = "Day")]
    Day = 0,

    [Display(Name = "Total Energy")]
    TotalEnergy = 1,

    [Display(Name = "Kilogram", ShortName = "kg")]
    KilogramOfBodyweight = 2,

    [Display(Name = "Kilocalorie", ShortName = "Kcal")]
    Kilocalorie = 3,
}
