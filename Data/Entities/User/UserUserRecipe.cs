using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_user_recipe"), Comment("User's progression level of an exercise")]
[DebuggerDisplay("User: {UserId}, Exercise: {ExerciseId}")]
public class UserUserRecipe
{
    [Required]
    public int UserId { get; init; }

    [Required]
    public int RecipeId { get; init; }

    /// <summary>
    /// Don't show this exercise or any of it's variations to the user
    /// </summary>
    [Required]
    public bool Ignore { get; set; }

    /// <summary>
    /// Multiplier for how often this exercise is choosen. Weights the LastSeen date.
    /// </summary>
    public bool? IsPrimary { get; set; }

    /// <summary>
    /// When was this exercise last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    [JsonIgnore, InverseProperty(nameof(UserRecipe.UserUserRecipes))]
    public virtual UserRecipe Recipe { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserUserRecipes))]
    public virtual User User { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId);

    public override bool Equals(object? obj) => obj is UserUserRecipe other
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
