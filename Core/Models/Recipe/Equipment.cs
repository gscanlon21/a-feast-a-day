using System.ComponentModel.DataAnnotations;

namespace Core.Models.Recipe;

[Flags]
public enum Equipment
{
    None = 0,

    [Display(Name = "Microwave")]
    Microwave = 1 << 0, // 1

    [Display(Name = "Oven")]
    Oven = 1 << 1, // 2

    [Display(Name = "Stove")]
    Stove = 1 << 2, // 4

    [Display(Name = "Toaster")]
    Toaster = 1 << 3, // 8

    [Display(Name = "Blender")]
    Blender = 1 << 4, // 16

    [Display(Name = "Slow Cooker")]
    SlowCooker = 1 << 5, // 32

    [Display(Name = "Toaster Oven")]
    ToasterOven = 1 << 6, // 64

    [Display(Name = "Bread Maker")]
    BreadMaker = 1 << 7, // 128

    [Display(Name = "Air Fryer")]
    AirFryer = 1 << 8, // 256
}
