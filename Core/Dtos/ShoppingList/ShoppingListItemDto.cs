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
    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public Category Category { get; init; }

    public Measure Measure { get; init; }

    public int Quantity { get; init; } = 1;

    public bool Optional { get; init; }

    public bool SkipShoppingList { get; init; }

    public override int GetHashCode() => HashCode.Combine(Name.TrimEnd('s', ' '));
    public override bool Equals(object? obj) => obj is ShoppingListItemDto other
        && other.Name.TrimEnd('s', ' ') == Name.TrimEnd('s', ' ');
}
