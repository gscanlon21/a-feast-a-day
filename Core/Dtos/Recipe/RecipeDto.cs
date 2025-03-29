using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Recipe;

/// <summary>
/// DTO class for Recipe.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeDto
{
    public int Id { get; init; }

    public Section Section { get; init; }
    public Measure Measure { get; init; }
    public Equipment Equipment { get; init; }

    public string Name { get; init; } = null!;
    public string? Link { get; init; } = null;
    public string? Notes { get; init; } = null;
    public string? Image { get; init; } = null;

    public int Servings { get; init; }
    public bool BaseRecipe { get; init; }
    public bool AdjustableServings { get; init; }
    public bool KeepIngredientOrder { get; init; }

    public int PrepTime { get; init; }
    public int CookTime { get; init; }
    public int TotalTime => PrepTime + CookTime;

    [JsonInclude]
    public virtual IList<RecipeInstructionDto> Instructions { get; init; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeDto other
        && other.Id == Id;
}
