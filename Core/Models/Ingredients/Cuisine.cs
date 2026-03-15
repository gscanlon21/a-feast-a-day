using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Cuisine : long
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Mediterranean", Order = 1)]
    Mediterranean = 1L << 0,

    [Display(Name = "American", Order = 2)]
    American = 1L << 1,

    [Display(Name = "Mexican", Order = 3)]
    Mexican = 1L << 2,

    [Display(Name = "Italian", Order = 4)]
    Italian = 1L << 3,

    [Display(Name = "Chinese", Order = 5)]
    Chinese = 1L << 4,

    [Display(Name = "Japanese", Order = 6)]
    Japanese = 1L << 5,

    [Display(Name = "Korean", Order = 7)]
    Korean = 1L << 6,

    [Display(Name = "Thai", Order = 8)]
    Thai = 1L << 7,

    [Display(Name = "Indian", Order = 9)]
    Indian = 1L << 8,

    [Display(Name = "Middle Eastern", Order = 10)]
    MiddleEastern = 1L << 9
}