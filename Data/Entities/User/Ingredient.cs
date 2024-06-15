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
    public int Id { get; init; }

    public int? UserId { get; init; }

    public int? ParentId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    public Allergy Allergens { get; set; }

    /// <summary>
    /// Is a common household ingredient like salt and pepper.
    /// </summary>
    [Display(Name = "Skip Shopping List")]
    public bool SkipShoppingList { get; set; }

    [Display(Name = "Serving Size (grams)")]
    public double GramsPerServing { get; set; }

    public double CaloriesPerServing { get; set; }

    public double GramsPerMeasure { get; set; }
    public Measure DefaultMeasure { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    /// <summary>
    /// When was this ingredient last checked, for debug user.
    /// </summary>
    public DateOnly LastUpdated { get; set; }

    /// <summary>
    /// The base ingredient.
    /// </summary>
    [JsonIgnore, InverseProperty(nameof(Children))]
    public virtual Ingredient? Parent { get; private init; } = null!;

    /// <summary>
    /// Substitute ingredients.
    /// </summary>
    [InverseProperty(nameof(Parent))]
    public virtual ICollection<Ingredient> Children { get; private init; } = [];

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.Ingredients))]
    public virtual User? User { get; set; }

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.Ingredient))]
    public virtual List<RecipeIngredient> RecipeIngredients { get; private init; } = null!;

    /// <summary>
    /// Nutrients per Serving Size (Grams).
    /// </summary>
    [InverseProperty(nameof(Nutrient.Ingredient))]
    public virtual List<Nutrient> Nutrients { get; set; } = [];

    [JsonIgnore, InverseProperty(nameof(UserIngredient.Ingredient))]
    public virtual ICollection<UserIngredient> UserIngredients { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserIngredient.SubstituteIngredient))]
    public virtual ICollection<UserIngredient> UserSubstituteIngredients { get; private init; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Ingredient other
        && other.Id == Id;

    [NotMapped]
    public Allergy[]? AllergenBinder
    {
        get => Enum.GetValues<Allergy>().Where(e => Allergens.HasFlag(e)).ToArray();
        set => Allergens = value?.Aggregate(Allergy.None, (a, e) => a | e) ?? Allergy.None;
    }
}
