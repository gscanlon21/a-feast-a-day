using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Interfaces.Recipe;
using Fractions;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Query;

[DebuggerDisplay("{Section}: {Recipe}")]
public class QueryResults(Section section, Recipe recipe, IList<RecipeIngredientQueryResults> recipeIngredients, UserRecipe? userRecipe) : IRecipeCombo
{
    private double _scale = 1;

    public Section Section { get; init; } = section;
    public Recipe Recipe { get; init; } = recipe;
    public UserRecipe? UserRecipe { get; init; } = userRecipe;
    public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = recipeIngredients;
    public IList<Nutrient> Nutrients => RecipeIngredients
        .Where(ri => ri.Type == RecipeIngredientType.Ingredient)
        .SelectMany(ri => ri.GetIngredient!.Nutrients)
        .ToList();

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
    internal IDictionary<QueryResults, List<RecipeIngredientQueryResults>> PrerequisiteRecipes => RecipeIngredients
        .Where(ri => ri.IngredientRecipe != null).GroupBy(ri => ri.IngredientRecipe)
        .ToDictionary(ir => ir.Key!, ir => ir.ToList());

    /// <summary>
    /// Includes prerequisite recipe nutrients.
    /// Only includes nutrients with a value.
    /// </summary>
    [JsonIgnore]
    internal List<Nutrients> UniqueWorkedNutrients =>
    [
        .. Nutrients.Where(n => n.Value > 0).Select(n => n.Nutrients).Distinct(),
        .. PrerequisiteRecipes.SelectMany(pr => pr.Key.Nutrients).Where(n => n.Value > 0).Select(n => n.Nutrients).Distinct(),
    ];

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
    public required Measure Measure { get; set; }
    public required string? Attributes { get; set; }
    public required int QuantityNumerator { get; set; }
    public required int QuantityDenominator { get; set; }
    public required int? RawIngredientRecipeId { get; init; }
    public bool IsUnwantedAndHasAlternatives { get; set; }

    public QueryResults? IngredientRecipe { get; internal set; }
    public required UserRecipe? UserRecipe { get; set; }

    public required Ingredient? Ingredient { get; set; }
    public required UserRecipeIngredient? UserRecipeIngredient { get; set; }

    // These are getters so when the Ingredient is substituted, or quantity is scaled, they are still accurate.
    public int? IngredientRecipeId => UserRecipeIngredient?.SubstituteRecipeId ?? RawIngredientRecipeId;
    public string Name => IngredientRecipe?.Recipe.Name ?? Ingredient?.Name ?? "";
    public Fraction Quantity => new(QuantityNumerator, QuantityDenominator);
    public bool SkipShoppingList => Ingredient?.SkipShoppingList ?? false;

    /// <summary>
    /// The number of grams this ingredient weights.
    /// </summary>
    internal double Weight => (Ingredient != null ? Measure.ToGramsWithContext(Ingredient) : 1) * Quantity.ToDouble();

    public Measure GetMeasure => Measure;
    public Ingredient? GetIngredient => Ingredient;
    public double GetQuantity => Quantity.ToDouble();

    /// <summary>
    /// Is this recipe's ingredient an ingredient or a recipe?
    /// </summary>
    /// Public so that the dto can bind this.
    public RecipeIngredientType Type => (UserRecipeIngredient?.SubstituteIngredientId, UserRecipeIngredient?.SubstituteRecipeId, Ingredient, IngredientRecipeId) switch
    {
        (not null, _, _, _) => RecipeIngredientType.Ingredient,
        (_, not null, _, _) => RecipeIngredientType.IngredientRecipe,
        (_, _, not null, _) => RecipeIngredientType.Ingredient,
        (_, _, _, not null) => RecipeIngredientType.IngredientRecipe,
        _ => RecipeIngredientType.None,
    };

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is RecipeIngredientQueryResults other && other.Id == Id;
}