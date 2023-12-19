using Core.Models.Newsletter;
using Lib.ViewModels.User;
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

    [JsonInclude]
    public List<InstructionViewModel> Instructions { get; init; } = [];

    [JsonInclude]
    public List<IngredientViewModel> Ingredients { get; init; } = [];

    public bool UserFirstTimeViewing { get; init; } = false;
}
