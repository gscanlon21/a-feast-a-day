using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.IngredientAlternatives;

namespace Web.Components.User;

public class IngredientAlternativesViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "IngredientAlternatives";

    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public IngredientAlternativesViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, Ingredient ingredient)
    {
        var partialIngredients = await GetAlternativeIngredients(ingredient, user, partial: true);
        var alternativeIngredients = await GetAlternativeIngredients(ingredient, user, partial: false);
        if (!partialIngredients.Any() && !alternativeIngredients.Any()) 
        { 
            return Content(""); 
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("IngredientAlternatives", new IngredientAlternativesViewModel()
        {
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            PartialIngredients = partialIngredients.ConvertAll(i => i.AsType<IngredientDto>()!),
            AlternativeIngredients = alternativeIngredients.ConvertAll(i => i.AsType<IngredientDto>()!),
        });
    }

    private async Task<List<Ingredient>> GetAlternativeIngredients(Ingredient ingredient, Data.Entities.Users.User user, bool partial)
    {
        return await _context.IngredientAlternatives.AsNoTracking()
            .Include(i => i.AlternativeIngredient).ThenInclude(ai => ai.Nutrients)
            .Include(i => i.AlternativeIngredient).ThenInclude(ai => ai.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredient).ThenInclude(ai => ai.AlternativeIngredients).ThenInclude(ai => ai.Ingredient)
            // The user is an admin who is allowed to edit alternative ingredients. Or the user owns the ingredient.
            .Where(i => i.AlternativeIngredient.UserId == user.Id || i.AlternativeIngredient.UserId == null)
            .Where(ia => ia.AlternativeIngredient.DisabledReason == null)
            .Where(ia => ia.IngredientId == ingredient.Id)
            .Where(ia => ia.IsAggregateElement == partial)
            .OrderBy(f => f.AlternativeIngredient.Name)
            .Select(ia => ia.AlternativeIngredient)
            .ToListAsync();
    }
}
