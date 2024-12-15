using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.User;
using Data;
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

    private readonly CoreContext _context;

    public IngredientsViewComponent(CoreContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        var all = bool.TryParse(Request.Query["all"], out bool allTmp)
            && allTmp && user.Features.HasFlag(Features.Admin);

        // FIXME: Slow when the user has lots of ingredients.
        var userIngredients = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            // The user is an admin who is allowed to edit base ingredients.
            .Where(i => i.UserId == user.Id || (all && i.UserId == null))
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Ingredients", new IngredientsViewModel()
        {
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            Ingredients = userIngredients.Select(i => i.AsType<IngredientDto>()!).ToList(),
        });
    }
}
