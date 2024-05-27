using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

public class IngredientViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Ingredient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Don't show custom ingredients to the demo user.
        if (user.IsDemoUser)
        {
            return Content("");
        }

        var userIngredients = await context.UserIngredients
            .Where(i => i.UserId == user.Id)
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Ingredient", new IngredientViewModel()
        {
            User = user,
            Ingredients = userIngredients,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
