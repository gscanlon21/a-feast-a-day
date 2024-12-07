using System.Diagnostics;

namespace Core.Dtos.Ingredient;

/// <summary>
/// Pre-requisite recipes for other recipes.
/// </summary>
[DebuggerDisplay("{IngredientId} alt is {AlternativeIngredient}")]
public class IngredientAlternativeDto
{
    public int IngredientId { get; init; }

    public int AlternativeIngredientId { get; init; }

    public IngredientDto Ingredient { get; init; } = null!;

    public IngredientDto AlternativeIngredient { get; init; } = null!;
}
