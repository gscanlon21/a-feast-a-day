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
    Breakfasts = Breakfast, // 7

    [Display(Name = "Lunch")]
    Lunch = 1 << 3, // 8
    [Display(Name = "Lunch")]
    Lunches = Lunch, // 56

    [Display(Name = "Dinner")]
    Dinner = 1 << 6, // 64
    [Display(Name = "Sides")]
    Sides = 1 << 7, // 128
    [Display(Name = "Sports")]
    Dinners = Dinner | Sides, // 192

    [Display(Name = "Dessert")]
    Dessert = 1 << 8, // 256
    [Display(Name = "Main")]
    Desserts = Dessert, // 1792

    Debug = 1 << 15, // 32768
}

public static class SectionExtensions
{
    public static ExerciseTheme AsTheme(this Section section) => section switch
    {
        not Section.None when Section.Breakfasts.HasFlag(section) => ExerciseTheme.Warmup,
        not Section.None when Section.Lunches.HasFlag(section) => ExerciseTheme.Cooldown,
        not Section.None when Section.Dinners.HasFlag(section) => ExerciseTheme.Main,
        not Section.None when Section.Desserts.HasFlag(section) => ExerciseTheme.Other,
        _ => ExerciseTheme.None,
    };
}