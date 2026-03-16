using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

/// <summary>
/// The detail shown in the newsletter.
/// </summary>
[Flags]
public enum Verbosity
{
    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute.
    /// </summary>
    None = 0,

    /// <summary>
    /// Show recipe images to the user.
    /// </summary>
    [Display(Name = "Images")]
    Images = 1 << 0, // 1

    /// <summary>
    /// Show recipe prep time to the user.
    /// </summary>
    [Display(Name = "Prep Time")]
    PrepTime = 1 << 1, // 2

    /// <summary>
    /// Show recipe cook time to the user.
    /// </summary>
    [Display(Name = "Cook Time")]
    CookTime = 1 << 2, // 4

    /// <summary>
    /// Show recipe total time to the user.
    /// </summary>
    [Display(Name = "Total Time")]
    TotalTime = 1 << 3, // 8

    /// <summary>
    /// Show recipe servings to the user.
    /// </summary>
    [Display(Name = "Servings")]
    Servings = 1 << 4, // 16

    /// <summary>
    /// Show recipe notes to the user.
    /// </summary>
    [Display(Name = "Notes")]
    Notes = 1 << 5, // 32

    /// <summary>
    /// Show common ingredients (salt, pepper...) in the shopping list.
    /// </summary>
    [Display(Name = "Common Ingredients")]
    CommonIngredients = 1 << 6, // 64

    /// <summary>
    /// Show recipe allergens to the user.
    /// </summary>
    [Display(Name = "Allergens")]
    Allergens = 1 << 7, // 128

    /// <summary>
    /// Show recipe's equipment.
    /// </summary>
    [Display(Name = "Equipment")]
    Equipment = 1 << 8, // 256

    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute.
    /// </summary>
    All = Images | PrepTime | CookTime | TotalTime | Servings | Notes | CommonIngredients | Allergens | Equipment
        | 1 << 29, // 536870912 

    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Debug = All | 1 << 30 // 1073741824
}
