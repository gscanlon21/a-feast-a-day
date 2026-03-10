using System.Diagnostics;

namespace Core.Dtos.Ingredient;

/// <summary>
/// Recipes listed on the website
/// </summary>
[DebuggerDisplay("{Nutrients}: {Measure} - {Value}")]
public class IngredientNutrientDto
{
    public int Id { get; init; }

    public int? IngredientId { get; init; }

    /// <summary>
    /// If it has atleast 10% RDA per serving.
    /// </summary>
    public Models.Nutrients.Nutrients Nutrients { get; set; }

    public Measure Measure { get; set; }

    public double Value { get; set; }

    /// <summary>
    /// Notes about the nutrient (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is IngredientNutrientDto other
        && other.Id == Id;
}
