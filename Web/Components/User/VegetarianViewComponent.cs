using Core.Models.Ingredients;
using Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Vegetarian;

namespace Web.Components.User;

public class VegetarianViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Vegetarian";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        if (user.UserFoodPreferences.FirstOrDefault(fp => fp.Allergen == Allergens.Meat)?.FoodPreference == FoodPreference.Exclude)
        {
            return View("Vegetarian", new VegetarianViewModel()); 
        }

        return Content("");
    }
}
