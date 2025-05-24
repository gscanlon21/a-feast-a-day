using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Interfaces.Recipe;
using Fractions;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Query;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, IList<Nutrient> nutrients, IList<RecipeIngredientQueryResults> recipeIngredients, UserRecipe? userRecipe) : IRecipeCombo
{
    private double _scale = 1;

    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public IList<Nutrient> Nutrients { get; init; } = nutrients;
    public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = recipeIngredients;

    /// <summary>
    /// Rounded scale.
    /// </summary>
    public int GetScale => (int)Math.Ceiling(_scale);

    /// <summary>
    /// Precise scale.
    /// </summary>
    internal double SetScale
    {
        get => _scale;
        set
        {
            var newScale = (int)Math.Ceiling(value);
            if (newScale != GetScale)
            {
                // Scale the servings.
                Recipe.Servings *= newScale;
                Recipe.Servings /= GetScale;

                // Scale the recipe ingredient quantities.
                foreach (var ingredient in RecipeIngredients)
                {
                    ingredient.QuantityNumerator *= newScale;
                    ingredient.QuantityNumerator /= GetScale;
                }
            }

            _scale = value;
        }
    }

    /// <summary>
    /// Distinct ingredient recipes with the group's quantities summed.
    /// </summary>
    [JsonIgnore]
    internal IDictionary<QueryResults, double> PrerequisiteRecipes => RecipeIngredients
        .Where(ri => ri.IngredientRecipe != null).GroupBy(ri => ri.IngredientRecipe)
        .ToDictionary(ir => ir.Key!, ir => ir.Sum(r => r.Measure.ToGramsOrMilliliters(r.Quantity.ToDouble())));

    /// <summary>
    /// Included prerequisite recipe nutrients.
    /// </summary>
    [JsonIgnore]
    internal List<Nutrient> AllNutrients => [.. Nutrients, .. PrerequisiteRecipes.SelectMany(pr => pr.Key.Nutrients)];

    public override int GetHashCode() => HashCode.Combine(Recipe.Id);
    public override bool Equals(object? obj) => obj is QueryResults other
        && other.Recipe.Id == Recipe.Id;
}

[DebuggerDisplay("{Id}: {Name}")]
public class RecipeIngredientQueryResults : IRecipeIngredient
{
    public required int Id { get; init; }
    public required int Order { get; init; }
    public required bool Optional { get; init; }
    public required Measure Measure { get; init; }
    public required string? Attributes { get; init; }
    public required int QuantityNumerator { get; set; }
    public required int QuantityDenominator { get; set; }
    public required int? RawIngredientRecipeId { get; init; }

    public required UserRecipe? UserIngredientRecipe { get; set; }
    public QueryResults? IngredientRecipe { get; internal set; }

    public required UserIngredient? UserIngredient { get; set; }
    public required Ingredient? Ingredient { get; set; }

    // These are getters so when the Ingredient is substituted, or quantity is scaled, they are still accurate.
    public int? IngredientRecipeId => UserIngredient?.SubstituteRecipeId ?? RawIngredientRecipeId;
    public string Name => IngredientRecipe?.Recipe.Name ?? Ingredient?.Name ?? "";
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);
    public bool SkipShoppingList => Ingredient?.SkipShoppingList ?? false;

    internal double Size => ((Ingredient != null && Measure != Measure.None) ? Measure.ToGramsWithContext(Ingredient) : 1) * Quantity.ToDouble();
    internal RecipeIngredientType Type => (UserIngredient?.SubstituteIngredientId, UserIngredient?.SubstituteRecipeId, Ingredient, IngredientRecipeId) switch
    {
        (not null, _, _, _) => RecipeIngredientType.Ingredient,
        (_, not null, _, _) => RecipeIngredientType.IngredientRecipe,
        (_, _, not null, _) => RecipeIngredientType.Ingredient,
        (_, _, _, not null) => RecipeIngredientType.IngredientRecipe,
        _ => throw new InvalidOperationException("Missing ingredient or recipe."),
    };

    public Measure GetMeasure => Measure;
    public Ingredient? GetIngredient => Ingredient;
    public double GetQuantity => Quantity.ToDouble();
    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientQueryResults other && other.Id == Id;
}

public enum RecipeIngredientType
{
    IngredientRecipe,
    Ingredient,
}