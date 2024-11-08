using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.User;
using Data;
using Data.Models;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.Recipes;

namespace Web.Components.User;


/// <summary>
/// Renders a list of the user's custom recipes.
/// </summary>
public class RecipesViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Recipes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
        var userNewsletter = user.AsType<UserNewsletterDto, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);

        var userRecipes = await context.Recipes
            .Where(r => r.UserId == user.Id
                // The user is an admin who is allowed to edit base recipes.
                || (user.Features.HasFlag(Features.Admin) && r.UserId == null))
            .ToListAsync();

        var recipes = await new QueryBuilder()
            // Include disabled recipes.
            .WithUser(user, ignoreAllergens: true, ignoreIgnored: true, ignoreMissingEquipment: true)
            .WithRecipes(x =>
            {
                x.AddRecipes(userRecipes);
                x.IgnorePrerequisites = true;
            })
            .Build()
            .Query(serviceScopeFactory);

        return View("Recipes", new RecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
        });
    }
}
