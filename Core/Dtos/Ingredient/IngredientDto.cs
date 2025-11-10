using Core.Dtos.User;
using Core.Models.Ingredients;
using Core.Models.User;
using System.Diagnostics;

namespace Core.Dtos.Ingredient;

/// <summary>
/// DTO for an ingredient.
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class IngredientDto
{
    public IngredientDto() { }
    public IngredientDto(string name)
    {
        Name = name;
    }

    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public bool SkipShoppingList { get; set; }

    public Allergens Allergens { get; set; }

    public Category Category { get; set; }

    public Measure DefaultMeasure { get; set; }

    public double GramsPerMeasure { get; set; }

    public double GramsPerCup { get; set; }

    public double GramsPerServing { get; set; }

    public string? Notes { get; set; } = null;

    /// <summary>
    /// Nutrients per Serving Size (Grams).
    /// </summary>
    public ICollection<NutrientDto> Nutrients { get; set; } = [];

    /// <summary>
    /// These are the alternate ingredients.
    /// </summary>
    public ICollection<IngredientAlternativeDto> Alternatives { get; init; } = [];

    /// <summary>
    /// These are what ingredients this ingredient is an alternate of.
    /// </summary>
    public ICollection<IngredientAlternativeDto> AlternativeIngredients { get; init; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is IngredientDto other
        && other.Id == Id;
}
