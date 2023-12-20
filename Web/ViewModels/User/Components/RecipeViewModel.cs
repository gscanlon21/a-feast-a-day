using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for Confirmation.cshtml
/// </summary>
public class RecipeViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public Data.Entities.User.UserRecipe Recipe { get; set; } = null!;

    [Display(Name = "Custom Recipes")]
    public IList<Data.Entities.User.UserRecipe> Recipes { get; init; } = null!;
}
