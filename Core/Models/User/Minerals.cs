using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Minerals
{
    None = 0,

    // Major
    [Display(Name = "Calcium", GroupName = "Fruits and Vegatables", Description = "yogurt, cheese, milk, salmon, leafy green vegetables")]
    Calcium = 1 << 0, // 1

    [Display(Name = "Chloride", GroupName = "Fruits and Vegetables", Description = "salt")]
    Chloride = 1 << 1, // 2

    [Display(Name = "Magnesium", GroupName = "Unsaturated Fats and Cholesterol", Description = "Spinach, broccoli, legumes, seeds, whole-wheat bread")]
    Magnesium = 1 << 2, // 4

    [Display(Name = "Potassium", GroupName = "Unsaturated Fats and Cholesterol", Description = "meat, milk, fruits, vegetables, grains, legumes")]
    Potassium = 1 << 3, // 8

    [Display(Name = "Sodium", GroupName = "Dairy", Description = "salt, soy sauce, vegetables")]
    Sodium = 1 << 4, // 16

    // Trace
    [Display(Name = "Chromium", GroupName = "Whole Grains", Description = "meat, poultry, fish, nuts, cheese")]
    Chromium = 1 << 5, // 32

    [Display(Name = "Copper", GroupName = "Fish, Poultry, and Eggs", Description = "shellfish, nuts, seeds, whole-grain products, beans, prunes")]
    Copper = 1 << 6, // 64

    [Display(Name = "Fluoride", GroupName = "Fish, Poultry, and Eggs", Description = "fish, teas")]
    Fluoride = 1 << 7, // 128

    [Display(Name = "Iodine", GroupName = "Fish, Poultry, and Eggs", Description = "Iodized salt, seafood")]
    Iodine = 1 << 8, // 256

    [Display(Name = "Iron", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "red meat, poultry, eggs, fruits, green vegetables, fortified bread")]
    Iron = 1 << 9, // 512

    [Display(Name = "Manganese", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "nuts, legumes, whole grains, tea")]
    Manganese = 1 << 10, // 1024

    [Display(Name = "Selenium", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "Organ meat, seafood, walnuts")]
    Selenium = 1 << 11, // 2048

    [Display(Name = "Zinc", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "meat, shellfish, legumes, whole grains")]
    Zinc = 1 << 12, // 4096,

    [Display(Name = "Molybdenum", GroupName = "", Description = "")]
    Molybdenum = 1 << 13, // 8192,

    [Display(Name = "Phosphorus", GroupName = "", Description = "")]
    Phosphorus = 1 << 14, // 16384,

    [Display(Name = "Sulfur", GroupName = "", Description = "")]
    Sulfur = 1 << 15, // 32768,
}