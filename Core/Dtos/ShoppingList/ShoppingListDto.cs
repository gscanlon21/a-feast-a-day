
namespace Core.Dtos.ShoppingList;

public class ShoppingListDto
{
    public required int NewsletterId { get; init; }

    public required IList<ShoppingListItemDto> ShoppingList { get; init; } = [];

    public override int GetHashCode() => NewsletterId.GetHashCode();
    public override bool Equals(object? obj) => obj is ShoppingListDto other
        && other.NewsletterId.Equals(NewsletterId);
}
