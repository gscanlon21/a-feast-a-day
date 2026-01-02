using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.IngredientCooked;

public class IngredientCookedViewModel
{
    [Display(Name = "Cooked Ingredients")]
    public required IList<Data.Entities.Ingredients.IngredientCooked> CookedIngredients { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
