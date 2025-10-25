using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.IngredientAlternatives;

public class IngredientAlternativesViewModel
{
    [Display(Name = "Alternative Ingredients")]
    public required IList<IngredientDto> AlternativeIngredients { get; init; }

    [Display(Name = "Partial Ingredients")]
    public required IList<IngredientDto> PartialIngredients { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public Verbosity Verbosity => Verbosity.Images;
}
