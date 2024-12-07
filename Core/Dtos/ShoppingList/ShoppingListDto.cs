using System.Diagnostics;

namespace Core.Dtos.ShoppingList;

[DebuggerDisplay("{Hash,nq}")]
public class ShoppingListDto
{
    public required IList<ShoppingListItemDto> ShoppingList { get; init; } = [];
    public string Hash => string.Join('_', ShoppingList.Select(s => s.Id));
}
