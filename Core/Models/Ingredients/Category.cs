using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredient;

public enum Category
{
    None = 0,

    [Display(Name = "Produce", Order = 1)]
    Produce = 1,

    [Display(Name = "Baked Goods", Order = 2)]
    BakedGoods = 2,

    [Display(Name = "Container Goods", Order = 3)]
    ContainerGoods = 3,

    [Display(Name = "Dry Goods", Order = 4)]
    DryGoods = 4,

    [Display(Name = "Beverages", Order = 5)]
    Beverages = 5,

    [Display(Name = "Dairy", Order = 6)]
    Dairy = 6,

    [Display(Name = "Frozen Goods", Order = 7)]
    FrozenGoods = 7,

    [Display(Name = "Meat", Order = 8)]
    Meat = 8,

    [Display(Name = "Personal Care Items", Order = 9)]
    PersonalCareItems = 9,

    [Display(Name = "Home Care Items", Order = 10)]
    HomeCareItems = 10,

    [Display(Name = "Pet Care Items", Order = 11)]
    PetCareItems = 11,
}
