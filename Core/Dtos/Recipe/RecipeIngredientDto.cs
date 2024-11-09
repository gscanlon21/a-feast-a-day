using Core.Models.User;
using Fractions;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// The ingredients of a recipe.
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientDto
{
    public int Id { get; init; }

    public int Order { get; set; }

    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public bool Optional { get; set; }

    public Measure Measure { get; set; }

    public Measure DefaultMeasure { get; set; }

    public int QuantityNumerator { get; set; } = 1;

    public int QuantityDenominator { get; set; } = 1;

    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientDto other
        && other.Id == Id;
}
