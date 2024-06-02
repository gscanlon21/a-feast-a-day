using Lib.ViewModels.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipeViewModel
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
    /// When was this exercise last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    [JsonInclude]
    public InstructionViewModel Exercise { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId);

    public override bool Equals(object? obj) => obj is UserRecipeViewModel other
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
