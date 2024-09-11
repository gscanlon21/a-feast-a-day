using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A feast's recipes.
/// </summary>
[Table("user_feast_recipe")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class UserFeastRecipe
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserFeastRecipe() { }

    public UserFeastRecipe(UserFeast newsletter, Recipe.Recipe recipe, int scale)
    {
        // Don't set UserFeast, so that EF Core doesn't add/update UserFeast.
        UserFeastId = newsletter.Id;
        // Don't set Recipe, so that EF Core doesn't add/update Recipe.
        RecipeId = recipe.Id;
        Scale = scale;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public int Scale { get; private init; }

    public int UserFeastId { get; private init; }

    public int RecipeId { get; private init; }

    /// <summary>
    /// The order of each exercise in each section.
    /// </summary>
    public int Order { get; init; }

    /// <summary>
    /// What section of the newsletter is this?
    /// </summary>
    public Section Section { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.Recipe.Recipe.UserFeastRecipes))]
    public virtual Recipe.Recipe Recipe { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Newsletter.UserFeast.UserFeastRecipes))]
    public virtual UserFeast UserFeast { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipeIngredient.UserFeastRecipe))]
    public virtual ICollection<UserFeastRecipeIngredient> UserFeastRecipeIngredients { get; init; } = null!;

    private string GetDebuggerDisplay()
    {
        if (Recipe != null)
        {
            return $"{Order}: {Recipe} - {Scale}";
        }

        return $"{Order}: {RecipeId} - {Scale}";
    }
}
