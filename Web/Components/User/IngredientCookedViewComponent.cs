using Core.Dtos.User;
using Core.Models.Ingredients;
using Core.Models.User;
using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        // User must've created the ingredient to be able to edit it.
        if (ingredient.UserId != user.Id && !user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        var cookedIngredients = await GetCookedIngredients(ingredient, user);
        var usedCookingMethods = cookedIngredients.Select(ci => ci.CookingMethod).ToList();
        foreach (var cookingMethod in EnumExtensions.GetNotNoneValues<CookingMethod>().Where(cm => !usedCookingMethods.Contains(cm)))
        {
            cookedIngredients.Add(new IngredientCooked()
            {
                Scale = 1,
                Ingredient = ingredient,
                IngredientId = ingredient.Id,
                CookingMethod = cookingMethod,
                CookedIngredient = ingredient,
                CookedIngredientId = ingredient.Id,
            });
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("IngredientCooked", new IngredientCookedViewModel()
        {
            Token = token,
            Email = user.Email,
            IngredientId = ingredient.Id,
            IngredientSelect = await GetIngredientSelect(user, ingredient.Id),
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            CookedIngredients = cookedIngredients.OrderByOrder(ci => ci.CookingMethod).ToList(),
        });
    }

    private async Task<IList<SelectListItem>> GetIngredientSelect(Data.Entities.Users.User user, int ingredientId)
    {
        return (await _context.Ingredients.AsNoTracking().TagWithCallSite()
            .Where(i => i.DisabledReason != null || i.Id == ingredientId)
            .Where(i => i.UserId == null || i.UserId == user.Id)
            .OrderBy(i => i.Name)
            .ToListAsync())
            .Select(i => new SelectListItem() { Text = i.Name, Value = i.Id.ToString() })
            .Prepend(new SelectListItem())
            .ToList();
    }

    private async Task<List<IngredientCooked>> GetCookedIngredients(Ingredient ingredient, Data.Entities.Users.User user)
    {
        return await _context.IngredientsCooked.AsNoTracking().IgnoreQueryFilters().Include(i => i.CookedIngredient)
            // The user is an admin who is allowed to edit alternative ingredients. Or the user owns the ingredient.
            .Where(i => i.CookedIngredient.UserId == user.Id || i.CookedIngredient.UserId == null)
            .Where(ia => ia.IngredientId == ingredient.Id)
            .OrderBy(f => f.CookedIngredient.Name)
            .ToListAsync();
    }
}
