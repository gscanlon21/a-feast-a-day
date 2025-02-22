using System.Diagnostics;

namespace Core.Dtos.ShoppingList;

[DebuggerDisplay("{Hash,nq}")]
public class ShoppingListDto
{
    public required int NewsletterId { get; init; }
    public required IList<ShoppingListItemDto> ShoppingList { get; init; } = [];

    /// <summary>
    /// Hash to differ different shopping lists.
    /// </summary>
    public int Hash => NewsletterId;
}
