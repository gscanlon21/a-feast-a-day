using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Recipe;

/// <summary>
/// DTO class for Recipe.cs
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeDto
{
    public int Id { get; init; }

    public Section Section { get; set; }

    public Equipment Equipment { get; set; }

    public string? Image { get; set; } = null;

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

    [Display(Name = "Measure")]
    public Measure Measure { get; set; } = Measure.None;

    [Display(Name = "Adjustable Servings")]
    public bool AdjustableServings { get; set; }

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    [JsonInclude]
    public virtual IList<RecipeInstructionDto> Instructions { get; set; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeDto other
        && other.Id == Id;
}
