using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.User;
using Data;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Recipes;

namespace Web.Components.User;


/// <summary>
/// Renders a list of the user's custom recipes.
/// </summary>
public class RecipesViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RecipesViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Recipes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = await _userRepo.AddUserToken(user, durationDays: 1);

        var userRecipes = await _context.Recipes
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
            .Query(_serviceScopeFactory);

        return View("Recipes", new RecipesViewModel()
        {
            UserNewsletter = userNewsletter,
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }
}
