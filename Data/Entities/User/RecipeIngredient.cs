using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe_ingredient"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

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

    [Required]
    public Measure Measure { get; set; }


    public bool Optional { get; set; }

    [NotMapped]
    public bool Hide { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; private init; } = null;

    public string? DisabledReason { get; private init; } = null;

    [NotMapped]
    public string Name => Ingredient?.Name ?? "";

    [NotMapped]
    public bool SkipShoppingList => Ingredient?.SkipShoppingList ?? false;

    [JsonIgnore, InverseProperty(nameof(Entities.User.Recipe.RecipeIngredients))]
    public virtual Recipe Recipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.Ingredient.RecipeIngredients))]
    public virtual Ingredient Ingredient { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeIngredient other
        && other.Id == Id;
}
