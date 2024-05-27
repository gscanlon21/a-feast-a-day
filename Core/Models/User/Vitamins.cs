using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Vitamins
{
    None = 0,

    [Display(Name = "Vitamin A (Retinoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminARetinoids = 1 << 0, // 1

    [Display(Name = "Vitamin A (Carotenoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminACartenoids = 1 << 1, // 2

    [Display(ShortName = "Vitamin A", Name = "Vitamin A (Retinoids and Carotenoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminA = VitaminARetinoids | VitaminACartenoids, // 3

    [Display(ShortName = "B1", Name = "B1 (Thiamine)", GroupName = "Vitamin B", Description = "ham, soymilk, watermelon, acorn squash")]
    B1 = 1 << 2, // 4

    [Display(ShortName = "B2", Name = "B2 (Riboflavin)", GroupName = "Vitamin B", Description = "milk, yogurt, cheese, whole and enriched grains and cereals.")]
    B2 = 1 << 3, // 8

    [Display(ShortName = "B3", Name = "B3 (Niacin)", GroupName = "Vitamin B", Description = "meat, poultry, fish, fortified and whole grains, mushrooms, potatoes")]
    B3 = 1 << 4, // 16

    [Display(ShortName = "B5", Name = "B5 (Pantothenic Acid)", GroupName = "Vitamin B", Description = "chicken, whole grains, broccoli, avocados, mushrooms")]
    B5 = 1 << 5, // 32

    [Display(ShortName = "B6", Name = "B6 (Pyridoxine)", GroupName = "Vitamin B", Description = "meat, fish, poultry, legumes, tofu and other soy products, bananas")]
    B6 = 1 << 6, // 64

    [Display(ShortName = "B7", Name = "B7 (Biotin)", GroupName = "Vitamin B", Description = "Whole grains, eggs, soybeans, fish")]
    B7 = 1 << 7, // 128

    [Display(ShortName = "B9", Name = "B9 (Folic Acid)", GroupName = "Vitamin B", Description = "Fortified grains and cereals, asparagus, spinach, broccoli, legumes (black-eyed peas and chickpeas), orange juice")]
    B9 = 1 << 8, // 256

    [Display(ShortName = "B12", Name = "B12 (Cobalamin)", GroupName = "Vitamin B", Description = "Meat, poultry, fish, milk, cheese, fortified soymilk and cereals")]
    B12 = 1 << 9, // 512

    [Display(ShortName = "Vitamin C", Name = "Vitamin C (Ascorbic Acid)", GroupName = "Vitamin C", Description = "Citrus fruit, potatoes, broccoli, bell peppers, spinach, strawberries, tomatoes, Brussels sprouts")]
    VitaminC = 1 << 10, // 1024

    [Display(ShortName = "Vitamin D", Name = "Vitamin D (Calciferol)", GroupName = "Vitamin D", Description = "Fortified milk and cereals, fatty fish")]
    VitaminD = 1 << 11, // 2048

    [Display(ShortName = "Vitamin E", Name = "Vitamin E (Alpha-Tocopherol)", GroupName = "Vitamin E", Description = "vegetables oils, leafy green vegetables, whole grains, nuts")]
    VitaminE = 1 << 12, // 4096

    [Display(ShortName = "Vitamin K", Name = "Vitamin K (Phylloquinone, Menadione)", GroupName = "Vitamin K", Description = "Cabbage, eggs, milk, spinach, broccoli, kale")]
    VitaminK = 1 << 13, // 8192,

    [Display(Name = "Choline", GroupName = "Vitamin B", Description = "Eggs")]
    Choline = 1 << 14, // 16384,
}