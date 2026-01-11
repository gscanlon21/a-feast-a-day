using Core.Models.User;
using Data.Interfaces.Recipe;
using Data.Query;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A feast's recipe's ingredients.
/// 
/// Recipe ingredient recipes are logged as separate user_feast_recipe entities, 
/// ... so we only care about ingredients. This way we also track user substitutions.
/// </summary>
[Table("user_feast_recipe_ingredient")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class UserFeastRecipeIngredient : IRecipeIngredient
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserFeastRecipeIngredient() { }

    public UserFeastRecipeIngredient(RecipeIngredientQueryResults recipeIngredient)
    {
        Measure = recipeIngredient.Measure;
        CoarseCut = recipeIngredient.CoarseCut;
        RecipeIngredientId = recipeIngredient.Id;
        CookedScale = recipeIngredient.CookedScale;
        Quantity = recipeIngredient.Quantity.ToDouble();
        // Don't set Ingredient, so that EF Core doesn't add/update Ingredient.
        IngredientId = recipeIngredient.Ingredient!.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private init; }

    public int IngredientId { get; init; }

    public int RecipeIngredientId { get; private init; }

    /// <summary>
    /// Don't need to set this as long as it's inserted at the same time UserFeastRecipe is.
    /// </summary>
    public long UserFeastRecipeId { get; private init; }

    [DefaultValue(IngredientConsts.CookedScaleDefault)]
    public double CookedScale { get; private init; }

    /// <summary>
    /// This value is set after recipe scaling is applied.
    /// </summary>
    public double Quantity { get; private init; } = 1;

    public Measure Measure { get; private init; }

    public bool CoarseCut { get; private init; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Newsletter.UserFeastRecipe.UserFeastRecipeIngredients))]
    public virtual UserFeastRecipe UserFeastRecipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredients.Ingredient.UserFeastRecipeIngredients))]
    public virtual Ingredients.Ingredient Ingredient { get; private init; } = null!;

    #endregion


    [NotMapped]
    public bool IsCoarseCut => CoarseCut;

    [NotMapped]
    public Measure GetMeasure => Measure;

    [NotMapped]
    public double GetQuantity => Quantity;

    [NotMapped]
    public double GetCookedScale => CookedScale;

    [NotMapped]
    public int GetRecipeIngredientId => RecipeIngredientId;

    [NotMapped]
    public Ingredients.Ingredient? GetIngredient => Ingredient;

    private string GetDebuggerDisplay()
    {
        if (Ingredient != null)
        {
            return $"{Ingredient}";
        }

        return $"{IngredientId}";
    }
}
