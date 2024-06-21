using Core.Models.Newsletter;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Ingredients;

public class IngredientsViewModel
{
    [Display(Name = "My Ingredients")]
    public required IList<Lib.ViewModels.Newsletter.IngredientViewModel> Ingredients { get; init; }

    public required UserNewsletterViewModel UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
