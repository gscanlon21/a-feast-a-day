using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Recipes;

public class RecipesViewModel
{
    [Display(Name = "My Recipes")]
    public required IList<RecipeDtoDto> Recipes { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
