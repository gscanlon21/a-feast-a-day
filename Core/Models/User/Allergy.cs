namespace Core.Models.User;

[Flags]
public enum Allergy
{
    None = 0,

    Lactose = 1 << 0, // 1

    Eggs = 1 << 1, // 2

    TreeNuts = 1 << 2, // 4

    Peanuts = 1 << 3, // 8

    Shellfish = 1 << 4, // 16

    Gluten = 1 << 5, // 32

    Soy = 1 << 6, // 64

    Fish = 1 << 7, // 128

    Sesame = 1 << 8, // 256

    Histamine = 1 << 9, // 512
}
