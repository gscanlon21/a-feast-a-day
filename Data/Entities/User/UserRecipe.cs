using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("user_recipe"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Name,nq}")]
public class UserRecipe
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; private init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Display(Name = "Servings")]
    public int Servings { get; set; }

    [Required]
    public RecipeType Type { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserRecipes))]
    public virtual User User { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(UserRecipeIngredient.Recipe))]
    public virtual IList<UserRecipeIngredient> Ingredients { get; set; } = null!;

    [JsonInclude, InverseProperty(nameof(UserRecipeInstruction.Recipe))]
    public virtual IList<UserRecipeInstruction> Instructions { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is UserRecipe other
        && other.Id == Id;

    [NotMapped]
    public RecipeType[]? TypeBinder
    {
        get => Enum.GetValues<RecipeType>().Where(e => Type.HasFlag(e)).ToArray();
        set => Type = value?.Aggregate(RecipeType.None, (a, e) => a | e) ?? RecipeType.None;
    }
}
