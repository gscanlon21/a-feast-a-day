using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum IngredientGroup
{
    None = 0,

    [Display(Name = "Fruits", GroupName = "Fruits and Vegatables")]
    Fruits = 1 << 0, // 1

    [Display(Name = "Fruits", GroupName = "Fruits and Vegetables")]
    Vegetables = 1 << 1, // 2

    [Display(Name = "Vegetable Oils", GroupName = "Unsaturated Fats and Cholesterol")]
    VegetableOils = 1 << 2, // 4

    [Display(Name = "Unsaturated Fats", GroupName = "Unsaturated Fats and Cholesterol")]
    UnsaturatedFats = 1 << 3, // 8

    [Display(Name = "Dairy", GroupName = "Dairy")]
    Dairy = 1 << 4, // 16

    [Display(Name = "Whole Grains", GroupName = "Whole Grains")]
    WholeGrains = 1 << 5, // 32

    [Display(Name = "Poultry", GroupName = "Fish, Poultry, and Eggs")]
    Poultry = 1 << 6, // 64

    [Display(Name = "Poultry", GroupName = "Fish, Poultry, and Eggs")]
    Eggs = 1 << 7, // 128

    [Display(Name = "Poultry", GroupName = "Fish, Poultry, and Eggs")]
    Fish = 1 << 8, // 256

    [Display(Name = "Nuts", GroupName = "Nuts, Seeds, Beans, and Tofu")]
    Nuts = 1 << 9, // 512

    [Display(Name = "Seeds", GroupName = "Nuts, Seeds, Beans, and Tofu")]
    Seeds = 1 << 10, // 1024

    [Display(Name = "Beans", GroupName = "Nuts, Seeds, Beans, and Tofu")]
    Beans = 1 << 11, // 2048

    [Display(Name = "Tofu", GroupName = "Nuts, Seeds, Beans, and Tofu")]
    Tofu = 1 << 12, // 4096,

    [Display(Name = "Red Meat", GroupName = "Red Meat and Butter")]
    RedMeat = 1 << 13, // 8192

    [Display(Name = "Butter", GroupName = "Red Meat and Butter")]
    Butter = 1 << 14, // 16384

    [Display(Name = "Refined Grains", GroupName = "Refined Grains")]
    RefinedGrains = 1 << 15, // 32768
}
