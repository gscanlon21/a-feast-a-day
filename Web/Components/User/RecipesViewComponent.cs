using Data;
using Data.Entities.User;
using Data.Repos;
using Lib.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.ViewModels.User.Components;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class RecipesViewComponent(IServiceScopeFactory serviceScopeFactory, CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Recipes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterViewModel, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);

        var recipes = await context.UserRecipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)
            .Where(r => r.UserId == user.Id).ToListAsync();

        return View("Recipes", new RecipesViewModel()
        {
            Recipes = recipes.AsType<List<Lib.ViewModels.Newsletter.RecipeViewModel>, List<UserRecipe>>()!,
            UserNewsletter = userNewsletter,
        });
    }
}
