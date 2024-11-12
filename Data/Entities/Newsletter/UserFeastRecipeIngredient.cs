using Core.Models.User;
using Data.Interfaces.Recipe;
using Data.Query;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A feast's recipe's ingredients.
/// 
/// Recipe ingredient recipes are logged as separate user_feast_recipe entities, 
/// ... so we only care about ingredients. This way we also track user substitutions.
/// </summary>
[Table("user_feast_recipe_ingredient")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class UserFeastRecipeIngredient : IRecipeIngredient
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserFeastRecipeIngredient() { }

    internal UserFeastRecipeIngredient(RecipeIngredientQueryResults recipeIngredient)
    {
        Measure = recipeIngredient.Measure;
        Quantity = recipeIngredient.Quantity.ToDouble();
        // Don't set Ingredient, so that EF Core doesn't add/update Ingredient.
        IngredientId = recipeIngredient.Ingredient!.Id;
    }


    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public int IngredientId { get; init; }

    public Measure Measure { get; private init; }

    /// <summary>
    /// This value is set after recipe scaling is applied.
    /// </summary>
    public double Quantity { get; private init; } = 1;

    public int UserFeastRecipeId { get; private init; }


    [JsonIgnore, InverseProperty(nameof(Newsletter.UserFeastRecipe.UserFeastRecipeIngredients))]
    public virtual UserFeastRecipe UserFeastRecipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Ingredient.Ingredient.UserFeastRecipeIngredients))]
    public virtual Ingredient.Ingredient Ingredient { get; private init; } = null!;

    [NotMapped]
    public double GetQuantity => Quantity;

    [NotMapped]
    public Measure GetMeasure => Measure;

    [NotMapped]
    public Ingredient.Ingredient? GetIngredient => Ingredient;

    private string GetDebuggerDisplay()
    {
        if (Ingredient != null)
        {
            return $"{Ingredient}";
        }

        return $"{IngredientId}";
    }
}
