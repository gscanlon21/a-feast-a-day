using Core.Dtos.User;
using Data;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Recipe;
using Web.Views.Shared.Components.RecipeIngredients;

namespace Web.Components.User;

/// <summary>
/// Renders a recipe's ingredients.
/// </summary>
public class RecipeIngredientsViewComponent : ViewComponent
{
    private readonly CoreContext _context;

    public RecipeIngredientsViewComponent(CoreContext context)
    {
        _context = context;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "RecipeIngredients";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe recipe, UserManageRecipeViewModel.Params parameters)
    {
        var recipeIngredients = await _context.RecipeIngredients
            .Include(ri => ri.Ingredient)
            .Include(ri => ri.IngredientRecipe)
            .Where(ri => ri.RecipeId == recipe.Id)
            .OrderBy(ri => ri.Order)
            .ToListAsync();

        return View("RecipeIngredients", new RecipeIngredientsViewModel()
        {
            Parameters = parameters,
            RecipeIngredients = recipeIngredients,
            User = new UserNewsletterDto(user.AsType<UserDto>()!, parameters.Token),
        });
    }
}
