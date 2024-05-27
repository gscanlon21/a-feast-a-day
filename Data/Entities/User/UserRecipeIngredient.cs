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
[Table("user_recipe_ingredient"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class UserRecipeIngredient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Display(Name = "Ingredient")]
    public int UserIngredientId { get; init; }

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

    [JsonIgnore, InverseProperty(nameof(Entities.User.Recipe.Ingredients))]
    public virtual Recipe Recipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserIngredient.RecipeIngredients))]
    public virtual UserIngredient Ingredient { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Recipe other
        && other.Id == Id;
}
