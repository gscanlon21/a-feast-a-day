using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Ignored;

public class IgnoredViewModel
{
    [Display(Name = "Ignored Recipes")]
    public required IList<NewsletterRecipeDto> IgnoredRecipes { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
