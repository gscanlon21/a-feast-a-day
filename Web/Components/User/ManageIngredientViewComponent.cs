using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Ingredient;
using Web.Views.Shared.Components.ManageIngredient;

namespace Web.Components.User;

public class ManageIngredientViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageIngredient";

    private readonly CoreContext _context;

    public ManageIngredientViewComponent(CoreContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Ingredient ingredient, UserManageIngredientViewModel.Params parameters)
    {
        var userIngredient = await _context.UserIngredients.AsNoTracking()
            .Where(ui => ui.IngredientId == parameters.IngredientId)
            .Where(ui => ui.RecipeId == parameters.RecipeId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        var recipeIngredient = await _context.RecipeIngredients.AsNoTracking()
            .Where(ri => ri.IngredientId == parameters.IngredientId)
            .Where(ri => ri.RecipeId == parameters.RecipeId)
            .FirstOrDefaultAsync();

        // Must be managed from a recipe context.
        if (userIngredient == null) { return Content(""); }
        if (recipeIngredient == null) { return Content(""); }
        return View("ManageIngredient", new ManageIngredientViewModel()
        {
            User = user,
            Parameters = parameters,
            UserIngredient = userIngredient,
            Recipes = await GetRecipes(user),
            RecipeIngredient = recipeIngredient,
            Ingredient = ingredient.AsType<IngredientDto>()!,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, parameters.Token),
            Ingredients = ingredient.Alternatives.Select(ai => ai.AlternativeIngredient.AsType<IngredientDto>()!).ToList(),
        });
    }

    /// <summary>
    /// Get recipes that the user is able to select as an ingredient alternative.
    /// </summary>
    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        return await _context.Recipes.AsNoTracking().TagWithCallSite()
            .Where(r => r.UserId == null || r.UserId == user.Id) // Has any flag:
            .Where(r => r.Instructions.All(i => (i.Equipment & user.Equipment) != 0 || i.Equipment == Equipment.None))
            .Where(r => r.BaseRecipe)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }
}
