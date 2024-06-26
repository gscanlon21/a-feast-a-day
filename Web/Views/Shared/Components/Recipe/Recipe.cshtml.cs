namespace Web.Views.Shared.Components.Recipe;

public class RecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public Data.Entities.Recipe.Recipe Recipe { get; set; } = null!;

    public IList<Data.Entities.Ingredient.Ingredient> Ingredients { get; init; } = [];
    public IList<Data.Entities.Recipe.Recipe> Recipes { get; init; } = [];
}
