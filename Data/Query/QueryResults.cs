using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Query;
using Fractions;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Models;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, IList<Nutrient> nutrients, IList<RecipeIngredientQueryResults> recipeIngredients, UserRecipe? userRecipe) : IRecipeCombo
{
    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public IList<Nutrient> Nutrients { get; init; } = nutrients;
    public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = recipeIngredients;

    private int _scale = 1;
    public int Scale
    {
        get => _scale;
        internal set
        {
            // Scale the servings.
            Recipe.Servings *= value;
            Recipe.Servings /= _scale;

            // Scale the recipe ingredient quantities.
            foreach (var ingredient in RecipeIngredients)
            {
                ingredient.QuantityNumerator *= value;
                ingredient.QuantityNumerator /= _scale;
            }

            _scale = value;
        }
    }

    /// <summary>
    /// Distinct ingredient recipes with the group's quantities summed.
    /// </summary>
    [JsonIgnore]
    public IDictionary<QueryResults, double> PrerequisiteRecipes => RecipeIngredients
        .Where(ri => ri.IngredientRecipe != null).GroupBy(ri => ri.IngredientRecipe)
        .ToDictionary(ir => ir.Key!, ir => ir.Sum(r => r.Measure.ToGramsOrMilliliters(r.Quantity.ToDouble())));

    public override int GetHashCode() => HashCode.Combine(Recipe.Id);
    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Recipe.Id == Recipe.Id;
}

public class RecipeIngredientQueryResults(RecipeIngredient recipeIngredient)
{
    public int Id { get; init; } = recipeIngredient.Id;
    public Measure Measure { get; init; } = recipeIngredient.Measure;
    public string? Attributes { get; init; } = recipeIngredient.Attributes;
    public bool SkipShoppingList { get; init; } = recipeIngredient.SkipShoppingList;
    public int QuantityNumerator { get; set; } = recipeIngredient.QuantityNumerator;
    public int QuantityDenominator { get; init; } = recipeIngredient.QuantityDenominator;
    public Ingredient? Ingredient { get; internal set; } = recipeIngredient.Ingredient;
    public int? IngredientRecipeId { get; internal set; } = recipeIngredient.IngredientRecipeId;

    // We don't .Include these or we use these later in the query so they can't be set in the constructor.
    public required bool Optional { get; init; }
    public required UserIngredient? UserIngredient { get; set; }
    public required UserRecipe? UserIngredientRecipe { get; set; }

    // These are getters so when the Ingredient is substituted, or quantity is scaled, they are still accurate.
    public string Name => Ingredient?.Name ?? IngredientRecipe?.Recipe.Name ?? "";
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);

    public QueryResults? IngredientRecipe { get; internal set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientQueryResults other
        && other.Id == Id;
}