using Core.Dtos.Recipe;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_recipe")]
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipeDto
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

    public int Scale { get; set; } = 1;

    public string? Notes { get; init; }

    /// <summary>
    /// Multiplier for how often this exercise is choosen. Weights the LastSeen date.
    /// </summary>
    public bool Favorite { get; set; }

    /// <summary>
    /// When was this exercise last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    [JsonIgnore]
    public virtual RecipeDto Recipe { get; set; } = null!;

    [JsonIgnore]
    public virtual UserDto User { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId);

    public override bool Equals(object? obj) => obj is UserRecipeDto other
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
