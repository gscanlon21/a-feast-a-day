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
    public virtual int IngredientId { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Ingredient.Ingredient.Alternatives))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    public virtual int AlternativeIngredientId { get; private init; }

    [InverseProperty(nameof(Entities.Ingredient.Ingredient.AlternativeIngredients))]
    public virtual Ingredient AlternativeIngredient { get; private init; } = null!;
}
