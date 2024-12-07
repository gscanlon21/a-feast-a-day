using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// User's preferences for a recipe.
/// </summary>
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipeDto
{
    public string? Notes { get; init; }
}
