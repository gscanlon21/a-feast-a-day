namespace Web.ViewModels.User;

/// <summary>
/// Viewmodel for All.cshtml
/// </summary>
public class ManageIngredientViewModel
{
    public ManageIngredientViewModel() { }

    public bool? WasUpdated { get; init; }

    public required string Token { get; init; }
    public required Data.Entities.User.User User { get; set; } = null!;
    public required Data.Entities.User.Ingredient Ingredient { get; set; } = null!;
}
