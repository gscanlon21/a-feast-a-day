using Core.Models.Newsletter;
using Lib.Pages.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Recipes;

public class RecipesViewModel
{
    [Display(Name = "My Recipes")]
    public required IList<Lib.Pages.Shared.Recipe.NewsletterRecipeViewModel> Recipes { get; init; }

    public required UserNewsletterViewModel UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
