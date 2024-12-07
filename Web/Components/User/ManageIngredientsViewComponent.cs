using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Data;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Recipe;
using Web.Views.Shared.Components.ManageIngredients;

namespace Web.Components.User;

public class ManageIngredientsViewComponent(CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "ManageIngredients";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe recipe, UserManageRecipeViewModel.Params parameters)
    {
        var userRecipe = await context.UserRecipes.AsNoTracking()
            .FirstOrDefaultAsync(r => r.UserId == user.Id && r.RecipeId == parameters.RecipeId);
        if (userRecipe == null)
        {
            return Content("");
        }

        var recipeIngredientIds = recipe.RecipeIngredients.Select(ri => ri.IngredientId).ToList();
        var ingredients = await context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .Where(i => recipeIngredientIds.Contains(i.Id)).ToListAsync();

        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = parameters.Token;
        return View("ManageIngredients", new ManageIngredientsViewModel()
        {
            User = userNewsletter,
            Parameters = parameters,
            Ingredients = ingredients.Select(i => i.AsType<IngredientDto>()!).ToList(),
        });
    }
}
