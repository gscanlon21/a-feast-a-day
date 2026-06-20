using Core.Models.Users;
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

    private static readonly Person[] OldPeople = [Person.Male_51_70_Years, Person.Male_71_XX_Years, Person.Female_51_70_Years, Person.Female_71_XX_Years];

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        if (user.UserFoodPreferences.FirstOrDefault(fp => fp.Allergen == Allergens.Meat)?.FoodPreference == FoodPreference.Exclude)
        {
            return View(VegetarianViewModel.ViewName, new VegetarianViewModel());
        }

        if (user.UserFamilies.Any(f => OldPeople.Contains(f.Person)))
        {
            return View(VitaminB12ViewModel.ViewName, new VitaminB12ViewModel());
        }

        return Content("");
    }
}
