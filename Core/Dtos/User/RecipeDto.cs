using Core.Consts;
using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeDto
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

    [Required]
    public Allergy Allergens { get; set; }

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; set; } = null;

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
