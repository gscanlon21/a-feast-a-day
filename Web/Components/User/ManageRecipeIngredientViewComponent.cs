using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Data;
using Data.Entities.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.RecipeIngredient;
using Web.Views.Shared.Components.ManageRecipeIngredient;

namespace Web.Components.User;

public class ManageRecipeIngredientViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageRecipeIngredient";

    private readonly CoreContext _context;

    public ManageRecipeIngredientViewComponent(CoreContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, RecipeIngredient recipeIngredient, UserManageRecipeIngredientViewModel.Params parameters)
    {
        var userRecipeIngredient = await _context.UserRecipeIngredients.AsNoTracking()
            .Where(ui => ui.RecipeIngredientId == parameters.RecipeIngredientId)
            //.Where(ui => ui.RecipeId == parameters.RecipeId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        //var recipeIngredient = await _context.RecipeIngredients.AsNoTracking()
        //    .Where(ri => ri.IngredientId == parameters.IngredientId)
        //    .Where(ri => ri.RecipeId == parameters.RecipeId)
        //    .FirstOrDefaultAsync();

        // Must be managed from a recipe context.
        if (recipeIngredient == null) { return Content(""); }
        if (userRecipeIngredient == null) { return Content(""); }
        return View("ManageRecipeIngredient", new ManageRecipeIngredientViewModel()
        {
            User = user,
            Parameters = parameters,
            Recipes = await GetRecipes(user),
            RecipeIngredient = recipeIngredient,
            UserRecipeIngredient = userRecipeIngredient,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, parameters.Token),
            Ingredients = recipeIngredient.Ingredient?.Alternatives.Select(ai => ai.AlternativeIngredient.AsType<IngredientDto>()!).ToList() ?? [],
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
