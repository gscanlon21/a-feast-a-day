using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Recipes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Web.Views.Shared.Components.UpsertRecipe;

public class UpsertRecipeViewModel
{
    public Section Section { get; init; }
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public UpsertRecipeModel Recipe { get; set; } = null!;

    public IList<SelectListItem> RecipeSelect { get; init; } = [];
    public IList<SelectListItem> IngredientSelect { get; init; } = [];
    public IList<SelectListItem> CookedIngredientSelect { get; init; } = [];
    public IList<SelectListItem> CookedScaleSelect { get; init; } = [];

    [ValidateNever]
    public bool Editing => Recipe != null && Recipe.Id != default;
}

public class UpsertRecipeModel : IValidatableObject
{
    public int Id { get; init; }

    [Required]
    [Display(Name = "Section")]
    public Section Section { get; set; }

    [Display(Name = "Measure")]
    public Measure Measure { get; set; } = Measure.None;

    [Required]
    public string Name { get; set; } = null!;

    public string? Link { get; set; } = null;

    /// <summary>
    /// Notes about the recipe (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Required, Range(RecipeConsts.ServingsMin, RecipeConsts.ServingsMax)]
    [Display(Name = "Servings")]
    public int Servings { get; set; } = RecipeConsts.ServingsDefault;

    [Display(Name = "Adjustable Servings")]
    public bool AdjustableServings { get; set; } = true;

    [Display(Name = "Base Recipe")]
    public bool BaseRecipe { get; set; } = false;

    [Display(Name = "Keep Ingredient Order")]
    public bool KeepIngredientOrder { get; set; } = false;

    public string? DisabledReason { get; set; } = null;

    [JsonInclude, ValidateNever]
    public IList<RecipeInstruction> Instructions { get; set; } = [];

    [JsonInclude, ValidateNever]
    public IList<Data.Entities.Recipes.RecipeIngredient> RecipeIngredients { get; set; } = [];

    [NotMapped]
    public Section[]? SectionBinder
    {
        get => Enum.GetValues<Section>().Where(e => Section.HasFlag(e)).ToArray();
        set => Section = value?.Aggregate(Section.None, (a, e) => a | e) ?? Section.None;
    }

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!BaseRecipe && Section == Section.None)
        {
            yield return new ValidationResult($"Section cannot be null when not a base recipe.", [nameof(Section), nameof(BaseRecipe)]);
        }

        if (RecipeIngredients.Where(ri => !ri.Hide).GroupBy(ri => ri.Order).Any(g => g.Count() > 1))
        {
            yield return new ValidationResult($"Two ingredients cannot have the same order.", [nameof(RecipeIngredients)]);
        }

        foreach (var recipeIngredient in RecipeIngredients.Where(ri => !ri.Hide))
        {
            if (recipeIngredient.IngredientId.HasValue && recipeIngredient.IngredientRecipeId.HasValue)
            {
                yield return new ValidationResult($"Both the Ingredient and the Recipe cannot have values.", [nameof(RecipeIngredients)]);
            }

            if (!recipeIngredient.IngredientId.HasValue && !recipeIngredient.IngredientRecipeId.HasValue)
            {
                yield return new ValidationResult($"Either the Ingredient or the Recipe must have a value.", [nameof(RecipeIngredients)]);
            }
        }
    }
}
