using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Web.Views.Recipe;

namespace Web.Views.Shared.Components.ManageIngredients;


public class ManageIngredientsViewModel
{
    public required UserManageRecipeViewModel.Params Parameters { get; init; }

    public required UserNewsletterDto User { get; init; }

    public required IList<IngredientDto> Ingredients { get; init; }

    public Verbosity IngredientVerbosity => Verbosity.Images;
}
