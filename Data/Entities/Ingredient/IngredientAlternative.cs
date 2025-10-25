using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

/// <summary>
/// Maps an ingredient to it's alternatives.
/// </summary>
[Table("ingredient_alternative")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
[Index(nameof(IngredientId), nameof(IsAggregateElement))]
public class IngredientAlternative
{
    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    public virtual int IngredientId { get; init; }

    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Entities.Ingredient.Ingredient.Alternatives))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    public virtual int AlternativeIngredientId { get; init; }

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Entities.Ingredient.Ingredient.AlternativeIngredients))]
    public virtual Ingredient AlternativeIngredient { get; private init; } = null!;

    /// <summary>
    /// How to scale the quantity of the alternative.
    /// </summary>
    [DefaultValue(RecipeConsts.IngredientScaleDefault)]
    [Range(RecipeConsts.IngredientScaleMin, RecipeConsts.IngredientScaleMax)]
    public double Scale { get; init; } = RecipeConsts.IngredientScaleDefault;

    /// <summary>
    /// Is this alternative ingredient a part of the whole base ingredient.
    /// sa. "Mixed-Color Bell Peppers" having aggregate alt for each color.
    /// </summary>
    public bool IsAggregateElement { get; set; }

    private string GetDebuggerDisplay()
    {
        if (Ingredient != null && AlternativeIngredient != null)
        {
            return $"{Ingredient} alt is {AlternativeIngredient}";
        }

        return $"{IngredientId} alt is {AlternativeIngredientId}";
    }
}
