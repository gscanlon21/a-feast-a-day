using Core.Models.Ingredients;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredients;


/// <summary>
/// Maps an ingredient to it's alternatives.
/// </summary>
[Table("ingredient_cooked")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class IngredientCooked
{
    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    public virtual int IngredientId { get; init; }

    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Ingredients.Ingredient.IngredientsCooked))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    public virtual int CookedIngredientId { get; init; }

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Ingredient.CookedIngredients))]
    public virtual Ingredient CookedIngredient { get; private init; } = null!;

    /// <summary>
    /// How to scale the quantity of the cooked ingredient.
    /// </summary>
    [DefaultValue(RecipeConsts.IngredientScaleDefault)]
    [Range(RecipeConsts.IngredientScaleMin, RecipeConsts.IngredientScaleMax)]
    public double Scale { get; init; } = RecipeConsts.IngredientScaleDefault;

    public CookingMethod CookingMethod { get; init; }

    private string GetDebuggerDisplay()
    {
        if (CookedIngredient != null)
        {
            return $"{IngredientId}:{CookingMethod.GetSingleDisplayName()} alt is {CookedIngredientId}:{CookedIngredient.Name}";
        }

        return $"{IngredientId}:{CookingMethod.GetSingleDisplayName()} alt is {CookedIngredientId}";
    }
}
