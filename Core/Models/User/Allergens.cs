using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

/// <summary>
/// Keep this in sync with ADiaryADay's Allergens enum.
/// </summary>
[Flags]
public enum Allergens : long
{
    None = 0,

    [Display(Name = "Almonds")]
    Almonds = 1 << 0, // 1

    [Display(Name = "Corn")]
    Corn = 1 << 1, // 2

    [Display(Name = "Dairy")]
    Dairy = 1 << 2, // 4

    [Display(Name = "Eggs")]
    Eggs = 1 << 3, // 8

    [Display(Name = "Fish")]
    Fish = 1 << 4, // 16

    [Display(Name = "Gluten")]
    Gluten = 1 << 5, // 32

    [Display(Name = "Lactose")]
    Lactose = 1 << 6, // 64

    [Display(Name = "Lupin")]
    Lupin = 1 << 7, // 128

    [Display(Name = "Milk")]
    Milk = 1 << 8, // 256

    [Display(Name = "Nightshades")]
    Nightshades = 1 << 9, // 512

    [Display(Name = "Oats")]
    Oats = 1 << 10, // 1024

    [Display(Name = "Peanuts")]
    Peanuts = 1 << 11, // 2048

    [Display(Name = "Rice")]
    Rice = 1 << 12, // 4096

    [Display(Name = "Sesame")]
    Sesame = 1 << 13, // 8192

    [Display(Name = "Shellfish")]
    Shellfish = 1 << 14, // 16384

    [Display(Name = "Soy")]
    Soy = 1 << 15, // 32768

    [Display(Name = "Sunflower")]
    Sunflower = 1 << 16, // 65536

    [Display(Name = "Tree Nuts")]
    TreeNuts = 1 << 17, // 131072

    [Display(Name = "Wheat")]
    Wheat = 1 << 18, // 262144

    [Display(Name = "Yeast")]
    Yeast = 1 << 19, // 524288

    [Display(Name = "Meat")]
    Meat = 1 << 20, // 1048576
}
