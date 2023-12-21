using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Lib.ViewModels.Newsletter;

// TODO: Implement IValidateableObject and setup model validation instead of using the /exercises/check route
/// <summary>
/// Intensity level of an exercise variation
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class IngredientViewModel
{
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    public string Quantity { get; init; }

    public Measure? Measure { get; init; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is InstructionViewModel other
        && other.Id == Id;
}