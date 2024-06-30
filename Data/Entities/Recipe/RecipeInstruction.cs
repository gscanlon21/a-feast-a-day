using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe_instruction"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstruction
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; private init; } = null!;

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; private init; } = null;

    public int Order { get; private init; }

    public string? DisabledReason { get; private init; } = null;

    [NotMapped]
    public bool Hide { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.Instructions))]
    public virtual Recipe Recipe { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeInstruction other
        && other.Id == Id;
}
