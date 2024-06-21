namespace Web.Views.Shared.Components.Recipe;

public class RecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public Data.Entities.User.Recipe Recipe { get; set; } = null!;

    public IList<Data.Entities.User.Ingredient> Ingredients { get; init; } = [];
}
