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
[Table("ingredient"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class Ingredient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public int? UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// If it has atleast 10% RDA per serving.
    /// </summary>
    public Nutrient Nutrients { get; init; }

    public Allergy Allergens { get; init; }

    /// <summary>
    /// Is a common household ingredient like salt and pepper.
    /// </summary>
    public bool SkipShoppingList { get; init; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; private init; } = null;

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredients))]
    public virtual User? User { get; set; }

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.Ingredient))]
    public virtual List<RecipeIngredient> RecipeIngredients { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Recipe other
        && other.Id == Id;
}
