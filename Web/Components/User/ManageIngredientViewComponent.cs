using Core.Dtos.User;
using Data;
using Data.Entities.Ingredient;
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
            Ingredients = ingredient.AlternativeIngredients.Select(ai => ai.Ingredient).ToList(),
            UserIngredient = userIngredient,
            Ingredient = ingredient.AsType<IngredientDto, Ingredient>()!,
        });
    }
}
