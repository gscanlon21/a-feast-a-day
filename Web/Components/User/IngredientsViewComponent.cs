using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Lib.Pages.Newsletter;
using Lib.Pages.Shared.Ingredient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.Ingredients;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class IngredientsViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Ingredients";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterViewModel, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);

        var userIngredients = await context.Ingredients.AsNoTracking()
            .Where(i => i.UserId == user.Id
                // The user is an admin who is allowed to edit base ingredients.
                || (user.Features.HasFlag(Features.Admin) && i.UserId == null))
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Ingredients", new IngredientsViewModel()
        {
            UserNewsletter = userNewsletter,
            Ingredients = userIngredients.Select(i => i.AsType<IngredientViewModel, Ingredient>()!).ToList(),
        });
    }
}
