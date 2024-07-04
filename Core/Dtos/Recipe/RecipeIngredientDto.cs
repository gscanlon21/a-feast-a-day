using Core.Models.User;
using Fractions;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientDto
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public int Order { get; set; }

    public int QuantityNumerator { get; set; } = 1;

    public int QuantityDenominator { get; set; } = 1;

    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);

    public Measure Measure { get; set; }

    public Measure DefaultMeasure { get; set; }

    public bool Optional { get; set; }

    public bool SkipShoppingList { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientDto other
        && other.Id == Id;
}
