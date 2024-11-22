using Core.Dtos.User;
using Core.Models.Ingredients;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Core.Dtos.Ingredient;

/// <summary>
/// DTO for an ingredient.
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class IngredientDto
{
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Is a common household ingredient like salt and pepper.
    /// </summary>
    [Display(Name = "Skip Shopping List")]
    public bool SkipShoppingList { get; set; }

    [Display(Name = "Allergens")]
    public Allergens Allergens { get; set; }

    [Display(Name = "Category")]
    public Category Category { get; set; }

    [Display(Name = "Default Measure")]
    public Measure DefaultMeasure { get; set; }

    [Display(Name = "Grams Per Measure")]
    public double GramsPerMeasure { get; set; }

    [Display(Name = "Grams Per Cup")]
    public double GramsPerCup { get; set; }

    [Display(Name = "Grams Per Serving")]
    public double GramsPerServing { get; set; }

    /// <summary>
    /// Notes about the recipe ingredient (externally shown).
    /// </summary>
    [Display(Name = "Notes")]
    public string? Notes { get; set; } = null;

    /// <summary>
    /// These are the alternate ingredients.
    /// </summary>
    public ICollection<IngredientAlternativeDto> Alternatives { get; init; } = [];

    /// <summary>
    /// These are what ingredients this ingredient is an alternate of.
    /// </summary>
    public ICollection<IngredientAlternativeDto> AlternativeIngredients { get; init; } = [];

    /// <summary>
    /// Nutrients per Serving Size (Grams).
    /// </summary>
    public ICollection<NutrientDto> Nutrients { get; set; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is IngredientDto other
        && other.Id == Id;
}
