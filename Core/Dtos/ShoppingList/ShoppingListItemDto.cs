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
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    public int Quantity { get; init; } = 1;

    public bool Optional { get; init; }

    public Measure Measure { get; init; }

    public Category Category { get; init; }

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public bool SkipShoppingList { get; init; }
}
