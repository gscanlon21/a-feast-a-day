using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Allergy : long
{
    None = 0,

    [Display(Name = "Lactose", GroupName = "Dairy")]
    Lactose = 1 << 0, // 1

    [Display(Name = "Casein", GroupName = "Dairy")]
    Casein = 1 << 1, // 2

    [Display(Name = "Dairy", GroupName = "Dairy")]
    Dairy = Lactose | Casein, // 3

    [Display(Name = "Gluten")]
    Gluten = 1 << 2, // 4

    [Display(Name = "Eggs")]
    Eggs = 1 << 3, // 8

    [Display(Name = "Tree Nuts")]
    TreeNuts = 1 << 4, // 16

    [Display(Name = "Peanuts")]
    Peanuts = 1 << 5, // 32

    [Display(Name = "Sesame")]
    Sesame = 1 << 6, // 64

    [Display(Name = "Soy")]
    Soy = 1 << 7, // 128

    [Display(Name = "Shellfish")]
    Shellfish = 1 << 8, // 256

    [Display(Name = "Fish")]
    Fish = 1 << 9, // 512

    [Display(Name = "Histamine")]
    Histamine = 1 << 10, // 1024

    [Display(Name = "Nightshades")]
    Nightshades = 1 << 11, // 2048

    [Display(Name = "Oats")]
    Oats = 1 << 12, // 4096

    [Display(Name = "Corn")]
    Corn = 1 << 13, // 8192

    [Display(Name = "Red Meat")]
    RedMeat = 1 << 14, // 16384

    [Display(Name = "Sugar Alcohols")]
    SugarAlcohols = 1 << 15, // 32768

    [Display(Name = "Caffeine")]
    Caffeine = 1 << 16, // 65536

    [Display(Name = "Salicylates")]
    Salicylates = 1 << 17, // 131072

    /// <summary>
    /// From fermented foods.
    /// </summary>
    [Display(Name = "Amines")]
    Amines = 1 << 18, // 262144

    [Display(Name = "Yeast")]
    Yeast = 1 << 19, // 524288

    /// <summary>
    /// Fermentable Oligosaccharides, Disaccharides, Monosaccharides and Polyols.
    /// </summary>
    [Display(Name = "FODMAP")]
    FODMAP = 1 << 20, // 1048576

    [Display(Name = "Aspartame")]
    Aspartame = 1 << 21, // 2097152

    [Display(Name = "Sulfites")]
    Sulfites = 1 << 22, // 4194304

    [Display(Name = "Fructose")]
    Fructose = 1 << 23, // 8388608

    [Display(Name = "Banana")]
    Banana = 1 << 24, // 16777216
}
