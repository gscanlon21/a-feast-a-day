using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Query;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, IList<Nutrient> nutrients, IList<RecipeIngredientQueryResults> recipeIngredients, UserRecipe? userRecipe, int scale) : IRecipeCombo
{
    public IList<Nutrient> Nutrients { get; init; } = nutrients;
    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = recipeIngredients;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public int Scale { get; set; } = scale;

    public override int GetHashCode() => HashCode.Combine(Recipe.Id);

    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Recipe.Id == Recipe.Id;
}

public class RecipeIngredientQueryResults(RecipeIngredient recipeIngredient)
{
    public int Id { get; init; } = recipeIngredient.Id;
    public Measure Measure { get; init; } = recipeIngredient.Measure;
    public bool Optional { get; init; } = recipeIngredient.Optional;
    public bool SkipShoppingList { get; init; } = recipeIngredient.SkipShoppingList;
    public int QuantityNumerator { get; set; } = recipeIngredient.QuantityNumerator;
    public int QuantityDenominator { get; init; } = recipeIngredient.QuantityDenominator;
    public Ingredient? Ingredient { get; set; } = recipeIngredient.Ingredient;
    public Recipe? IngredientRecipe { get; init; } = recipeIngredient.IngredientRecipe;
    public UserIngredient? UserIngredient { get; set; }
    public UserRecipe? UserIngredientRecipe { get; set; }
    public string Name { get; init; } = null!;
}