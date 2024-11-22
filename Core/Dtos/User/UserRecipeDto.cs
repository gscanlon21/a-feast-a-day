using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// User's preferences for a recipe.
/// </summary>
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipeDto
{
    public int RecipeId { get; init; }

    public int UserId { get; init; }

    public int Scale { get; set; } = 1;

    public string? Notes { get; init; }

    /// <summary>
    /// When was this recipe last seen in the user's newsletter.
    /// </summary>
    public DateOnly LastSeen { get; set; }

    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId);
    public override bool Equals(object? obj) => obj is UserRecipeDto other
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
