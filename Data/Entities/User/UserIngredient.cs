using Core.Models.User;
using Data.Entities.Recipe;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Not using RecipeIngredientId because we want to be able to 
/// ... re-order RecipeIngredients without changing user preferences.
/// </summary>
[Table("user_recipe_ingredient")]
public class UserRecipeIngredient
{
    [Required]
    public int UserId { get; init; }

    [Required]
    public int RecipeIngredientId { get; set; }


    public Measure? Measure { get; set; }

    public int? QuantityNumerator { get; set; }

    public int? QuantityDenominator { get; set; }


    public int? SubstituteRecipeId { get; set; }

    public int? SubstituteIngredientId { get; set; }

    
    public string? Notes { get; set; }

    [Required]
    public bool Ignore { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserRecipeIngredients))]
    public virtual User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.UserRecipeIngredients))]
    public virtual RecipeIngredient RecipeIngredient { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.Ingredient.UserSubstituteIngredients))]
    public virtual Ingredient.Ingredient? SubstituteIngredient { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Recipe.Recipe.UserSubstituteRecipes))]
    public virtual Recipe.Recipe? SubstituteRecipe { get; private init; }

    #endregion Navigation Properties


    public override int GetHashCode() => HashCode.Combine(UserId, RecipeIngredientId);
    public override bool Equals(object? obj) => obj is UserRecipeIngredient other
        && other.RecipeIngredientId == RecipeIngredientId
        && other.UserId == UserId;
}
