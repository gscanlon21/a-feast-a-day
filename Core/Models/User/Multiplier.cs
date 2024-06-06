using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum Multiplier
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Person")]
    Person = 1,

    [Display(Name = "Kilogram of bodyweight")]
    KilogramOfBodyweight = 2,

    [Display(Name = "Kilocalorie")]
    Kilocalorie = 3,
}
