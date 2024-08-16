using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "Prep")]
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
        Section.Breakfast => RecipeTheme.Warmup,
        Section.Lunch or Section.Dinner => RecipeTheme.Main,
        Section.Sides => RecipeTheme.Cooldown,
        Section.Dessert => RecipeTheme.Other,
        Section.Snacks => RecipeTheme.Extra,
        _ => RecipeTheme.None,
    };
}