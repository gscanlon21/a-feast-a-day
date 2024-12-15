using Core.Code.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Recipe;

[Flags]
public enum Equipment : long
{
    None = 0,

    [Display(Name = "Microwave", Order = 1)]
    Microwave = 1 << 0 | 1L << 20, // 1 + 1048576

    [Display(Name = "Oven", Order = 2)]
    Oven = 1 << 1 | 1L << 21, // 2 + 2097152

    [Display(Name = "Stove", Order = 3)]
    Stove = 1 << 2 | 1L << 22, // 4 + 4194304 

    [Display(Name = "Grill", Order = 4)]
    Grill = 1 << 3 | 1L << 23, // 8 + 8388608

    [Display(Name = "Broiler", Order = 5)]
    Broiler = 1 << 4 | 1L << 24, // 16 + 16777216

    [Display(Name = "Toaster", Order = 6)]
    Toaster = 1 << 5 | 1L << 25, // 32 + 33554432

    [Display(Name = "Toaster Oven", Order = 7)]
    ToasterOven = 1 << 6 | 1L << 26, // 64 + 67108864

    [Display(Name = "Blender", Order = 8)]
    Blender = 1 << 7 | 1L << 27, // 128 + 134217728

    [Display(Name = "Food Processor", Order = 9)]
    FoodProcessor = 1 << 8 | 1L << 28, // 256 + 268435456

    [Display(Name = "Immersion Blender", Order = 10)]
    ImmersionBlender = 1 << 9 | 1L << 29, // 512 + 536870912

    [Display(Name = "Slow Cooker", Order = 11)]
    SlowCooker = 1 << 10 | 1L << 30, // 1024 + 1073741824

    [Display(Name = "Mortar & Pestle", Order = 12)]
    MortarPestle = 1 << 11 | 1L << 31, // 2048 + 2147483648

    [Display(Name = "Air Fryer", Order = 13)]
    AirFryer = 1 << 12 | 1L << 32, // 4096 + 4294967296

    [Display(Name = "Bread Maker", Order = 14)]
    BreadMaker = 1 << 13 | 1L << 33, // 8192 + 8589934592

    [Display(Name = "Dehydrator", Order = 15)]
    Dehydrator = 1 << 14 | 1L << 34, // 16384 + 17179869184

    [Display(Name = "Potato Masher", Order = 16)]
    PotatoMasher = 1 << 15 | 1L << 35, // 32768 + 34359738368


    [Display(Name = "Grill | Broiler", Order = 41)]
    GrillBroiler = 1L << 40 | 1L << 23 | 1L << 24,

    [Display(Name = "Microwave | Stove", Order = 42)]
    MicrowaveStove = 1L << 41 | 1L << 20 | 1L << 22,


    [Display(Name = "Immersion Blender | Potato Masher", Order = 57)]
    ImmersionBlenderPotatoMasher = 1L << 56 | 1L << 29 | 1L << 35,

    [Display(Name = "Food Processor | Blender", Order = 58)]
    FoodProcessorBlender = 1L << 57 | 1L << 28 | 1L << 27,

    [Display(Name = "Food Processor | Mortar & Pestle", Order = 59)]
    FoodProcessorMortarPestle = 1L << 58 | 1L << 28 | 1L << 31,

    [Display(Name = "Food Processor | Potato Masher", Order = 60)]
    FoodProcessorPotatoMasher = 1L << 59 | 1L << 28 | 1L << 35,

    [Display(Name = "Food Processor | Mortar & Pestle | Blender", Order = 61)]
    FoodProcessorMortarPestleBlender = 1L << 60 | 1L << 28 | 1L << 31 | 1L << 27,

    [Display(Name = "Food Processor | Immersion Blender | Blender", Order = 62)]
    FoodProcessorImmersionBlenderBlender = 1L << 61 | 1L << 29 | 1L << 28 | 1L << 27,

    [Display(Name = "Food Processor | Potato Masher | Mortar & Pestle", Order = 63)]
    FoodProcessorPotatoMasherMortarPestle = 1L << 62 | 1L << 28 | 1L << 35 | 1L << 31,

    [Display(Name = "Food Processor | Potato Masher | Mortar & Pestle | Blender", Order = 64)]
    FoodProcessorPotatoMasherMortarPestleBlender = 1L << 63 | 1L << 28 | 1L << 35 | 1L << 31 | 1L << 27,
}

public static class EquipmentExtensions
{
    public static Equipment WithOptionalEquipment(this Equipment equipment)
    {
        if (equipment == Equipment.None)
        {
            return equipment;
        }

        return EnumExtensions.GetMultiValues<Equipment>()
            .Where(e => equipment.HasAnyFlag(e))
            .Aggregate(equipment, (c, n) => c | n);
    }
}