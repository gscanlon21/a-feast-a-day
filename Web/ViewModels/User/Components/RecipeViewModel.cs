using Data.Entities.User;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class RecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public Data.Entities.User.Recipe Recipe { get; set; } = null!;

    public List<UserIngredient> Ingredients { get; init; } = [];
}
