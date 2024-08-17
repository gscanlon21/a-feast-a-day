using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Prep")]
    Prep = 1 << 0, // 1

    [Display(Name = "Breakfast")]
    Breakfast = 1 << 1, // 2

    [Display(Name = "Lunch")]
    Lunch = 1 << 2, // 4

    [Display(Name = "Dinner")]
    Dinner = 1 << 3, // 8

    [Display(Name = "Sides")]
    Sides = 1 << 4, // 16

    [Display(Name = "Snacks")]
    Snacks = 1 << 5, // 32

    [Display(Name = "Dessert")]
    Dessert = 1 << 6, // 64

    Debug = 1 << 15, // 32768

    All = Breakfast | Lunch | Dinner | Sides | Snacks | Dessert | Prep
}

public static class SectionExtensions
{
    public static readonly List<Section> MainSections = [Section.Breakfast, Section.Lunch, Section.Dinner, Section.Snacks, Section.Dessert];

    public static RecipeTheme AsTheme(this Section section) => section switch
    {
        Section.Breakfast => RecipeTheme.Warmup,
        Section.Lunch or Section.Dinner => RecipeTheme.Main,
        Section.Sides => RecipeTheme.Cooldown,
        Section.Snacks => RecipeTheme.Extra,
        Section.Dessert => RecipeTheme.Other,
        _ => RecipeTheme.None,
    };
}