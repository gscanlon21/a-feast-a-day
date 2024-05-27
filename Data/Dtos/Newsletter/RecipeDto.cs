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
public class RecipeDto :
    IRecipeCombo
{
    public RecipeDto(Section section, UserRecipe exercise, UserUserRecipe? userExercise)
    {
        Section = section;
        Recipe = exercise;
        UserRecipe = userExercise;
    }

    public RecipeDto(QueryResults result) : this(result.Section, result.Recipe, result.UserRecipe) { }

    public Section Section { get; private init; }

    public UserRecipe Recipe { get; private init; } = null!;

    public UserUserRecipe? UserRecipe { get; set; }

    public override int GetHashCode() => HashCode.Combine(Recipe);

    public override bool Equals(object? obj) => obj is RecipeDto other
        && other.Recipe == Recipe;
}
