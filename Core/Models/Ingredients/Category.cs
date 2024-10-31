using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Category
{
    None = 0,

    [Display(Name = "Fruits", Order = 1)]
    Fruits = 1 << 0, // 1

    [Display(Name = "Vegetables", Order = 2)]
    Vegetables = 1 << 1, // 2

    [Display(Name = "Produce", Order = 3)]
    Produce = Fruits | Vegetables,

    [Display(Name = "Baked Goods", Order = 4)]
    BakedGoods = 1 << 2, // 4

    [Display(Name = "Dips", Order = 5)]
    Dips = 1 << 3, // 8

    [Display(Name = "Artisan", Order = 6)]
    Artisan = 1 << 4, // 16

    [Display(Name = "Condiments", Order = 7)]
    Condiments = 1 << 5, // 32

    [Display(Name = "Bread", Order = 8)]
    Bread = 1 << 6, // 64

    [Display(Name = "Spreads", Order = 9)]
    Spreads = 1 << 7, // 128

    [Display(Name = "Sauces", Order = 10)]
    Sauces = 1 << 8, // 256

    [Display(Name = "Canned Goods", Order = 11)]
    CannedGoods = 1 << 9, // 512

    [Display(Name = "Container Goods", Order = 12)]
    ContainerGoods = Condiments | CannedGoods | Spreads | Sauces,

    [Display(Name = "Grains", Order = 13)]
    Grains = 1 << 10, // 1024 

    [Display(Name = "Legumes", Order = 14)]
    Legumes = 1 << 11, // 2048

    [Display(Name = "Noodles", Order = 15)]
    Noodles = 1 << 12, // 4092

    [Display(Name = "Boxed Goods", Order = 16)]
    BoxedGoods = Grains | Legumes | Noodles,

    [Display(Name = "Foreign", Order = 17)]
    Foreign = 1 << 13, // 8192,

    [Display(Name = "Dry Goods", Order = 18)]
    DryGoods = ContainerGoods | BoxedGoods | Foreign,

    [Display(Name = "Chocolate", Order = 19)]
    Chocolate = 1 << 14, // 16384,

    [Display(Name = "Flour", Order = 20)]
    Flour = 1 << 15, // 32768,

    [Display(Name = "Oils", Order = 21)]
    Oils = 1 << 16, // 65536

    [Display(Name = "Baking Goods", Order = 22)]
    BakingGoods = Chocolate | Flour | Oils,

    [Display(Name = "Spices", Order = 23)]
    Spices = 1 << 17, // 131072

    [Display(Name = "Crackers", Order = 24)]
    Crackers = 1 << 18, // 262144

    [Display(Name = "Beverages", Order = 25)]
    Beverages = 1 << 19, // 524288

    [Display(Name = "Nuts and Seeds", Order = 26)]
    Nuts = 1 << 20, // 1048576

    [Display(Name = "Chips", Order = 27)]
    Chips = 1 << 21, // 2097152

    [Display(Name = "Snacks", Order = 28)]
    Snacks = Nuts | Chips,

    [Display(Name = "Milk", Order = 29)]
    Milk = 1 << 22, // 4194304

    [Display(Name = "Cheese", Order = 30)]
    Cheese = 1 << 23, // 8388608

    [Display(Name = "Eggs", Order = 31)]
    Eggs = 1 << 24, // 16777216

    [Display(Name = "Dairy", Order = 32)]
    Dairy = Milk | Cheese | Eggs,

    [Display(Name = "Frozen Fruit", Order = 33)]
    FrozenFruit = 1 << 25, // 33554432

    [Display(Name = "Frozen Vegetables", Order = 34)]
    FrozenVegetables = 1 << 26, // 67108864

    [Display(Name = "Frozen Meat", Order = 35)]
    FrozenMeat = 1 << 27, // 134217728

    [Display(Name = "Frozen Goods", Order = 36)]
    FrozenGoods = FrozenFruit | FrozenVegetables | FrozenMeat,

    [Display(Name = "Meat", Order = 37)]
    Meat = 1 << 28, // 268435456

    [Display(Name = "Fish", Order = 38)]
    Fish = 1 << 29, // 536870912

    [Display(Name = "Home Goods", Order = 39)]
    HomeGoods = 1 << 30, // 1073741824

    [Display(Name = "Supplements", Order = 40)]
    Supplements = 1 << 31, // 2147483648
}
