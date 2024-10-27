using Core.Models.Ingredients;
using Core.Models.User;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class ShoppingListItemDto
{
    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public int Quantity { get; set; } = 1;

    public Category Category { get; set; }

    public Measure Measure { get; set; }

    public bool Optional { get; set; }

    public bool SkipShoppingList { get; init; }

    public override int GetHashCode() => HashCode.Combine(Name.TrimEnd('s', ' '));
    public override bool Equals(object? obj) => obj is ShoppingListItemDto other
        && other.Name.TrimEnd('s', ' ') == Name.TrimEnd('s', ' ');
}
