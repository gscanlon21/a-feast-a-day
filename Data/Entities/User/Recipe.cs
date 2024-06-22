using Core.Consts;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

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

    [Display(Name = "Adjustable Servings")]
    public bool AdjustableServings { get; set; }

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
    public virtual User User { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(RecipeIngredient.Recipe))]
    public virtual IList<RecipeIngredient> RecipeIngredients { get; set; } = [];

    [JsonInclude, InverseProperty(nameof(RecipeInstruction.Recipe))]
    public virtual IList<RecipeInstruction> Instructions { get; set; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipe.Recipe))]
    public virtual ICollection<UserFeastRecipe> UserFeastRecipes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserRecipe.Recipe))]
    public virtual ICollection<UserRecipe> UserRecipes { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is Recipe other
        && other.Id == Id;

    [NotMapped, Required]
    public Section[]? SectionBinder
    {
        get => Enum.GetValues<Section>().Where(e => Section.HasFlag(e)).ToArray();
        set => Section = value?.Aggregate(Section.None, (a, e) => a | e) ?? Section.None;
    }

    [NotMapped]
    public Equipment[]? EquipmentBinder
    {
        get => Enum.GetValues<Equipment>().Where(e => Equipment.HasFlag(e)).ToArray();
        set => Equipment = value?.Aggregate(Equipment.None, (a, e) => a | e) ?? Equipment.None;
    }

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }
}
