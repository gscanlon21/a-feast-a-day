using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's progression level of an exercise.
/// </summary>
[Table("user_recipe")]
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipe
{
    [Required]
    public required int UserId { get; init; }

    [Required]
    public required int RecipeId { get; init; }

    [Required]
    public required Section Section { get; init; }

    [Required, Range(RecipeConsts.ServingsMin, RecipeConsts.ServingsMax)]
    public int Servings { get; set; } = RecipeConsts.ServingsDefault;

    public string? Notes { get; set; }

    /// <summary>
    /// Don't show this recipe to the user.
    /// </summary>
    public DateOnly? IgnoreUntil { get; set; }

    /// <summary>
    /// When was this recipe last seen in the user's newsletter.
    /// </summary>
    [Required]
    public DateOnly LastSeen { get; set; }

    /// <summary>
    /// If this is set, will not update the LastSeen date until this date is reached.
    /// This is so we can reduce the variation of feasts and show the same groups of recipes for a month+ straight.
    /// </summary>
    public DateOnly? RefreshAfter { get; set; }

    /// <summary>
    /// How often to refresh recipes.
    /// </summary>
    [Required, Range(UserConsts.LagRefreshXWeeksMin, UserConsts.LagRefreshXWeeksMax)]
    public int LagRefreshXWeeks { get; set; } = UserConsts.LagRefreshXWeeksDefault;

    /// <summary>
    /// How often to refresh recipes.
    /// </summary>
    [Required, Range(UserConsts.PadRefreshXWeeksMin, UserConsts.PadRefreshXWeeksMax)]
    public int PadRefreshXWeeks { get; set; } = UserConsts.PadRefreshXWeeksDefault;


    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.UserRecipes))]
    public virtual Recipe.Recipe Recipe { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserRecipes))]
    public virtual User User { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, Section, RecipeId);
    public override bool Equals(object? obj) => obj is UserRecipe other
        && other.RecipeId == RecipeId
        && other.Section == Section
        && other.UserId == UserId;
}
