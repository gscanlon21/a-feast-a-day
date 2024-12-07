using Core.Dtos.Recipe;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.Newsletter;

[DebuggerDisplay("{Section,nq}: {Variation,nq}")]
public class NewsletterRecipeDto
{
    public Section Section { get; init; }

    [JsonInclude]
    public RecipeDto Recipe { get; init; } = null!;

    [JsonInclude]
    public UserRecipeDto? UserRecipe { get; set; }

    [JsonInclude]
    public IList<RecipeIngredientDto> RecipeIngredients { get; init; } = [];

    public override int GetHashCode() => HashCode.Combine(Recipe);
    public override bool Equals(object? obj) => obj is NewsletterRecipeDto other
        && other.Recipe == Recipe;
}
