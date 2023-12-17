﻿using Core.Consts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_exercise"), Comment("User's progression level of an exercise")]
[DebuggerDisplay("User: {UserId}, Exercise: {ExerciseId}")]
public class UserExercise
{
    [Required]
    public int UserId { get; init; }

    [Required]
    public int ExerciseId { get; init; }

    /// <summary>
    /// How far the user has progressed for this exercise.
    /// </summary>
    [Required, Range(UserConsts.MinUserProgression, UserConsts.MaxUserProgression)]
    public int Progression { get; set; } = UserConsts.MinUserProgression;

    /// <summary>
    /// Don't show this exercise or any of it's variations to the user
    /// </summary>
    [Required]
    public bool Ignore { get; set; }

    /// <summary>
    /// When was this exercise last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    /// <summary>
    /// When did this exercise last have potential to be seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastVisible { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// If this is set, will not update the LastSeen date until this date is reached.
    /// This is so we can reduce the variation of workouts and show the same groups of exercises for a month+ straight.
    /// </summary>
    public DateOnly? RefreshAfter { get; set; }

    [JsonIgnore, InverseProperty(nameof(Entities.Exercise.Exercise.UserExercises))]
    public virtual Exercise.Exercise Exercise { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserExercises))]
    public virtual User User { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, ExerciseId);

    public override bool Equals(object? obj) => obj is UserExercise other
        && other.ExerciseId == ExerciseId
        && other.UserId == UserId;
}
