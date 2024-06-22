using Core.Dtos.Recipe;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Dtos.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_feast_recipe")]
public class UserFeastRecipeDto
{
    public UserFeastRecipeDto() { }

    public UserFeastRecipeDto(UserFeastDto newsletter, RecipeDto userRecipe, int scale)
    {
        UserFeastId = newsletter.Id;
        RecipeId = userRecipe.Id;
        Scale = scale;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int Scale { get; init; }

    public int UserFeastId { get; init; }

    public int RecipeId { get; init; }

    /// <summary>
    /// The order of each exercise in each section.
    /// </summary>
    public int Order { get; init; }

    /// <summary>
    /// What section of the newsletter is this?
    /// </summary>
    public Section Section { get; init; }

    [JsonIgnore]
    public virtual RecipeDto Recipe { get; init; } = null!;

    [JsonIgnore]
    public virtual UserFeastDto UserFeast { get; init; } = null!;
}
