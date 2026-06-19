using ADay.Core.Models.Theme;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
    None = 0,

    [Display(Name = "Prep", Order = 1)]
    Prep = 1 << 0, // 1

    [Display(Name = "Breakfast", Order = 2)]
    Breakfast = 1 << 1, // 2

    [Display(Name = "Lunch", Order = 3)]
    Lunch = 1 << 2, // 4

    [Display(Name = "Dinner", Order = 4)]
    Dinner = 1 << 3, // 8

    [Display(Name = "Sides", Order = 5)]
    Sides = 1 << 4, // 16

    [Display(Name = "Snacks", Order = 6)]
    Snacks = 1 << 5, // 32

    [Display(Name = "Dessert", Order = 7)]
    Dessert = 1 << 6, // 64

    [Display(Name = "Drinks", Order = 8)]
    Drinks = 1 << 7, // 128

    Debug = 1 << 30, // 1073741824

    All = Prep | Breakfast | Lunch | Dinner | Sides | Snacks | Dessert | Drinks
}

public static class SectionExtensions
{
    public static readonly List<Section> RecipeSections = [Section.Prep, Section.Breakfast, Section.Lunch, Section.Dinner, Section.Sides, Section.Snacks, Section.Dessert, Section.Drinks];
    public static readonly List<Section> MainSections = [Section.Breakfast, Section.Lunch, Section.Dinner, Section.Sides, Section.Snacks, Section.Dessert, Section.Drinks];

    public static Theme AsTheme(this Section section) => section switch
    {
        Section.Breakfast => Theme.Red,
        Section.Lunch => Theme.Violet,
        Section.Dinner => Theme.Teal,
        Section.Sides => Theme.Blue,
        Section.Snacks => Theme.Orange,
        Section.Dessert => Theme.Slate,
        Section.Drinks => Theme.Green,
        _ => Theme.None,
    };
}