using Core.Models.Ingredients;
using Core.Models.User;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Vegetarian;

namespace Web.Components.Users;

/// <summary>
/// Renders alerts regarding nutrient targets for vegetarian users.
/// </summary>
public class VegetarianViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Vegetarian";

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        if (user.UserFoodPreferences.FirstOrDefault(fp => fp.Allergen == Allergens.Meat)?.FoodPreference == FoodPreference.Exclude)
        {
            return View("Vegetarian", new VegetarianViewModel()); 
        }

        return Content("");
    }
}
