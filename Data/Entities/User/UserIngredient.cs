using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Not using RecipeIngredientId because we want to be able to 
/// ... re-order RecipeIngredients without changing user preferences.
/// </summary>
[Table("user_ingredient")]
public class UserIngredient
{
    [Required]
    public int UserId { get; init; }

    [Required]
    public int RecipeId { get; set; }

    [Required]
    public int IngredientId { get; set; }

    [DefaultValue(RecipeConsts.IngredientScaleDefault)]
    [Range(RecipeConsts.IngredientScaleMin, RecipeConsts.IngredientScaleMax)]
    [Display(Name = "Substitute Scale")]
    public double SubstituteScale { get; set; } = RecipeConsts.IngredientScaleDefault;

    [Display(Name = "Substitute Ingredient")]
    public int? SubstituteIngredientId { get; set; }

    [Display(Name = "or Substitute Recipe")]
    public int? SubstituteRecipeId { get; set; }

    public string? Notes { get; set; }

    [Required]
    public bool Ignore { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredients))]
    public virtual User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Recipe.UserIngredients))]
    public virtual Recipe.Recipe Recipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserIngredients))]
    public virtual Ingredient.Ingredient Ingredient { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserSubstituteIngredients))]
    public virtual Ingredient.Ingredient? SubstituteIngredient { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.UserSubstituteRecipes))]
    public virtual Recipe.Recipe? SubstituteRecipe { get; private init; }

    #endregion Navigation Properties


    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId, IngredientId);
    public override bool Equals(object? obj) => obj is UserIngredient other
        && other.IngredientId == IngredientId
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
