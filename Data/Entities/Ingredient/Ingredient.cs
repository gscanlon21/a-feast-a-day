using Core.Models.Ingredients;
using Core.Models.User;
using Data.Entities.Genetics;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

/// <summary>
/// Ingredient's used in recipes.
/// 
/// <para>
/// The boiling point of most cooking oils is much higher than their smoke points. 
/// The boiling point of olive oil, for example, is around 300°C (572°F), 
/// ... which is hotter than the temperature of a pan on a typical residential range/cooktop.
/// With that said, alcohols and esters which make up the flavor and fragrance 
/// ... of the oil will have lower boiling points and will therefore evaporate.
/// That should not significantly alter the nutritional content of the oil. 
/// Furthermore, much of the perceived loss of oil is likely due to a combination 
/// ... of absorption of the oil into the items being fried, and also due to splatter. 
/// The latter cannot be easily quantified due to its connection with the cooking vessel and the technique of the cook.
/// </para>
/// </summary>
[Table("ingredient")]
[Index(nameof(UserId))]
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
    public virtual IList<Nutrient> Nutrients { get; set; } = [];

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
