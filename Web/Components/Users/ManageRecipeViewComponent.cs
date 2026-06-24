using Data.Entities.Newsletter;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Code.Attributes;
using Web.Code.Context;
using Web.Views.Shared.Components.ManageRecipe;

namespace Web.Components.Users;

public class ManageRecipeViewComponent : ViewComponent
{
    private readonly RequestContext<ManageRecipeParams> _parameters;
    private readonly UserRepo _userRepo;

    public ManageRecipeViewComponent(UserRepo userRepo, RequestContext<ManageRecipeParams> parameters)
    {
        _parameters = parameters;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageRecipe";

    public async Task<IViewComponentResult> InvokeAsync(User user, Recipe recipe, UserRecipe? userRecipe)
    {
        if (userRecipe == null)
        {
            return Content("");
        }

        var userFeast = await _userRepo.GetCurrentFeast(user, UserFeast.Include.Recipes);
        if (userFeast == null)
        {
            return Content("");
        }

        var swappable = userFeast.UserFeastRecipes.Any(ufr => ufr.RecipeId == _parameters.RequireContext.RecipeId);
        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            Recipe = recipe,
            Swappable = swappable,
            UserRecipe = userRecipe,
            Parameters = _parameters.RequireContext,
            Notes = userRecipe.Notes,
            Servings = userRecipe.Servings,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
        });
    }
}
