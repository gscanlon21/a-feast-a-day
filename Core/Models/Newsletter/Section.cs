using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "Ingredient Recipes")]
    None = 0,

    [Display(Name = "Breakfast")]
    Breakfast = 1 << 0, // 1

    [Display(Name = "Lunch")]
    Lunch = 1 << 1, // 2

    [Display(Name = "Dinner")]
    Dinner = 1 << 2, // 4

    [Display(Name = "Sides")]
    Sides = 1 << 3, // 8

    [Display(Name = "Snacks")]
    Snacks = 1 << 4, // 16

    [Display(Name = "Dessert")]
    Dessert = 1 << 5, // 32

    Debug = 1 << 15, // 32768

    All = Breakfast | Lunch | Dinner | Sides | Snacks | Dessert
}

public static class SectionExtensions
{
    public static RecipeTheme AsTheme(this Section section) => section switch
    {
        not Section.None when Section.Breakfast.HasFlag(section) => RecipeTheme.Warmup,
        not Section.None when Section.Lunch.HasFlag(section) => RecipeTheme.Main,
        not Section.None when Section.Dinner.HasFlag(section) => RecipeTheme.Main,
        not Section.None when Section.Sides.HasFlag(section) => RecipeTheme.Cooldown,
        not Section.None when Section.Dessert.HasFlag(section) => RecipeTheme.Other,
        not Section.None when Section.Snacks.HasFlag(section) => RecipeTheme.Other,
        _ => RecipeTheme.None,
    };
}