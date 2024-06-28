using Core.Models.User;
using Data.Entities.Recipe;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

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
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Is a common household ingredient like salt and pepper.
    /// </summary>
    [Display(Name = "Skip Shopping List")]
    public bool SkipShoppingList { get; set; }

    [Display(Name = "Allergens")]
    public Allergy Allergens { get; set; }

    [Display(Name = "Default Measure")]
    public Measure DefaultMeasure { get; set; }

    [Display(Name = "Grams Per Measure")]
    public double GramsPerMeasure { get; set; }

    [Display(Name = "Grams Per Cup")]
    public double GramsPerCup { get; set; }

    [Display(Name = "Grams Per Serving")]
    public double GramsPerServing { get; set; }

    /// <summary>
    /// Notes about the ingredient (externally shown).
    /// </summary>
    [Display(Name = "Notes")]
    public string? Notes { get; set; } = null;

    /// <summary>
    /// When was this ingredient last checked, for debug user.
    /// </summary>
    public DateOnly LastUpdated { get; set; }

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.Ingredients))]
    public virtual User.User? User { get; set; }

    /// <summary>
    /// Nutrients per serving.
    /// </summary>
    [InverseProperty(nameof(Nutrient.Ingredient))]
    public virtual IList<Nutrient> Nutrients { get; private init; } = [];

    [InverseProperty(nameof(IngredientAlternative.Ingredient))]
    public virtual ICollection<IngredientAlternative> Alternatives { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(IngredientAlternative.AlternativeIngredient))]
    public virtual ICollection<IngredientAlternative> AlternativeIngredients { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.Ingredient))]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private init; } = null!;

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
