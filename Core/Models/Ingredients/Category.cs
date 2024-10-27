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

    [Display(Name = "Canned Goods", Order = 6)]
    CannedGoods = 1 << 5, // 32

    [Display(Name = "Container Goods", Order = 7)]
    ContainerGoods = Condiments | CannedGoods, // 48

    [Display(Name = "Grains", Order = 8)]
    Grains = 1 << 6, // 64

    [Display(Name = "Legumes", Order = 9)]
    Legumes = 1 << 7, // 128

    [Display(Name = "Boxed Goods", Order = 10)]
    BoxedGoods = Grains | Legumes, // 192

    [Display(Name = "Dry Goods", Order = 11)]
    DryGoods = ContainerGoods | BoxedGoods, // 240

    [Display(Name = "Chocolate", Order = 12)]
    Chocolate = 1 << 8, // 256

    [Display(Name = "Flour", Order = 13)]
    Flour = 1 << 9, // 512

    [Display(Name = "Oils", Order = 14)]
    Oils = 1 << 10, // 1024

    [Display(Name = "Baking Goods", Order = 15)]
    BakingGoods = Chocolate | Flour | Oils, // 1792,

    [Display(Name = "Spices", Order = 16)]
    Spices = 1 << 11, // 2048

    [Display(Name = "Crackers", Order = 17)]
    Crackers = 1 << 12, // 4092

    [Display(Name = "Beverages", Order = 18)]
    Beverages = 1 << 13, // 8192,

    [Display(Name = "Nuts", Order = 19)]
    Nuts = 1 << 14, // 16384,

    [Display(Name = "Snacks", Order = 20)]
    Chips = 1 << 15, // 32768,

    [Display(Name = "Snacks", Order = 21)]
    Snacks = Nuts | Chips, // 49152

    [Display(Name = "Milk", Order = 22)]
    Milk = 1 << 16, // 65536

    [Display(Name = "Cheese", Order = 23)]
    Cheese = 1 << 17, // 131072

    [Display(Name = "Eggs", Order = 24)]
    Eggs = 1 << 18, // 262144

    [Display(Name = "Dairy", Order = 25)]
    Dairy = Milk | Cheese | Eggs, // 458752,

    [Display(Name = "Frozen Fruit", Order = 26)]
    FrozenFruit = 1 << 19, // 524288

    [Display(Name = "Frozen Vegetables", Order = 27)]
    FrozenVegetables = 1 << 20, // 1048576

    [Display(Name = "Frozen Meat", Order = 28)]
    FrozenMeat = 1 << 21, // 2097152

    [Display(Name = "Frozen Goods", Order = 29)]
    FrozenGoods = FrozenFruit | FrozenVegetables | FrozenMeat, // 3670016,

    [Display(Name = "Meat", Order = 30)]
    Meat = 1 << 22, // 4194304

    [Display(Name = "Fish", Order = 31)]
    Fish = 1 << 23, // 8388608

    [Display(Name = "Pet Care Items", Order = 32)]
    PetCareItems = 1 << 24, // 16777216

    [Display(Name = "Home Care Items", Order = 33)]
    HomeCareItems = 1 << 25, // 33554432

    [Display(Name = "Personal Care Items", Order = 34)]
    PersonalCareItems = 1 << 26, // 67108864
}
