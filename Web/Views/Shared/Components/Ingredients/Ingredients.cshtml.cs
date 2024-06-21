using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Ingredients;

public class IngredientsViewModel
{
    [Display(Name = "My Ingredients")]
    public required IList<IngredientDto> Ingredients { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
