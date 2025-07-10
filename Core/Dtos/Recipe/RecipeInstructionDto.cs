using Core.Models.Recipe;
using System.Diagnostics;

namespace Core.Dtos.Recipe;

/// <summary>
/// DTO for RecipeInstruction.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstructionDto
{
    public int Id { get; init; }
    public int Order { get; init; }
    public string Name { get; init; } = null!;
    public Equipment Equipment { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeInstructionDto other
        && other.Id == Id;
}
