using Core.Models.Newsletter;
using Data.Entities.User;
using Data.Models;
using Data.Query;
using System.Diagnostics;

namespace Data.Dtos.Newsletter;

/// <summary>
/// Viewmodel for _Exercise.cshtml
/// </summary>
[DebuggerDisplay("{Section,nq}: {Variation,nq}")]
public class RecipeDto(Section section, Recipe recipe, UserRecipe? userRecipe) :
    IRecipeCombo
{
    public RecipeDto(QueryResults result) : this(result.Section, result.Recipe, result.UserRecipe)
    {
        Scale = result.Scale;
    }

    public int Scale { get; set; } = 1;

    public Section Section { get; private init; } = section;

    public Recipe Recipe { get; private init; } = recipe;

    public UserRecipe? UserRecipe { get; set; } = userRecipe;

    public override int GetHashCode() => HashCode.Combine(Recipe);

    public override bool Equals(object? obj) => obj is RecipeDto other
        && other.Recipe == Recipe;
}
