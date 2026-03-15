using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Cuisine
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Mediterranean", Order = 1)]
    Mediterranean = 1,

    [Display(Name = "American", Order = 2)]
    American = 2,

    [Display(Name = "Mexican", Order = 3)]
    Mexican = 3,

    [Display(Name = "Italian", Order = 4)]
    Italian = 4,

    [Display(Name = "Chinese", Order = 5)]
    Chinese = 5,

    [Display(Name = "Japanese", Order = 6)]
    Japanese = 6,

    [Display(Name = "Korean", Order = 7)]
    Korean = 7,

    [Display(Name = "Thai", Order = 8)]
    Thai = 8,

    [Display(Name = "Indian", Order = 9)]
    Indian = 9,

    [Display(Name = "Middle Eastern", Order = 10)]
    MiddleEastern = 10,
}