using Core.Models.Newsletter;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

public class IgnoredViewModel
{
    [Display(Name = "Ignored Recipes")]
    public required IList<Lib.ViewModels.Newsletter.NewsletterRecipeViewModel> IgnoredRecipes { get; init; }

    public required UserNewsletterViewModel UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
