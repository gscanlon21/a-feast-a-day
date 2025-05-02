using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

/// <summary>
/// Pre-requisite recipes for other recipes.
/// </summary>
[Table("ingredient_alternative")]
[DebuggerDisplay("{Ingredient} alt is {AlternativeIngredient}")]
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

    [DefaultValue(RecipeConsts.IngredientScaleDefault)]
    [Range(RecipeConsts.IngredientScaleMin, RecipeConsts.IngredientScaleMax)]
    public double Scale { get; init; } = RecipeConsts.IngredientScaleDefault;
}
