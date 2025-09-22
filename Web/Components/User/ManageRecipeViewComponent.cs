using Data;
using Data.Entities.Recipe;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Recipe;
using Web.Views.Shared.Components.ManageRecipe;

namespace Web.Components.User;

public class ManageRecipeViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public ManageRecipeViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
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

        if (userRecipe == null)
        {
            return Content("");
        }

        var userFeast = await _userRepo.GetCurrentFeast(user);
        if (userFeast == null)
        {
            return Content("");
        }

        var swappable = await _context.UserFeastRecipes.Where(ufr => ufr.UserFeastId == userFeast.Id).AnyAsync(ufr => ufr.RecipeId == parameters.RecipeId);
        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            Recipe = recipe,
            Swappable = swappable,
            UserRecipe = userRecipe,
            Parameters = parameters,
            Notes = userRecipe.Notes,
            Servings = userRecipe.Servings,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
        });
    }
}
