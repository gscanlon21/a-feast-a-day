using Core.Dtos.User;
using Core.Models.Newsletter;

namespace Web.Views.Shared.Components.ManageIngredients;


public class ManageIngredientsViewModel
{
    public required User.UserManageRecipeViewModel.Params Parameters { get; init; }

    public required UserNewsletterDto User { get; init; }

    public required IList<IngredientDto> Ingredients { get; init; }

    public Verbosity IngredientVerbosity => Verbosity.Images;
}
