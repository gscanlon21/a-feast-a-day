using Core.Dtos.Recipe;
using Core.Models.Newsletter;

namespace Core.Dtos.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
public class UserFeastRecipeDto
{
    public UserFeastRecipeDto() { }

    public UserFeastRecipeDto(UserFeastDto newsletter, RecipeDto userRecipe, int scale)
    {
        UserFeastId = newsletter.Id;
        RecipeId = userRecipe.Id;
        Scale = scale;
    }

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
}
