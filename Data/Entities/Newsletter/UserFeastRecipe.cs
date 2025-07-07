using Core.Models.Newsletter;
using Data.Query;
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
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserFeastRecipe() { }

    public UserFeastRecipe(UserFeast newsletter, QueryResults queryResults, int order)
    {
        Order = order;
        Scale = queryResults.GetScale;
        Section = queryResults.Section;
        // Don't set Recipe, so that EF Core doesn't add/update Recipe.
        RecipeId = queryResults.Recipe.Id;
        // Don't set UserFeast, so that EF Core doesn't add/update UserFeast.
        UserFeastId = newsletter.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private init; }

    public int Scale { get; private init; }

    public int RecipeId { get; private init; }

    public int UserFeastId { get; private init; }

    /// <summary>
    /// What section of the newsletter is this?
    /// </summary>
    public Section Section { get; private init; }

    /// <summary>
    /// The order of each recipe in each section.
    /// </summary>
    public int Order { get; private init; }


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
