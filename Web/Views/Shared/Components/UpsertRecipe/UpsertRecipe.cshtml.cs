using Core.Consts;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Web.Views.Shared.Components.UpsertRecipe;

public class UpsertRecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UpsertRecipeModel Recipe { get; set; } = null!;

    public IList<Data.Entities.Ingredient.Ingredient> Ingredients { get; init; } = [];
    public IList<Data.Entities.Recipe.Recipe> Recipes { get; init; } = [];
}

public class UpsertRecipeModel : IValidatableObject
{
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

    [JsonInclude, ValidateNever]
    public IList<RecipeIngredient> RecipeIngredients { get; set; } = [];

    [JsonInclude, ValidateNever]
    public IList<RecipeInstruction> Instructions { get; set; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UpsertRecipeModel other
        && other.Id == Id;

    [NotMapped]
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        foreach (var recipeIngredient in RecipeIngredients.Where(ri => !ri.Hide))
        {
            if (recipeIngredient.IngredientId.HasValue && recipeIngredient.IngredientRecipeId.HasValue)
            {
                yield return new ValidationResult($"Both Ingredient and Recipe cannot have values.", [nameof(RecipeIngredients)]);
            }
        }
    }
}
