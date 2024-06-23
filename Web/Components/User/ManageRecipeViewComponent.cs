using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data;
using Data.Entities.User;
using Data.Models;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.User;

namespace Web.Components.User;

public class ManageRecipeViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory) : ViewComponent
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

        if (userRecipe == null) { return Content(""); }
        var recipeDto = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreIgnored: true)
            .WithRecipes(x =>
            {
                x.AddRecipes([recipe]);
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!)
            .DistinctBy(vm => vm.Recipe)
            .SingleOrDefault();

        if (recipeDto == null) { return Content(""); }
        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            Recipe = recipeDto,
            UserRecipe = userRecipe,
            Parameters = parameters,
            Notes = userRecipe.Notes,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
        });
    }
}
