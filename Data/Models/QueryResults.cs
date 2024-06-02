using Core.Models.Newsletter;
using Data.Entities.User;
using Data.Query;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, UserRecipe? userRecipe, int scale) : IRecipeCombo
{
    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public int Scale { get; set; } = scale;

    public override int GetHashCode() => HashCode.Combine(Recipe.Id);

    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Recipe.Id == Recipe.Id;
}