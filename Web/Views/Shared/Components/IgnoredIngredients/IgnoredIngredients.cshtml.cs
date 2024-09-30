using Core.Dtos.Ingredient;
using Core.Dtos.User;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.IgnoredIngredients;

public class IgnoredIngredientsViewModel
{
    [Display(Name = "Ignored Ingredients")]
    public required IList<IngredientDto> IgnoredIngredients { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }
}
