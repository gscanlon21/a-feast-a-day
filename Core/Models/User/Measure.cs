
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum Measure
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Pinch")]
    Pinch = 1,

    [Display(Name = "Ounce")]
    Ounce = 2,

    [Display(Name = "Teaspoon", ShortName = "Tsp.")]
    Teaspoon = 3,

    [Display(Name = "Tablespoon", ShortName = "Tbsp.")]
    Tablespoon = 4,

    [Display(Name = "Cup")]
    Cup = 5,
}
