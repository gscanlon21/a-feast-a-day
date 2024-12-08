namespace Web.Views.Ingredient;

public class UserManageIngredientViewModel
{
    public record Params(string Email, string Token, int RecipeId, int IngredientId);

    public required Params Parameters { get; init; }

    public required bool HasUserIngredient { get; init; }

    public required string Token { get; init; }
    public required Data.Entities.User.User User { get; set; } = null!;
    public required Data.Entities.Ingredient.Ingredient Ingredient { get; set; } = null!;

    public bool? WasUpdated { get; init; }
}
