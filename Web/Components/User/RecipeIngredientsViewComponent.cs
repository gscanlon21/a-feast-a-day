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
        var recipeIngredients = await _context.UserRecipeIngredients
            .Include(ri => ri.SubstituteIngredient).Include(ri => ri.SubstituteRecipe)
            .Include(ri => ri.RecipeIngredient).ThenInclude(ri => ri.IngredientRecipe)
            .Include(ri => ri.RecipeIngredient).ThenInclude(ri => ri.Ingredient)
            .Where(ri => ri.RecipeIngredient.RecipeId == recipe.Id)
            .Where(ri => ri.UserId == user.Id)
            .OrderBy(ri => ri.RecipeIngredient.Order)
            .ToListAsync();

        // May be empty if the user hasn't seen this recipe.
        if (!recipeIngredients.Any()) { return Content(""); }
        return View("RecipeIngredients", new RecipeIngredientsViewModel()
        {
            User = user,
            Token = parameters.Token,
            UserRecipeIngredients = recipeIngredients,
        });
    }
}
