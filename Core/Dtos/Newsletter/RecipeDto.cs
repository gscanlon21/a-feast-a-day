using Core.Dtos.User;
using Core.Models.Newsletter;
using System.Diagnostics;

namespace Core.Dtos.Newsletter;

[DebuggerDisplay("{Section,nq}: {Variation,nq}")]
public class RecipeDtoDto
{
    public int Scale { get; set; } = 1;

    public Section Section { get; init; }

    public RecipeDto Recipe { get; init; } = null!;

    public UserRecipeDto? UserRecipe { get; set; }

    public override int GetHashCode() => HashCode.Combine(Recipe);

    public override bool Equals(object? obj) => obj is RecipeDtoDto other
        && other.Recipe == Recipe;
}
