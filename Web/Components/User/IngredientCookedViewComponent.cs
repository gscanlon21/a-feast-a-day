using Core.Dtos.User;
using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.IngredientCooked;

namespace Web.Components.User;

public class IngredientCookedViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "IngredientCooked";

    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public IngredientCookedViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, Ingredient ingredient)
    {
        var cookedIngredients = await GetCookedIngredients(ingredient, user);
        if (!cookedIngredients.Any())
        {
            return Content("");
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("IngredientCooked", new IngredientCookedViewModel()
        {
            CookedIngredients = cookedIngredients,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
        });
    }

    private async Task<List<IngredientCooked>> GetCookedIngredients(Ingredient ingredient, Data.Entities.Users.User user)
    {
        return await _context.IngredientsCooked.AsNoTracking().IgnoreQueryFilters()
            .Include(i => i.CookedIngredient).ThenInclude(ai => ai.Nutrients)
            .Include(i => i.CookedIngredient).ThenInclude(ai => ai.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.CookedIngredient).ThenInclude(ai => ai.AlternativeIngredients).ThenInclude(ai => ai.Ingredient)
            // The user is an admin who is allowed to edit alternative ingredients. Or the user owns the ingredient.
            .Where(i => i.CookedIngredient.UserId == user.Id || i.CookedIngredient.UserId == null)
            .Where(ia => ia.IngredientId == ingredient.Id)
            .OrderBy(f => f.CookedIngredient.Name)
            .ToListAsync();
    }
}
