
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum Measure
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Pinch")]
    Pinch = 1,

    [Display(Name = "Ounces")]
    Ounce = 2,

    [Display(Name = "Teaspoons", ShortName = "tsp.")]
    Teaspoon = 3,

    [Display(Name = "Tablespoons", ShortName = "Tbsp.")]
    Tablespoon = 4,

    [Display(Name = "Cups")]
    Cup = 5,

    [Display(Name = "Pounds", ShortName = "lb.")]
    Pound = 6,

    [Display(Name = "Handful")]
    Handful = 7,
}
