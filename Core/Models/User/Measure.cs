
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

    [Display(Name = "Head")]
    Head = 8,

    [Display(Name = "Clove")]
    Clove = 9,

    [Display(Name = "Can")]
    Can = 10,

    [Display(Name = "Bottle")]
    Bottle = 11,

    [Display(Name = "Package")]
    Package = 12,

    [Display(Name = "Grams", ShortName = "g")]
    Grams = 13,

    [Display(Name = "Splash")]
    Splash = 14,

    [Display(Name = "Jar")]
    Jar = 15,

    [Display(Name = "Slices")]
    Slice = 16,

    [Display(Name = "Milligrams", ShortName = "mg")]
    Milligrams = 17,

    [Display(Name = "Micrograms", ShortName = "mcg")]
    Micrograms = 18,
}
