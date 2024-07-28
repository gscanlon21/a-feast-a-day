using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Data;
using Data.Models;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.Ignored;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class IgnoredViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Ignored";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterDto, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);

        var userRecipes = await context.UserRecipes
            .Where(r => r.UserId == user.Id)
            .Where(r => r.Ignore)
            .Select(r => r.Recipe)
            .ToListAsync();

        var ignoredRecipes = await new QueryBuilder()
            // Include disabled recipes.
            .WithUser(user, ignoreIgnored: true)
            .WithRecipes(x =>
            {
                x.AddRecipes(userRecipes);
            })
            .Build()
            .Query(serviceScopeFactory);

        return View("Ignored", new IgnoredViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredRecipes = ignoredRecipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
        });
    }
}
