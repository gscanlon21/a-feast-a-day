namespace Web.Views.RecipeIngredient;

public class UserManageRecipeIngredientViewModel
{
    public record Params(string Email, string Token, int RecipeIngredientId);

    public required Params Parameters { get; init; }

    public required string Token { get; init; }
    public required Data.Entities.User.User User { get; set; } = null!;
    public required Data.Entities.Recipe.RecipeIngredient RecipeIngredient { get; set; } = null!;

    public bool? WasUpdated { get; init; }
}
