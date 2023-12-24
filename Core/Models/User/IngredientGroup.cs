namespace Core.Models.User;

[Flags]
public enum IngredientGroup
{
    None = 0,

    Produce = 1 << 0, // 1

    Grains = 1 << 1, // 2

    Meat = 1 << 2, // 4

    Protein = 1 << 3, // 8

    Dairy = 1 << 4, // 16

    BakingGoods = 1 << 5, // 32

    FreezerGoods = 1 << 6, // 64

    CannedGoods = 1 << 7, // 128

    DriedGoods = 1 << 8, // 256

    Condiments = 1 << 9, // 512

    Spices = 1 << 10, // 1024

    Oils = 1 << 11, // 2048

    Vinegars = 1 << 12, // 4096,

    Snacks = 1 << 13, // 8192
}
