using Core.Models.Ingredients;
using Core.Models.User;
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

    public required int Quantity { get; init; } = 1;

    public required Measure Measure { get; init; }

    public required Category Category { get; init; }

    public required bool SkipShoppingList { get; init; }

    public required string? Notes { get; init; }
}
