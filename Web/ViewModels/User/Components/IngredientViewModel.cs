using Data.Entities.User;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class IngredientViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;
    public required Data.Entities.User.Ingredient Ingredient { get; set; } = null!;

    public required IList<Nutrient> Nutrients { get; set; }
}
