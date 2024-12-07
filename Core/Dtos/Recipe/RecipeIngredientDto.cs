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
    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public bool Optional { get; set; }

    public Measure Measure { get; set; }

    public int QuantityNumerator { get; set; } = 1;

    public int QuantityDenominator { get; set; } = 1;

    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);
}
