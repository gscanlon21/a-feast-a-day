using Core.Dtos.Ingredient;
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
        var recipeIngredientIds = recipe.RecipeIngredients.Select(ri => ri.IngredientId).ToList();
        var ingredients = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .Where(i => recipeIngredientIds.Contains(i.Id))
            .OrderBy(f => f.Name)
            .ToListAsync();

        var ignoredIngredients = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.AlternativeIngredients).ThenInclude(ai => ai.Ingredient)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Where(i => i.UserIngredients.First(ui => ui.UserId == user.Id).Ignore)
            .Where(i => recipeIngredientIds.Contains(i.Id))
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("RecipeIngredients", new RecipeIngredientsViewModel()
        {
            Parameters = parameters,
            User = new UserNewsletterDto(user.AsType<UserDto>()!, parameters.Token),
            Ingredients = ingredients.Select(i => i.AsType<IngredientDto>()!).ToList(),
            IgnoredIngredients = ignoredIngredients.Select(i => i.AsType<IngredientDto>()!).ToList(),
        });
    }
}
