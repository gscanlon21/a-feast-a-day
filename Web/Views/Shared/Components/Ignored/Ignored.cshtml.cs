using Core.Models.Newsletter;
using Lib.Pages.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Ignored;

public class IgnoredViewModel
{
    [Display(Name = "Ignored Recipes")]
    public required IList<Lib.Pages.Shared.Recipe.NewsletterRecipeViewModel> IgnoredRecipes { get; init; }

    public required UserNewsletterViewModel UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
