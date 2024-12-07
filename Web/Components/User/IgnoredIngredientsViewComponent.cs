using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.IgnoredIngredients;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class IgnoredIngredientsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "IgnoredIngredients";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public IgnoredIngredientsViewComponent(CoreContext context, UserRepo userRepo)
    {
        _userRepo = userRepo;
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterDto>()!;
        userNewsletter.Token = token;

        // FIXME: Slow when the user has lots of ingredients.
        var ignoredIngredients = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .Where(i => i.UserIngredients.First(ui => ui.UserId == user.Id).Ignore == true)
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("IgnoredIngredients", new IgnoredIngredientsViewModel()
        {
            UserNewsletter = userNewsletter,
            IgnoredIngredients = ignoredIngredients.Select(r => r.AsType<IngredientDto>()!).ToList(),
        });
    }
}
