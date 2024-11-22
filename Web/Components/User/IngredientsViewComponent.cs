using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.Ingredients;

namespace Web.Components.User;


/// <summary>
/// Renders a list of the user's custom ingredients.
/// </summary>
public class IngredientsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Ingredients";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public IngredientsViewComponent(CoreContext context, UserRepo userRepo)
    {
        _userRepo = userRepo;
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = await _userRepo.AddUserToken(user, durationDays: 1);

        // FIXME: Slow when the user has lots of ingredients.
        var userIngredients = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .Where(i => i.UserId == user.Id
                // The user is an admin who is allowed to edit base ingredients.
                || (user.Features.HasFlag(Features.Admin) && i.UserId == null))
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Ingredients", new IngredientsViewModel()
        {
            UserNewsletter = userNewsletter,
            Ingredients = userIngredients.Select(i => i.AsType<IngredientDto>()!).ToList(),
        });
    }
}
