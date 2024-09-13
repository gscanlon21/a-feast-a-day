using Core.Code.Extensions;
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

    [Display(Name = "Blender", GroupName = "BlenderFoodProcessor")]
    Blender = 1 << 4 | 1 << 17, // 16 + 131072 = 131088

    [Display(Name = "Slow Cooker")]
    SlowCooker = 1 << 5, // 32

    [Display(Name = "Toaster Oven")]
    ToasterOven = 1 << 6, // 64

    [Display(Name = "Bread Maker")]
    BreadMaker = 1 << 7, // 128

    [Display(Name = "Air Fryer")]
    AirFryer = 1 << 8, // 256

    [Display(Name = "Grill", GroupName = "GrillBroiler")]
    Grill = 1 << 9 | 1 << 16, // 512 + 65536 = 66048

    [Display(Name = "Broiler", GroupName = "GrillBroiler")]
    Broiler = 1 << 10 | 1 << 14, // 1024 + 16384 = 17408

    [Display(Name = "Food Processor", GroupName = "BlenderFoodProcessor")]
    FoodProcessor = 1 << 11 | 1 << 15, // 2048 + 32768 = 34816

    [Display(Name = "Blender | Food Processor", GroupName = "BlenderFoodProcessor")]
    BlenderFoodProcessor = 1 << 12 | 1 << 17 | 1 << 15, // 4096 + 131072 + 32768 = 167936

    [Display(Name = "Grill | Broiler", GroupName = "GrillBroiler")]
    GrillBroiler = 1 << 13 | 1 << 16 | 1 << 14, // 8192 + 65536 + 16384 = 90112
}

public static class EquipmentExtensions
{
    public static Equipment WithOptionalEquipment(this Equipment equipment)
    {
        if (equipment == Equipment.None)
        {
            return equipment;
        }

        return EnumExtensions.GetMultiValues32<Equipment>()
            .Where(e => e.HasAnyFlag32(equipment))
            .Aggregate(equipment, (curr, n) => curr | n);
    }
}