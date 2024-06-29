using System.Diagnostics;

namespace Core.Dtos.Ingredient;

/// <summary>
/// Pre-requisite exercises for other exercises
/// </summary>
[DebuggerDisplay("{IngredientId} alt is {AlternativeIngredient}")]
public class IngredientAlternativeDto
{
    public virtual int IngredientId { get; init; }

    public virtual int AlternativeIngredientId { get; init; }

    public virtual IngredientDto AlternativeIngredient { get; init; } = null!;
}
