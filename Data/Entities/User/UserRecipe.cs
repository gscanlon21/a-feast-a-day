using Core.Models.Exercise;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("user_recipe"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class UserRecipe
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

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(UserRecipeIngredient.Recipe))]
    public virtual IList<UserRecipeIngredient> Ingredients { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserRecipeInstruction.Recipe))]
    public virtual IList<UserRecipeInstruction> Instructions { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is UserRecipe other
        && other.Id == Id;
}
