using Data.Entities.Recipe;
using Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A feast's recipe's ingredients.
/// </summary>
[Table("user_feast_recipe_ingredient")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class UserFeastRecipeIngredient
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserFeastRecipeIngredient() { }

    internal UserFeastRecipeIngredient(RecipeIngredientQueryResults recipeIngredient)
    {
        // Don't set RecipeIngredient, so that EF Core doesn't add/update RecipeIngredient.
        RecipeIngredientId = recipeIngredient.Id;
    }


    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public int RecipeIngredientId { get; init; }

    public int UserFeastRecipeId { get; private init; }


    [JsonIgnore, InverseProperty(nameof(Newsletter.UserFeastRecipe.UserFeastRecipeIngredients))]
    public virtual UserFeastRecipe UserFeastRecipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Recipe.RecipeIngredient.UserFeastRecipeIngredients))]
    public virtual RecipeIngredient RecipeIngredient { get; private init; } = null!;


    private string GetDebuggerDisplay()
    {
        if (RecipeIngredient != null)
        {
            return $"{RecipeIngredient}";
        }

        return $"{RecipeIngredientId}";
    }
}
