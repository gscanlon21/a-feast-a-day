using Core.Code.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Recipe;

[Flags]
public enum Equipment : long
{
    None = 0,

    [Display(Name = "Microwave", Order = 1)]
    Microwave = 1 << 0 | 1 << 18, // 1 + 262144 = 262145

    [Display(Name = "Oven", Order = 2)]
    Oven = 1 << 1, // 2

    [Display(Name = "Stove", Order = 3)]
    Stove = 1 << 2 | 1 << 19, // 4 + 524288 = 524292

    [Display(Name = "Toaster", Order = 4)]
    Toaster = 1 << 3, // 8

    [Display(Name = "Blender", Order = 5)]
    Blender = 1 << 4 | 1 << 17, // 16 + 131072 = 131088

    [Display(Name = "Slow Cooker", Order = 6)]
    SlowCooker = 1 << 5, // 32

    [Display(Name = "Toaster Oven", Order = 7)]
    ToasterOven = 1 << 6, // 64

    [Display(Name = "Bread Maker", Order = 8)]
    BreadMaker = 1 << 7, // 128

    [Display(Name = "Air Fryer", Order = 9)]
    AirFryer = 1 << 8, // 256

    [Display(Name = "Grill", Order = 10)]
    Grill = 1 << 9 | 1 << 16, // 512 + 65536 = 66048

    [Display(Name = "Broiler", Order = 11)]
    Broiler = 1 << 10 | 1 << 14, // 1024 + 16384 = 17408

    [Display(Name = "Food Processor", Order = 12)]
    FoodProcessor = 1 << 11 | 1 << 15, // 2048 + 32768 = 34816

    [Display(Name = "Blender | Food Processor", Order = 13)]
    BlenderFoodProcessor = 1 << 12 | 1 << 17 | 1 << 15, // 4096 + 131072 + 32768 = 167936

    [Display(Name = "Grill | Broiler", Order = 14)]
    GrillBroiler = 1 << 13 | 1 << 16 | 1 << 14, // 8192 + 65536 + 16384 = 90112

    [Display(Name = "Microwave | Stove", Order = 15)]
    MicrowaveStove = 1 << 20 | 1 << 18 | 1 << 19, // 1048576 + 262144 + 524288 = 1835008
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
            .Where(e => equipment.HasAnyFlag32(e))
            .Aggregate(equipment, (c, n) => c | n);
    }
}