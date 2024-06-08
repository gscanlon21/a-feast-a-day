using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Lib.ViewModels.Newsletter;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstructionViewModel
{
    public int Id { get; init; }

    public int Order { get; set; }

    /// <summary>
    /// The instruction text.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// Notes about the instruction (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeInstructionViewModel other
        && other.Id == Id;
}
