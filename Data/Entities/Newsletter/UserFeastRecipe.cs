using Core.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_feast_recipe"), Comment("A day's workout routine")]
public class UserFeastRecipe
{
    public UserFeastRecipe() { }

    public UserFeastRecipe(UserFeast newsletter, Recipe.Recipe userRecipe, int scale)
    {
        UserFeastId = newsletter.Id;
        RecipeId = userRecipe.Id;
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
}
