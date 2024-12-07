using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Data;
using Data.Query;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe.
        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = token;

        var userRecipes = user.UserRecipes.NullIfEmpty()?
            .Where(ur => ur.Section != Section.None)
            .Where(ur => ur.Ignore)
            .ToList();
        userRecipes ??= await _context.UserRecipes.AsNoTracking()
            .Where(ur => ur.Section != Section.None)
            .Where(ur => ur.UserId == user.Id)
            .Where(ur => ur.Ignore)
            .ToListAsync();

        var ignoredRecipes = new List<QueryResults>();
        // PERF: This may be slow if the user has a lot of ignored recipes.
        foreach (var sectionGroup in userRecipes.GroupBy(ur => ur.Section))
        {
            ignoredRecipes.AddRange(await new QueryBuilder(sectionGroup.Key)
                .WithUser(user, ignoreAllergens: true, ignoreIgnored: true, ignoreMissingEquipment: true)
                .WithRecipes(x =>
                {
                    x.AddRecipes(sectionGroup);
                })
                .Build()
                .Query(_serviceScopeFactory));
        }

        return View("IgnoredRecipes", new IgnoredRecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredRecipes = ignoredRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }
}
