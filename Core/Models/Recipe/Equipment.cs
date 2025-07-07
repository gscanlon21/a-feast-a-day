using System.ComponentModel.DataAnnotations;

namespace Core.Models.Recipe;

[Flags]
public enum Equipment
{
    None = 0,

    [Display(Name = "Microwave", Order = 1)]
    Microwave = 1 << 0, // 1

    [Display(Name = "Oven", Order = 2)]
    Oven = 1 << 1, // 2

    [Display(Name = "Stove", Order = 3)]
    Stove = 1 << 2, // 4 

    [Display(Name = "Grill", Order = 4)]
    Grill = 1 << 3, // 8

    [Display(Name = "Broiler", Order = 5)]
    Broiler = 1 << 4, // 16

    [Display(Name = "Toaster", Order = 6)]
    Toaster = 1 << 5, // 32

    [Display(Name = "Toaster Oven", Order = 7)]
    ToasterOven = 1 << 6, // 64

    [Display(Name = "Blender", Order = 8)]
    Blender = 1 << 7, // 128

    [Display(Name = "Food Processor", Order = 9)]
    FoodProcessor = 1 << 8, // 256

    [Display(Name = "Immersion Blender", Order = 10)]
    ImmersionBlender = 1 << 9, // 512

    [Display(Name = "Slow Cooker", Order = 11)]
    SlowCooker = 1 << 10, // 1024

    [Display(Name = "Mortar & Pestle", Order = 12)]
    MortarPestle = 1 << 11, // 2048

    [Display(Name = "Air Fryer", Order = 13)]
    AirFryer = 1 << 12, // 4096

    [Display(Name = "Bread Maker", Order = 14)]
    BreadMaker = 1 << 13, // 8192

    [Display(Name = "Dehydrator", Order = 15)]
    Dehydrator = 1 << 14, // 16384

    [Display(Name = "Potato Masher", Order = 16)]
    PotatoMasher = 1 << 15, // 32768

    All = Microwave | Oven | Stove | Grill | Broiler | Toaster | ToasterOven | Blender | FoodProcessor | ImmersionBlender
        | SlowCooker | MortarPestle | AirFryer | BreadMaker | Dehydrator | PotatoMasher
}
