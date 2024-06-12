using Core.Code.Extensions;
using Core.Models.User;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

public class IngredientViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Ingredient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Ingredient? ingredient = null)
    {
        var userIngredients = await context.Ingredients
            .Where(i => i.UserId == user.Id
                // The user is an admin who is allowed to edit base ingredients.
                || (user.Features.HasFlag(Features.Admin) && i.UserId == null))
            .OrderBy(f => f.Name)
            .ToListAsync();

        var nutrients = new List<Nutrient>();
        foreach (var nutrient in EnumExtensions.GetValuesExcluding32(Nutrients.None, Nutrients.All)
            .OrderBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.Order).Length)
            .ThenBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.Order))
            .ThenBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.Name)))
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

        return View("Ingredient", new IngredientViewModel()
        {
            User = user,
            Nutrients = nutrients,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            Ingredient = ingredient ?? new Ingredient()
            {
                UserId = user.Id
            },
        });
    }
}
