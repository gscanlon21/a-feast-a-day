using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Query;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Recipes;

namespace Web.Components.User;

/// <summary>
/// Renders a list of the user's custom recipes.
/// </summary>
public class RecipesViewComponent : ViewComponent
{
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RecipesViewComponent(CoreContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Recipes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        var all = bool.TryParse(Request.Query["all"], out bool allTmp)
            && allTmp && user.Features.HasFlag(Features.Admin);

        // FIXME: Slow when the user has lots of recipes.
        var userRecipes = await _context.Recipes.AsNoTracking()
            // The user is an admin who is allowed to edit base recipes.
            .Where(r => r.UserId == user.Id || (all && r.UserId == null))
            .ToListAsync();

        // This should include disabled recipes.
        var recipes = await new UserQueryBuilder(user, Section.None)
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
                x.AddRecipes(userRecipes);
                x.IgnorePrepRecipes = true;
            })
            .Build()
            .Query(_serviceScopeFactory, OrderBy.Name);

        return View("Recipes", new RecipesViewModel()
        {
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }
}
