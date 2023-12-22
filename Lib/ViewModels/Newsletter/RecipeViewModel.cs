using Core.Models.Newsletter;
using Core.Models.User;
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

    public RecipeType Type { get; init; }

    [Display(Name = "Prep Time")]
    public int PrepTime { get; set; }

    [Display(Name = "Cook Time")]
    public int CookTime { get; set; }

    [Display(Name = "Servings")]
    public int Servings { get; set; }

    [JsonInclude]
    public List<InstructionViewModel> Instructions { get; init; } = [];

    [JsonInclude]
    public List<IngredientViewModel> Ingredients { get; init; } = [];

    public bool UserFirstTimeViewing { get; init; } = false;
}
