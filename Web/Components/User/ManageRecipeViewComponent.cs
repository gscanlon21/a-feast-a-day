using Data;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Recipe;
using Web.Views.Shared.Components.ManageRecipe;

namespace Web.Components.User;

public class ManageRecipeViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ManageRecipeViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageRecipe";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe recipe, UserManageRecipeViewModel.Params parameters)
    {
        var userRecipe = await _context.UserRecipes.AsNoTracking()
            .Where(r => r.RecipeId == parameters.RecipeId)
            .Where(r => r.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userRecipe == null) { return Content(""); }
        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            Recipe = recipe,
            UserRecipe = userRecipe,
            Parameters = parameters,
            Notes = userRecipe.Notes,
            Servings = userRecipe.Servings,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
        });
    }
}
