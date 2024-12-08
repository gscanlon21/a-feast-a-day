using Core.Models.User;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.UpsertIngredient;

namespace Web.Components.User;

public class UpsertIngredientViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public UpsertIngredientViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "UpsertIngredient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Ingredient? ingredient = null)
    {
        var userIngredients = await _context.Ingredients
            .Where(i => i.UserId == user.Id
                // The user is an admin who is allowed to edit base ingredients.
                || (user.Features.HasFlag(Features.Admin) && i.UserId == null))
            .OrderBy(f => f.Name)
            .ToListAsync();

        var nutrients = new List<Nutrient>();
        foreach (var nutrient in EnumExtensions.GetValuesExcluding32(Nutrients.None, Nutrients.All)
            .OrderBy(n => n.GetSingleDisplayName(DisplayType.Order).Length)
            .ThenBy(n => n.GetSingleDisplayName(DisplayType.Order))
            .ThenBy(n => n.GetSingleDisplayName(DisplayType.GroupName))
            .ThenBy(n => n.GetSingleDisplayName(DisplayType.Name)))
        {
            var userNutrient = ingredient?.Nutrients.FirstOrDefault(n => n.Nutrients == nutrient);
            if (userNutrient != null)
            {
                nutrients.Add(userNutrient);
            }
            else
            {
                nutrients.Add(new Nutrient()
                {
                    Nutrients = nutrient,
                    Ingredient = ingredient,
                });
            }
        }

        return View("UpsertIngredient", new UpsertIngredientViewModel()
        {
            User = user,
            Nutrients = nutrients,
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
            Ingredient = ingredient ?? new Ingredient()
            {
                UserId = user.Id
            },
        });
    }
}
