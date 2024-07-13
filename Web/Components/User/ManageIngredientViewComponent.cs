using Core.Dtos.Ingredient;
using Core.Models.Recipe;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.ManageIngredient;
using Web.Views.User;

namespace Web.Components.User;

public class ManageIngredientViewComponent(CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "ManageIngredient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Ingredient ingredient, UserManageIngredientViewModel.Params parameters)
    {
        var userIngredient = await context.UserIngredients.AsNoTracking()
            .FirstOrDefaultAsync(r => r.UserId == user.Id && r.IngredientId == parameters.IngredientId);

        if (userIngredient == null)
        {
            userIngredient = new UserIngredient()
            {
                UserId = user.Id,
                IngredientId = ingredient.Id,
            };
            context.UserIngredients.Add(userIngredient);
            await context.SaveChangesAsync();
        }

        return View("ManageIngredient", new ManageIngredientViewModel()
        {
            User = user,
            Parameters = parameters,
            UserIngredient = userIngredient,
            Ingredient = ingredient.AsType<IngredientDto, Ingredient>()!,
            Ingredients = ingredient.Alternatives.Select(ai => ai.AlternativeIngredient).ToList(),
            Recipes = await GetRecipes(user),
        });
    }

    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        return await context.Recipes.AsNoTracking()
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => r.Equipment == Equipment.None || user.Equipment.HasFlag(r.Equipment))
            // Some ingredients recipes can stand on their own, such as a simple salad that can be used in a sandwich.
            //.Where(r => r.Section == Section.None)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }
}
