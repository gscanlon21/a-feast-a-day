using System.Diagnostics;

namespace Core.Dtos.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstructionDto
{
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Notes about the recipe instruction (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public int Order { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeInstructionDto other
        && other.Id == Id;
}
