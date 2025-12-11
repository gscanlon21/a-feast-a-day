using Core.Models.Recipe;
using Core.Models.User;
using Fractions;
using System.Diagnostics;

namespace Core.Dtos.Recipe;

/// <summary>
/// DTO for RecipeIngredient.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientDto
{
    public string Name { get; init; } = null!;

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    public bool Partial { get; init; }
    public bool Optional { get; init; }
    public Measure Measure { get; init; }
    public RecipeIngredientType Type { get; init; }
    public bool IsUnwantedAndHasAlternatives { get; init; }

    public int QuantityNumerator { get; init; } = 1;
    public int QuantityDenominator { get; init; } = 1;
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);

    public string GetFontWeight() => Type == RecipeIngredientType.IngredientRecipe ? "600" : "normal";
    public string GetListStyleType() => Optional ? "circle" : "disc";
}
