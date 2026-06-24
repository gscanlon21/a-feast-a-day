using Data;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.Attributes;
using Web.Code.Context;
using Web.Views.Shared.Components.RecipeIngredients;

namespace Web.Components.Users;

/// <summary>
/// Renders a recipe's ingredients.
/// </summary>
public class RecipeIngredientsViewComponent : ViewComponent
{
    private readonly RequestContext<ManageRecipeParams> _parameters;
    private readonly CoreContext _context;

    public RecipeIngredientsViewComponent(CoreContext context, RequestContext<ManageRecipeParams> parameters)
    {
        _parameters = parameters;
        _context = context;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "RecipeIngredients";

    public async Task<IViewComponentResult> InvokeAsync(User user, Recipe recipe)
    {
        var recipeIngredients = await _context.UserRecipeIngredients.AsNoTracking()
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
            Token = _parameters.RequireContext.Token,
            UserRecipeIngredients = recipeIngredients,
        });
    }
}
