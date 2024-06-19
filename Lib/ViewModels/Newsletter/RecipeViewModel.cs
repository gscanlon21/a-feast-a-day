using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.Newsletter;

/// <summary>
/// Viewmodel for _Exercise.cshtml
/// </summary>
[DebuggerDisplay("{Exercise,nq}: {Variation,nq}")]
public class RecipeViewModel
{
    public int Id { get; init; }

    public Section Section { get; init; }

    public string Name { get; init; } = null!;

    public string Notes { get; init; } = null!;

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Display(Name = "Servings")]
    public int Servings { get; set; }

    public bool AdjustableServings { get; set; }

    [JsonInclude]
    public List<RecipeInstructionViewModel> Instructions { get; init; } = [];

    [JsonInclude]
    public List<RecipeIngredientViewModel> RecipeIngredients { get; init; } = [];

    public bool UserFirstTimeViewing { get; init; } = false;
}
