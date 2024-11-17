using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Data;
using Data.Query;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.IgnoredRecipes;

namespace Web.Components.User;

/// <summary>
/// Renders the user's ignored recipes.
/// </summary>
public class IgnoredRecipesViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "IgnoredRecipes";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public IgnoredRecipesViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _userRepo = userRepo;
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterDto, Data.Entities.User.User>()!;
        userNewsletter.Token = await _userRepo.AddUserToken(user, durationDays: 1);

        var userRecipes = await _context.UserRecipes
            .Where(r => r.UserId == user.Id)
            .Where(r => r.Ignore)
            .Select(r => r.Recipe)
            .ToListAsync();

        // FIXME: This may be slow if the user has a lot of ignored recipes.
        var ignoredRecipes = await new QueryBuilder()
            // Include disabled recipes.
            .WithUser(user, ignoreAllergens: true, ignoreIgnored: true, ignoreMissingEquipment: true)
            .WithRecipes(x =>
            {
                x.AddRecipes(userRecipes);
            })
            .Build()
            .Query(_serviceScopeFactory);

        return View("IgnoredRecipes", new IgnoredRecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredRecipes = ignoredRecipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
        });
    }
}
