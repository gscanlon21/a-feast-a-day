using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe_ingredient")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Display(Name = "Ingredient")]
    public int IngredientId { get; init; }

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    [Range(1, 1000), Display(Name = "Quantity")]
    public int? QuantityNumerator { get; set; } = 1;

    [Range(1, 16), Display(Name = "Quantity")]
    public int? QuantityDenominator { get; set; } = 1;

    public Fractions.Fraction Quantity => new(QuantityNumerator ?? 0, QuantityDenominator ?? 0);

    [Required]
    public Measure Measure { get; set; }


    public bool Optional { get; set; }

    [NotMapped]
    public bool Hide { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    [NotMapped]
    public string Name => Ingredient?.Name ?? "";

    [NotMapped]
    public bool SkipShoppingList => Ingredient?.SkipShoppingList ?? false;

    [JsonIgnore]
    public virtual RecipeDto Recipe { get; init; } = null!;

    [JsonInclude]
    public virtual IngredientDto Ingredient { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeIngredientDto other
        && other.Id == Id;
}
