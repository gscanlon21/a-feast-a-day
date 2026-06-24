using Core.Dtos.Newsletter;
using Core.Dtos.Users;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Users;
using Data.Query;
using Data.Query.Builders;
using Data.Query.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.IgnoredRecipes;

namespace Web.Components.Users;

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

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        // See if the user recipes exist on the user obj.
        var userRecipes = user.UserRecipes.NullIfEmpty()?
            .Where(ur => ur.IgnoreUntil == DateOnly.MaxValue)
            .ToList();

        // If they don't, pull them from the database.
        userRecipes ??= await _context.UserRecipes.AsNoTracking()
            .Where(ur => ur.IgnoreUntil == DateOnly.MaxValue)
            .Where(ur => ur.UserId == user.Id)
            .ToListAsync();

        var ignoredRecipes = await new UserQueryBuilder<RecipeQueryFilter>(user, Section.None)
            // Pass in the user so we can select their recipes.
            .WithUser(options =>
            {
                options.IgnoreIgnored = true;
                options.MaxIngredients = null;
                options.FoodPreferences.Clear();
            })
            .WithEquipment(Equipment.All)
            .WithRecipes(x =>
            {
                x.AddRecipes(userRecipes.DistinctBy(ur => ur.RecipeId));
            })
            .WithSelectionOptions(x =>
            {
                x.IgnorePrepRecipes = true;
            })
            .Build()
            .Query(_serviceScopeFactory);

        // Need a user context so the manage link is clickable and the user can un-ignore a recipe.
        var userNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token);
        return View("IgnoredRecipes", new IgnoredRecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredRecipes = ignoredRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }
}
