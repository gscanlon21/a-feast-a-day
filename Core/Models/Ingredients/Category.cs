using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Category : long
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Produce", Order = 1)]
    Produce = 1L << 0,

    [Display(Name = "Bakery", Order = 2)]
    Bakery = 1L << 1,

    [Display(Name = "Deli", Order = 3)]
    Deli = 1L << 2,

    [Display(Name = "Pantry", Order = 4)]
    Pantry = 1L << 3,

    [Display(Name = "Baking", Order = 5)]
    Baking = 1L << 4,

    [Display(Name = "Snacks", Order = 6)]
    Snacks = 1L << 5,

    [Display(Name = "Beverages", Order = 7)]
    Beverages = 1L << 6,

    [Display(Name = "Dairy", Order = 8)]
    Dairy = 1L << 7,

    [Display(Name = "Meat", Order = 9)]
    Meat = 1L << 8,

    [Display(Name = "Seafood", Order = 10)]
    Seafood = 1L << 9,

    [Display(Name = "Frozen", Order = 11)]
    Frozen = 1L << 10,

    [Display(Name = "International", Order = 12)]
    International = 1L << 11,

    [Display(Name = "Household", Order = 13)]
    Household = 1L << 12
}