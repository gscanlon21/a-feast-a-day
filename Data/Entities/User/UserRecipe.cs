using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User's preferences for a recipe.
/// </summary>
[Table("user_recipe")]
[DebuggerDisplay("UserId: {UserId}, RecipeId: {RecipeId}")]
public class UserRecipe
{
    [Required]
    public required int UserId { get; init; }

    [Required]
    public required int RecipeId { get; init; }

    // Don't set Section on UserRecipe!
    // Things don't play well (like ignoring recipes).
    // If we really need to manage recipes per Section,
    // ... them add a new UserRecipeSection and use that for section specific properties
    // ... or make that property only apply for the Section(like UserRecipeRefresh.Section).
    //public required Section Section { get; init; }

    public string? Notes { get; set; }

    /// <summary>
    /// Don't show this recipe to the user.
    /// </summary>
    public DateOnly? IgnoreUntil { get; set; }

    /// <summary>
    /// When was this recipe last seen in the user's newsletter.
    /// </summary>
    public DateOnly? LastSeen { get; set; }

    /// <summary>
    /// If this is set, will not update the LastSeen date until this date is reached.
    /// This is so we can reduce the variation of feasts and show the same groups of recipes for a month+ straight.
    /// </summary>
    public DateOnly? RefreshAfter { get; set; }

    /// <summary>
    /// Add a delay before this recipe is removed from your feasts.
    /// </summary>
    [Required, Range(UserConsts.LagRefreshXWeeksMin, UserConsts.LagRefreshXWeeksMax)]
    public int LagRefreshXWeeks { get; set; } = UserConsts.LagRefreshXWeeksDefault;

    /// <summary>
    /// Add a delay before this recipe is added back into your feasts.
    /// </summary>
    [Required, Range(UserConsts.PadRefreshXWeeksMin, UserConsts.PadRefreshXWeeksMax)]
    public int PadRefreshXWeeks { get; set; } = UserConsts.PadRefreshXWeeksDefault;

    [Required, Range(RecipeConsts.ServingsMin, RecipeConsts.ServingsMax)]
    public int Servings { get; set; } = RecipeConsts.ServingsDefault;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.UserRecipes))]
    public virtual Recipe.Recipe Recipe { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserRecipes))]
    public virtual User User { get; private init; } = null!;

    #endregion


    public override int GetHashCode() => HashCode.Combine(UserId, RecipeId);
    public override bool Equals(object? obj) => obj is UserRecipe other
        && other.RecipeId == RecipeId
        && other.UserId == UserId;
}
