using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Query;
using Fractions;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, IList<Nutrient> nutrients, IList<RecipeIngredientQueryResults> recipeIngredients, UserRecipe? userRecipe, int scale) : IRecipeCombo
{
    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public IList<Nutrient> Nutrients { get; init; } = nutrients;
    public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = recipeIngredients;
    public int Scale { get; set; } = scale;

    public override int GetHashCode() => HashCode.Combine(Recipe.Id);

    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Recipe.Id == Recipe.Id;
}

public class RecipeIngredientQueryResults(RecipeIngredient recipeIngredient)
{
    public int Id { get; init; } = recipeIngredient.Id;
    public Measure Measure { get; init; } = recipeIngredient.Measure;
    public bool SkipShoppingList { get; init; } = recipeIngredient.SkipShoppingList;
    public int QuantityNumerator { get; set; } = recipeIngredient.QuantityNumerator;
    public int QuantityDenominator { get; init; } = recipeIngredient.QuantityDenominator;
    public Ingredient? Ingredient { get; set; } = recipeIngredient.Ingredient;
    public int? IngredientRecipeId { get; set; } = recipeIngredient.IngredientRecipeId;

    // We don't .Include these or we use these later in the query so they can't be set in the constructor.
    public required bool Optional { get; init; }
    public required UserIngredient? UserIngredient { get; set; }
    public required UserRecipe? UserIngredientRecipe { get; set; }

    // These are getters so when the Ingredient is substituted, or quantity is scaled, they are still accurate.
    public string IngredientRecipeName { get; set; }
    public string Name => Ingredient?.Name ?? IngredientRecipeName ?? "";
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);
}