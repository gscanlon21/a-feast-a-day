using Core.Models.User;

namespace Web.Views.UserIngredients;

public class UserManageIngredientViewModel
{
    public record Params(string Email, string Token, int IngredientId);

    public bool? WasUpdated { get; init; }

    public required Params Parameters { get; init; }

    public required Data.Entities.Users.User User { get; set; } = null!;

    public required Data.Entities.Ingredients.Ingredient Ingredient { get; set; } = null!;

    /// <summary>
    /// User must have created the ingredient to be able to edit it.
    /// </summary>
    public bool CanManage => Ingredient.UserId == User.Id || User.Features.HasFlag(Features.Admin);
}
