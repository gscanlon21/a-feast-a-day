using Core.Models.Newsletter;
using Lib.ViewModels.User;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.Newsletter;

/// <summary>
/// Viewmodel for _Exercise.cshtml
/// </summary>
[DebuggerDisplay("{Exercise,nq}: {Variation,nq}")]
public class NewsletterRecipeViewModel
{
    public Section Section { get; init; }

    public RecipeViewModel Recipe { get; init; } = null!;

    [JsonInclude]
    public UserExerciseViewModel? UserRecipe { get; set; }

    public bool UserFirstTimeViewing { get; init; } = false;

    public override int GetHashCode() => HashCode.Combine(Recipe);

    public override bool Equals(object? obj) => obj is NewsletterRecipeViewModel other
        && other.Recipe == Recipe;
}
