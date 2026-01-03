using Core.Dtos.User;
using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.IngredientCooked;

public class IngredientCookedViewModel
{
    public required string Email { get; init; }
    public required string Token { get; init; }
    public required int IngredientId { get; init; }

    [Display(Name = "Cooked Ingredients")]
    public required IList<Data.Entities.Ingredients.IngredientCooked> CookedIngredients { get; init; }

    public required UserNewsletterDto UserNewsletter { get; init; }

    public required IList<SelectListItem> IngredientSelect { get; init; } = [];

    public Verbosity Verbosity => Verbosity.Images;
}
