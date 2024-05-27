using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class IngredientViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    [Display(Name = "Custom Ingredients")]
    public IList<Data.Entities.User.Ingredient> Ingredients { get; init; } = null!;
}
