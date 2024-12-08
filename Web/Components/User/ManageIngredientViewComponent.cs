using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Recipe;
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

        // Must be managed from a recipe context.
        if (userIngredient == null) { return Content(""); }
        return View("ManageIngredient", new ManageIngredientViewModel()
        {
            User = user,
            Parameters = parameters,
            UserIngredient = userIngredient,
            Recipes = await GetRecipes(user),
            Ingredient = ingredient.AsType<IngredientDto>()!,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, parameters.Token),
            Ingredients = ingredient.Alternatives.Select(ai => ai.AlternativeIngredient.AsType<IngredientDto>()!).ToList(),
        });
    }

    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        var allEquipment = user.Equipment.WithOptionalEquipment();
        return await _context.Recipes.AsNoTracking()
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => allEquipment.HasFlag(r.Equipment))
            // Some ingredients recipes can stand on their own,
            // ... such as a salad that can be used in a sandwich.
            //.Where(r => r.Section == Section.None)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }
}
