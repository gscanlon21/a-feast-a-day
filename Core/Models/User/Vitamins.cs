using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Vitamins
{
    None = 0,

    [Display(Name = "B-1 (Thiamine)", GroupName = "Vitamin B", Description = "ham, soymilk, watermelon, acorn squash")]
    B1 = 1 << 0, // 1

    [Display(Name = "B-2", GroupName = "Vitamin B", Description = "milk, yogurt, cheese, whole and enriched grains and cereals.")]
    B2 = 1 << 1, // 2

    [Display(Name = "B-3", GroupName = "Vitamin B", Description = "meat, poultry, fish, fortified and whole grains, mushrooms, potatoes")]
    B3 = 1 << 2, // 4

    [Display(Name = "B-5", GroupName = "Vitamin B", Description = "chicken, whole grains, broccoli, avocados, mushrooms")]
    B5 = 1 << 3, // 8

    [Display(Name = "B-6", GroupName = "Vitamin B", Description = "meat, fish, poultry, legumes, tofu and other soy products, bananas")]
    B6 = 1 << 4, // 16

    [Display(Name = "B-7", GroupName = "Vitamin B", Description = "Whole grains, eggs, soybeans, fish")]
    B7 = 1 << 5, // 32

    [Display(Name = "B-9", GroupName = "Vitamin B", Description = "Fortified grains and cereals, asparagus, spinach, broccoli, legumes (black-eyed peas and chickpeas), orange juice")]
    B9 = 1 << 6, // 64

    [Display(Name = "B-12", GroupName = "Vitamin B", Description = "Meat, poultry, fish, milk, cheese, fortified soymilk and cereals")]
    B12 = 1 << 7, // 128

    [Display(Name = "Vitamin C", GroupName = "Vitamin C", Description = "Citrus fruit, potatoes, broccoli, bell peppers, spinach, strawberries, tomatoes, Brussels sprouts")]
    VitaminC = 1 << 8, // 256

    [Display(Name = "Vitamin A", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminA = 1 << 9, // 512

    [Display(Name = "Vitamin D", GroupName = "Vitamin D", Description = "Fortified milk and cereals, fatty fish")]
    VitaminD = 1 << 10, // 1024

    [Display(Name = "Vitamin E", GroupName = "Vitamin E", Description = "vegetables oils, leafy green vegetables, whole grains, nuts")]
    VitaminE = 1 << 11, // 2048

    [Display(Name = "Vitamin K", GroupName = "Vitamin K", Description = "Cabbage, eggs, milk, spinach, broccoli, kale")]
    VitaminK = 1 << 12, // 4096,

    [Display(Name = "Choline", GroupName = "Vitamin B", Description = "Eggs")]
    Choline = 1 << 13, // 8192,
}