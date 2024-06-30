using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredient;

/// <summary>
/// Pre-requisite exercises for other exercises
/// </summary>
[Table("ingredient_alternative"), Comment("Alternative ingredients")]
[DebuggerDisplay("{Ingredient} alt is {AlternativeIngredient}")]
public class IngredientAlternative
{
    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    public virtual int IngredientId { get; private init; }

    /// <summary>
    /// This is the ingredient that has an alternative.
    /// </summary>
    [JsonIgnore, InverseProperty(nameof(Entities.Ingredient.Ingredient.Alternatives))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    public virtual int AlternativeIngredientId { get; private init; }

    /// <summary>
    /// This is the alternative ingredient.
    /// </summary>
    [InverseProperty(nameof(Entities.Ingredient.Ingredient.AlternativeIngredients))]
    public virtual Ingredient AlternativeIngredient { get; private init; } = null!;
}
