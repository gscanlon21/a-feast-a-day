using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum SubCategory : long
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Fruit", Order = 1)]
    Fruit = 1L << 0,

    [Display(Name = "Vegetable", Order = 2)]
    Vegetable = 1L << 1,

    [Display(Name = "Herb", Order = 3)]
    Herb = 1L << 2,

    [Display(Name = "Grain", Order = 4)]
    Grain = 1L << 3,

    [Display(Name = "Pasta", Order = 5)]
    Pasta = 1L << 4,

    [Display(Name = "Legume", Order = 6)]
    Legume = 1L << 5,

    [Display(Name = "Meat", Order = 7)]
    Meat = 1L << 6,

    [Display(Name = "Seafood", Order = 8)]
    Seafood = 1L << 7,

    [Display(Name = "Dairy", Order = 9)]
    Dairy = 1L << 8,

    [Display(Name = "Egg", Order = 10)]
    Egg = 1L << 9,

    [Display(Name = "Oil", Order = 11)]
    Oil = 1L << 10,

    [Display(Name = "Spice", Order = 12)]
    Spice = 1L << 11,

    [Display(Name = "Condiment", Order = 13)]
    Condiment = 1L << 12,

    [Display(Name = "Sauce", Order = 14)]
    Sauce = 1L << 13,

    [Display(Name = "Flour", Order = 15)]
    Flour = 1L << 14,

    [Display(Name = "Sweetener", Order = 16)]
    Sweetener = 1L << 15,

    [Display(Name = "Chocolate", Order = 17)]
    Chocolate = 1L << 16,

    [Display(Name = "Nut", Order = 18)]
    Nut = 1L << 17,

    [Display(Name = "Seed", Order = 19)]
    Seed = 1L << 18,

    [Display(Name = "Beverage", Order = 20)]
    Beverage = 1L << 19
}