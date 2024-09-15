using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Breakfast", Order = 2)]
    Breakfast = 1 << 0, // 1

    [Display(Name = "Lunch", Order = 3)]
    Lunch = 1 << 1, // 2

    [Display(Name = "Dinner", Order = 4)]
    Dinner = 1 << 2, // 4

    [Display(Name = "Sides", Order = 5)]
    Sides = 1 << 3, // 8

    [Display(Name = "Snacks", Order = 6)]
    Snacks = 1 << 4, // 16

    [Display(Name = "Dessert", Order = 7)]
    Dessert = 1 << 5, // 32

    [Display(Name = "Prep", Order = 1)]
    Prep = 1 << 30, // 1073741824

    Debug = 1 << 31, // 2147483648

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