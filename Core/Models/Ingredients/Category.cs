using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Category
{
    None = 0,

    [Display(Name = "Produce", Order = 1)]
    Produce = 1 << 0, // 1

    [Display(Name = "Baked Goods", Order = 2)]
    BakedGoods = 1 << 1, // 2

    [Display(Name = "Dips", Order = 3)]
    Dips = 1 << 2, // 4

    [Display(Name = "Artisan", Order = 4)]
    Artisan = 1 << 3, // 8

    [Display(Name = "Condiments", Order = 5)]
    Condiments = 1 << 4, // 16

    [Display(Name = "Bread", Order = 6)]
    Bread = 1 << 5, // 32

    [Display(Name = "Canned Goods", Order = 7)]
    CannedGoods = 1 << 6, // 64

    [Display(Name = "Jarred Goods", Order = 8)]
    JarredGoods = 1 << 7, // 128

    [Display(Name = "Container Goods", Order = 9)]
    ContainerGoods = Condiments | CannedGoods | JarredGoods,

    [Display(Name = "Grains", Order = 10)]
    Grains = 1 << 8, // 256

    [Display(Name = "Legumes", Order = 11)]
    Legumes = 1 << 9, // 512

    [Display(Name = "Noodles", Order = 12)]
    Noodles = 1 << 10, // 1024

    [Display(Name = "Boxed Goods", Order = 13)]
    BoxedGoods = Grains | Legumes | Noodles,

    [Display(Name = "Rice", Order = 14)]
    Rice = 1 << 11, // 2048

    [Display(Name = "Foreign", Order = 15)]
    Foreign = 1 << 12, // 4092

    [Display(Name = "Dry Goods", Order = 16)]
    DryGoods = ContainerGoods | BoxedGoods | Rice | Foreign,

    [Display(Name = "Chocolate", Order = 17)]
    Chocolate = 1 << 13, // 8192,

    [Display(Name = "Flour", Order = 18)]
    Flour = 1 << 14, // 16384,

    [Display(Name = "Oils", Order = 19)]
    Oils = 1 << 15, // 32768,

    [Display(Name = "Baking Goods", Order = 20)]
    BakingGoods = Chocolate | Flour | Oils,

    [Display(Name = "Spices", Order = 21)]
    Spices = 1 << 16, // 65536

    [Display(Name = "Crackers", Order = 22)]
    Crackers = 1 << 17, // 131072

    [Display(Name = "Beverages", Order = 23)]
    Beverages = 1 << 18, // 262144

    [Display(Name = "Nuts", Order = 24)]
    Nuts = 1 << 19, // 524288

    [Display(Name = "Chips", Order = 25)]
    Chips = 1 << 20, // 1048576

    [Display(Name = "Snacks", Order = 26)]
    Snacks = Nuts | Chips,

    [Display(Name = "Milk", Order = 27)]
    Milk = 1 << 21, // 2097152

    [Display(Name = "Cheese", Order = 28)]
    Cheese = 1 << 22, // 4194304

    [Display(Name = "Eggs", Order = 29)]
    Eggs = 1 << 23, // 8388608

    [Display(Name = "Dairy", Order = 30)]
    Dairy = Milk | Cheese | Eggs,

    [Display(Name = "Frozen Fruit", Order = 31)]
    FrozenFruit = 1 << 24, // 16777216

    [Display(Name = "Frozen Vegetables", Order = 32)]
    FrozenVegetables = 1 << 25, // 33554432

    [Display(Name = "Frozen Meat", Order = 33)]
    FrozenMeat = 1 << 26, // 67108864

    [Display(Name = "Frozen Goods", Order = 34)]
    FrozenGoods = FrozenFruit | FrozenVegetables | FrozenMeat,

    [Display(Name = "Meat", Order = 35)]
    Meat = 1 << 27, // 134217728

    [Display(Name = "Fish", Order = 36)]
    Fish = 1 << 28, // 268435456

    [Display(Name = "Pet Care Items", Order = 37)]
    PetCareItems = 1 << 29, // 536870912

    [Display(Name = "Home Care Items", Order = 38)]
    HomeCareItems = 1 << 30, // 1073741824

    [Display(Name = "Personal Care Items", Order = 39)]
    PersonalCareItems = 1 << 31, // 2147483648
}
