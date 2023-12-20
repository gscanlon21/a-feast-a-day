using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

/// <summary>
/// Controls access to user features.
/// </summary>
[Flags]
public enum RecipeType
{
    None = 0,

    [Display(Name = "Breakfast")]
    Breakfast = 1 << 0, // 1

    [Display(Name = "Lunch")]
    Lunch = 1 << 1, // 2

    [Display(Name = "Dinner")]
    Dinner = 1 << 2, // 4

    [Display(Name = "Side")]
    Side = 1 << 3, // 8

    /// <summary>
    /// Pre-beta features.
    /// </summary>
    [Display(Name = "Dessert")]
    Dessert = 1 << 4, // 16
}
