using Core.Models.Ingredients;
using Core.Models.User;
using Data.Entities.Genetics;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("ingredient")]
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
    public virtual User.User? User { get; private init; }

    /// <summary>
    /// Nutrients per serving.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Nutrient.Ingredient))]
    public virtual IList<Nutrient> Nutrients { get; private init; } = [];

    /// <summary>
    /// These are the alternate ingredients.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(IngredientAlternative.Ingredient))]
    public virtual ICollection<IngredientAlternative> Alternatives { get; private init; } = [];

    /// <summary>
    /// These are what ingredients this ingredient is an alternate of.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(IngredientAlternative.AlternativeIngredient))]
    public virtual ICollection<IngredientAlternative> AlternativeIngredients { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.Ingredient))]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private init; } = null!;

    //[JsonIgnore, InverseProperty(nameof(UserRecipeIngredient.Ingredient))]
    //public virtual ICollection<UserRecipeIngredient> UserIngredients { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserRecipeIngredient.SubstituteIngredient))]
    public virtual ICollection<UserRecipeIngredient> UserSubstituteIngredients { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipeIngredient.Ingredient))]
    public virtual ICollection<UserFeastRecipeIngredient> UserFeastRecipeIngredients { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(StudyIngredient.Ingredient))]
    public virtual ICollection<StudyIngredient> StudyIngredients { get; private init; } = null!;

    [NotMapped]
    public Allergens[]? AllergenBinder
    {
        get => Enum.GetValues<Allergens>().Where(e => Allergens.HasFlag(e)).ToArray();
        set => Allergens = value?.Aggregate(Allergens.None, (a, e) => a | e) ?? Allergens.None;
    }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Ingredient other
        && other.Id == Id;
}
