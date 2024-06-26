using Core.Consts;
using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeDto
{
    public int Id { get; init; }

    public int? UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    public string Name { get; set; } = null!;

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Display(Name = "Servings")]
    public int Servings { get; set; } = RecipeConsts.ServingsDefault;

    [Display(Name = "Adjustable Servings")]
    public bool AdjustableServings { get; set; }

    public Equipment Equipment { get; set; }

    public Section Section { get; set; }

    public Allergy Allergens { get; set; }

    public string? Image { get; set; } = null;

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; set; } = null;

    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }

    [JsonIgnore]
    public virtual UserDto User { get; set; } = null!;

    [JsonInclude]
    public virtual IList<RecipeIngredientDto> RecipeIngredients { get; set; } = [];

    [JsonInclude]
    public virtual IList<RecipeInstructionDto> Instructions { get; set; } = [];

    [JsonIgnore]
    public virtual ICollection<UserFeastRecipeDto> UserFeastRecipes { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserRecipeDto> UserRecipes { get; init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeDto other
        && other.Id == Id;
}
