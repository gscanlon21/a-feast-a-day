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
    public int ServingSizeGrams { get; set; }

    public int CaloriesPerServing { get; set; }

    public int GramsPerCup { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredients))]
    public virtual User? User { get; set; }

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.Ingredient))]
    public virtual List<RecipeIngredient> RecipeIngredients { get; private init; } = null!;

    /// <summary>
    /// Nutrients per Serving Size (Grams).
    /// </summary>
    [InverseProperty(nameof(Nutrient.Ingredient))]
    public virtual List<Nutrient> Nutrients { get; set; } = [];


    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Recipe other
        && other.Id == Id;

    [NotMapped]
    public Allergy[]? AllergenBinder
    {
        get => Enum.GetValues<Allergy>().Where(e => Allergens.HasFlag(e)).ToArray();
        set => Allergens = value?.Aggregate(Allergy.None, (a, e) => a | e) ?? Allergy.None;
    }
}
