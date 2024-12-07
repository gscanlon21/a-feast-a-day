using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Recipe;
using Data.Query.Builders;
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
            .Where(r => r.Section == parameters.Section)
            .Where(r => r.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userRecipe == null) { return Content(""); }
        var recipeDto = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreAllergens: true, ignoreIgnored: true, ignoreMissingEquipment: true)
            .WithRecipes(x =>
            {
                // Don't return more than one recipe if the recipe has ingredient recipes.
                x.IgnorePrerequisites = true;
                x.AddRecipes([recipe]);
            })
            .Build()
            .Query(_serviceScopeFactory))
            .FirstOrDefault();

        if (recipeDto == null) { return Content(""); }
        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            UserRecipe = userRecipe,
            Parameters = parameters,
            Notes = userRecipe.Notes,
            Servings = userRecipe.Servings,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
            Recipe = recipeDto.AsType<NewsletterRecipeDto>()!,
        });
    }
}
