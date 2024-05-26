using Core.Models.Exercise;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Newsletter;

[Flags]
public enum Section
{
    [Display(Name = "None")]
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
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        not Section.None when Section.Breakfast.HasFlag(section) => ExerciseTheme.Warmup,
        not Section.None when Section.Lunch.HasFlag(section) => ExerciseTheme.Cooldown,
        not Section.None when Section.Dinner.HasFlag(section) => ExerciseTheme.Main,
        not Section.None when Section.Dessert.HasFlag(section) => ExerciseTheme.Other,
        _ => ExerciseTheme.None,
    };
}