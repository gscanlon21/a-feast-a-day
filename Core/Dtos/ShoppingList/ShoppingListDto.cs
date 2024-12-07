using System.Diagnostics;

namespace Core.Dtos.ShoppingList;

[DebuggerDisplay("{Hash,nq}")]
public class ShoppingListDto
{
    public required int NewsletterId { get; init; }
    public required IList<ShoppingListItemDto> ShoppingList { get; init; } = [];

    /// <summary>
    /// Add the item count so if the user ignores a recipe, the list changes.
    /// </summary>
    public int Hash => unchecked(unchecked(NewsletterId * 100) + ShoppingList.Count);
}
