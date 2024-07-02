using Core.Dtos.Ingredient;
using Core.Models.Newsletter;
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
                SubstituteIngredientId = ingredient.Id,
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
            .Where(i => i.UserId == null || i.UserId == user.Id)
            .Where(i => i.Section == Section.None)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }
}
