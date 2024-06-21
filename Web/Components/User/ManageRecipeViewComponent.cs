using Data;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.User;

namespace Web.Components.User;

public class ManageRecipeViewComponent(CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "ManageRecipe";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe recipe, UserManageRecipeViewModel.Params parameters)
    {
        var userRecipe = await context.UserRecipes.AsNoTracking()
            .FirstOrDefaultAsync(r => r.UserId == user.Id && r.RecipeId == parameters.RecipeId);
        if (userRecipe == null)
        {
            return Content("");
        }

        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            Recipe = recipe,
            User = user,
            RecipeSection = parameters.Section,
            UserRecipe = userRecipe,
            Parameters = parameters
        });
    }
}
