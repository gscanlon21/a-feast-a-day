using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe_instruction")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstructionDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public int Order { get; set; }

    [NotMapped]
    public bool Hide { get; set; }

    public string? DisabledReason { get; init; } = null;

    [JsonIgnore]
    public virtual RecipeDto Recipe { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeInstructionDto other
        && other.Id == Id;
}
