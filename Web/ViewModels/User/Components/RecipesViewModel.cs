using Core.Models.Newsletter;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

public class RecipesViewModel
{
    [Display(Name = "My Recipes")]
    public IList<Lib.ViewModels.Newsletter.RecipeViewModel> Recipes { get; init; }

    public Verbosity Verbosity => Verbosity.Instructions | Verbosity.Images;

    public UserNewsletterViewModel UserNewsletter { get; init; }
}
