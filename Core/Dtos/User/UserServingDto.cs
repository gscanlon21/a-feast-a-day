using Core.Models.Newsletter;

namespace Core.Dtos.User;

public class UserServingDto
{
    public Section Section { get; init; }

    public int UserId { get; init; }

    public int Count { get; init; }

    public int AtLeastXNutrientsPerRecipe { get; init; }

    public int AtLeastXServingsPerRecipe { get; init; }

}
