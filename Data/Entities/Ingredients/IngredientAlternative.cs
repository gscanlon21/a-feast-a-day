using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredients;

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
    [JsonInclude, InverseProperty(nameof(Ingredients.Ingredient.Alternatives))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    public virtual int AlternativeIngredientId { get; init; }

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    [JsonInclude, InverseProperty(nameof(Ingredients.Ingredient.AlternativeIngredients))]
    public virtual Ingredient AlternativeIngredient { get; init; } = null!;

    /// <summary>
    /// How to scale the quantity of the alternative.
    /// </summary>
    [DefaultValue(IngredientConsts.AlternativeScaleDefault)]
    [Range(IngredientConsts.AlternativeScaleMin, IngredientConsts.AlternativeScaleMax)]
    public double Scale { get; init; } = IngredientConsts.AlternativeScaleDefault;

    /// <summary>
    /// Is this alternative ingredient a part of the whole base ingredient.
    /// sa. "Mixed-Color Bell Peppers" having aggregate alt for each color.
    /// </summary>
    [DefaultValue(false)]
    public bool IsAggregateElement { get; set; }

    private string GetDebuggerDisplay()
    {
        if (Ingredient != null && AlternativeIngredient != null)
        {
            return $"{Ingredient.Name} alt is {AlternativeIngredient.Name}";
        }

        return $"{IngredientId} alt is {AlternativeIngredientId}";
    }
}
