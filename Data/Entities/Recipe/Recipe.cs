using Core.Consts;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Recipe;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class Recipe
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? UserId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Required, Range(RecipeConsts.ServingsMin, RecipeConsts.ServingsMax)]
    [Display(Name = "Servings")]
    public int Servings { get; set; } = RecipeConsts.ServingsDefault;

    [Display(Name = "Measure")]
    public Measure Measure { get; set; } = Measure.None;

    [Display(Name = "Adjustable Servings")]
    public bool AdjustableServings { get; set; } = true;

    [Required]
    public Equipment Equipment { get; set; }

    [Required]
    public Section Section { get; set; }

    public string? Image { get; set; } = null;

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; set; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.Recipes))]
    public virtual User.User User { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(RecipeIngredient.Recipe))]
    public virtual List<RecipeIngredient> RecipeIngredients { get; set; } = [];

    [JsonIgnore, InverseProperty(nameof(RecipeIngredient.IngredientRecipe))]
    public virtual List<RecipeIngredient> RecipeIngredientRecipes { get; private init; } = null!;

    [JsonInclude, InverseProperty(nameof(RecipeInstruction.Recipe))]
    public virtual IList<RecipeInstruction> Instructions { get; set; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipe.Recipe))]
    public virtual ICollection<UserFeastRecipe> UserFeastRecipes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserRecipe.Recipe))]
    public virtual ICollection<UserRecipe> UserRecipes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserIngredient.SubstituteRecipe))]
    public virtual ICollection<UserIngredient> UserSubstituteRecipes { get; private init; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Recipe other
        && other.Id == Id;

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
