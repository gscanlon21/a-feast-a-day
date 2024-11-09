using System.Diagnostics;

namespace Core.Dtos.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstructionDto
{
    public int Id { get; init; }

    public int Order { get; init; }

    public string Name { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeInstructionDto other
        && other.Id == Id;
}
