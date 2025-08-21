using Core.Models.User;
using Data.Entities.User;
using Fractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Recipe;

/// <summary>
/// A recipe's ingredients.
/// </summary>
[Table("recipe_ingredient")]
[DebuggerDisplay("Id = {Id}, {Recipe}: {Ingredient}")]
public class RecipeIngredient
{
    // Not private so json can bind to it.
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Display(Name = "Recipe")]
    public int RecipeId { get; init; }

    [Display(Name = "Ingredient")]
    public int? IngredientId { get; init; }

    [Display(Name = "or Recipe")]
    public int? IngredientRecipeId { get; init; }

    [Display(Name = "Quantity")]
    [Required, DefaultValue(RecipeConsts.QuantityNumeratorDefault)]
    [Range(RecipeConsts.QuantityNumeratorMin, RecipeConsts.QuantityNumeratorMax)]
    public int QuantityNumerator { get; set; } = RecipeConsts.QuantityNumeratorDefault;

    [Display(Name = "Quantity")]
    [Required, DefaultValue(RecipeConsts.QuantityDenominatorDefault)]
    [Range(RecipeConsts.QuantityDenominatorMin, RecipeConsts.QuantityDenominatorMax)]
    public int QuantityDenominator { get; set; } = RecipeConsts.QuantityDenominatorDefault;

    [Required]
    public int Order { get; set; }

    [Required]
    public bool Optional { get; set; }

    [Required]
    public Measure Measure { get; set; }

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    /// <summary>
    /// Notes about the recipe ingredient (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    /// <summary>
    /// Used in the edit form: whether the form field is hidden or not.
    /// </summary>
    [NotMapped]
    public bool Hide { get; set; }

    [NotMapped]
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);


    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.RecipeIngredients))]
    public virtual Recipe Recipe { get; private init; } = null!;

    [JsonInclude, InverseProperty(nameof(Entities.Ingredient.Ingredient.RecipeIngredients))]
    public virtual Ingredient.Ingredient Ingredient { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(Entities.Recipe.Recipe.RecipeIngredientRecipes))]
    public virtual Recipe IngredientRecipe { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(UserRecipeIngredient.RecipeIngredient))]
    public virtual ICollection<UserRecipeIngredient> UserRecipeIngredients { get; set; } = null!;


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredient other
        && other.Id == Id;
}
