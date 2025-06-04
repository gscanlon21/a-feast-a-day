using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Data;
using Data.Query.Builders;
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

    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public IgnoredRecipesViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe.
        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = token;

        // See if the user recipes exist on the user obj.
        var userRecipes = user.UserRecipes.NullIfEmpty()?
            .Where(ur => ur.IgnoreUntil == DateOnly.MaxValue)
            .Where(ur => ur.Section != Section.None)
            .ToList();

        // If they don't, pull them from the database.
        userRecipes ??= await _context.UserRecipes.AsNoTracking()
            .Where(ur => ur.IgnoreUntil == DateOnly.MaxValue)
            .Where(ur => ur.Section != Section.None)
            .Where(ur => ur.UserId == user.Id)
            .ToListAsync();

        // Recipes are ignored across all sections at once.
        var ignoredRecipes = await new QueryBuilder(Section.None)
            .WithUser(user, ignoreAllergens: true, ignoreIgnored: true, ignoreMissingEquipment: true)
            .WithRecipes(x =>
            {
                x.AddRecipes(userRecipes.DistinctBy(ur => ur.RecipeId));
            })
            .Build()
            .Query(_serviceScopeFactory);

        return View("IgnoredRecipes", new IgnoredRecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredRecipes = ignoredRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }
}
