using System.Diagnostics;

namespace Core.Dtos.ShoppingList;

/// <summary>
/// Ingredients used in a feast.
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class ShoppingListItemDto
{
    public required string Name { get; init; } = null!;

    public required string Group { get; init; } = null!;

    public required bool SkipShoppingList { get; init; }

    public required Measure Measure { get; init; }

    public required string? Notes { get; init; }

    public required int Quantity { get; init; }

    public required int Order { get; init; }
}
