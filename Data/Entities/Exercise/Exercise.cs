﻿using Core.Models.Exercise;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Exercise;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class Exercise
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; private init; } = null!;

    /// <summary>
    /// Similar groups of exercises.
    /// </summary>
    [Required]
    public ExerciseGroup Groups { get; private init; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; private init; } = null;

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(UserExercise.Exercise))]
    public virtual ICollection<UserExercise> UserExercises { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Exercise other
        && other.Id == Id;
}
