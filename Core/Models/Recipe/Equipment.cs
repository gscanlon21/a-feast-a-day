using System.ComponentModel.DataAnnotations;

namespace Core.Models.Recipe;

[Flags]
public enum Equipment
{
    None = 0,

    [Display(Name = "Crockpot")]
    Crockpot = 1 << 0, // 1
}
