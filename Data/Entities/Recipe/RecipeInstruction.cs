﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Recipe;

/// <summary>
/// A recipe's instructions.
/// </summary>
[Table("recipe_instruction")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeInstruction
{
    // Not private so json can bind to it.
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int Order { get; init; }

    [Required]
    public string Name { get; init; } = null!;

    public string? DisabledReason { get; init; } = null;

    [NotMapped]
    public bool Hide { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.Instructions))]
    public virtual Recipe Recipe { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeInstruction other
        && other.Id == Id;
}
