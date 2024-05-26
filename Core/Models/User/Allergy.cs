using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Allergy
{
    None = 0,
    
    [Display(Name = "Lactose")]
    Lactose = 1 << 0, // 1

    [Display(Name = "Eggs")]
    Eggs = 1 << 1, // 2

    [Display(Name = "Tree Nuts")]
    TreeNuts = 1 << 2, // 4

    [Display(Name = "Peanuts")]
    Peanuts = 1 << 3, // 8

    [Display(Name = "Shellfish")]
    Shellfish = 1 << 4, // 16

    [Display(Name = "Gluten")]
    Gluten = 1 << 5, // 32

    [Display(Name = "Soy")]
    Soy = 1 << 6, // 64

    [Display(Name = "Fish")]
    Fish = 1 << 7, // 128

    [Display(Name = "Sesame")]
    Sesame = 1 << 8, // 256

    [Display(Name = "Histamine")]
    Histamine = 1 << 9, // 512
}
