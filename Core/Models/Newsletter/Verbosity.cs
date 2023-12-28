using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

/// <summary>
/// The detail shown in the newsletter.
/// </summary>
[Flags]
public enum Verbosity
{
    None = 0,

    /// <summary>
    /// Show instructions to the user.
    /// </summary>
    [Display(Name = "Images")]
    Images = 1 << 0, // 1

    /// <summary>
    /// Show exercises images to the user.
    /// </summary>
    [Display(Name = "Prep Time")]
    PrepTime = 1 << 1, // 2

    /// <summary>
    /// Show the bottom progression bar to the user, 
    /// allowing them to progress and regress their exercise progression.
    /// </summary>
    [Display(Name = "Cook Time")]
    CookTime = 1 << 2, // 4

    /// <summary>
    /// Show which muscles are stretched by the exercise to the user.
    /// </summary>
    [Display(Name = "Total Time")]
    TotalTime = 1 << 3, // 8

    /// <summary>
    /// Show which muscles are stretched by the exercise to the user.
    /// </summary>
    [Display(Name = "Servings")]
    Servings = 1 << 4, // 16

    /// <summary>
    /// Show which muscles are stretched by the exercise to the user.
    /// </summary>
    [Display(Name = "Notes")]
    Notes = 1 << 5, // 32

    /// <summary>
    /// Show common ingredients (salt, pepper...) in the shopping list.
    /// </summary>
    [Display(Name = "Common Ingredients")]
    CommonIngredients = 1 << 6, // 64

    /// <summary>
    /// This is not user-facing. 
    /// It should not have a Display attribute. 
    /// </summary>
    Debug = Images | CookTime | PrepTime | Servings | Notes | CommonIngredients
        | 1 << 30 // 1073741824
}
