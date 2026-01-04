using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

/// <summary>
/// How is an ingredient cooked?
/// </summary>
public enum CookingMethod
{
    [Display(Name = "")]
    None = 0,

    /// <summary>
    /// Not getting as granular to differentiate between oven- and pan- fried cooking.
    /// There aren't many ingredients that need to differentiate between the two types.
    /// And they yield similar nutrient profiles and the user may not follow the recipe.
    /// Let's see if we can use partial or aggregate ingredients for accurate nutrients.
    /// </summary>
    [Display(Name = "Dry Heat", Order = 1)]
    DryHeat = 1,

    [Display(Name = "Moist Heat", Order = 2)]
    MoistHeat = 2,

    [Display(Name = "Combination", Order = 3)]
    Combination = 3,
}