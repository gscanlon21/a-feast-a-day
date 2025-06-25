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
        // Use Section.None so our recipe isn't filtered out.
        var recipeDtos = (await new QueryBuilder(Section.None)
            .WithRecipes(x =>
            {
                x.AddRecipes(new Dictionary<int, int?>
                {
                    [recipe.Id] = null,
                });
            })
            .Build()
            .Query(_serviceScopeFactory))
            .Select(r => r.AsType<NewsletterRecipeDto>()!);

        var recipeDto = recipeDtos.FirstOrDefault(r => r.Recipe.Id == recipe.Id);
        if (recipeDto == null)
        {
            return Content("");
        }

        return View("ManageRecipe", new ManageRecipeViewModel()
        {
            User = user,
            Recipe = recipeDto,
            UserRecipe = userRecipe,
            Parameters = parameters,
            Notes = userRecipe.Notes,
            Servings = userRecipe.Servings,
            LagRefreshXWeeks = userRecipe.LagRefreshXWeeks,
            PadRefreshXWeeks = userRecipe.PadRefreshXWeeks,
            PrepRecipes = recipeDtos.ExceptBy([recipeDto.Recipe.Id], r => r.Recipe.Id).ToList(),
        });
    }
}
