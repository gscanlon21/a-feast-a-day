using Core.Models.User;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class ShoppingListItemDto
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public int Quantity { get; set; } = 1;

    public Measure Measure { get; set; }

    public bool Optional { get; set; }

    public bool SkipShoppingList { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientDto other
        && other.Id == Id;
}
