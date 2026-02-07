using Core.Models.User;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Edit;

namespace Web.Components.User;

/// <summary>
/// The edit form for the user's preferences.
/// </summary>
public class EditViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public EditViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Edit";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User? user = null)
    {
        user ??= await _userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true, includeNutrients: true, includeFoodPreferences: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new EditComponentViewModel(user, token)));
    }

    private static async Task<EditComponentViewModel> PopulateUserEditViewModel(EditComponentViewModel viewModel)
    {
        foreach (var section in UserSection.DefaultWeight.Keys.OrderBy(mg => mg))
        {
            var userMuscleMobility = viewModel.User.UserSections.SingleOrDefault(umm => umm.Section == section);
            viewModel.UserSections.Add(userMuscleMobility != null ? new EditComponentViewModel.UserSectionViewModel(userMuscleMobility) : new EditComponentViewModel.UserSectionViewModel()
            {
                Section = section,
                UserId = viewModel.User.Id,
                Weight = UserSection.DefaultWeight.TryGetValue(section, out int countTmp) ? countTmp : 0
            });
        }

        foreach (var muscleGroup in EnumExtensions.GetSingleValues<Allergens>()
            .OrderBy(mg => mg.GetSingleDisplayName(DisplayType.GroupName))
            .ThenBy(mg => mg.GetSingleDisplayName()))
        {
            var userMuscleMobility = viewModel.User.UserFoodPreferences.SingleOrDefault(umm => umm.Allergen == muscleGroup);
            viewModel.UserFoodPreferences.Add(userMuscleMobility != null ? new EditComponentViewModel.UserEditFoodPreferencesViewModel(userMuscleMobility) : new EditComponentViewModel.UserEditFoodPreferencesViewModel()
            {
                FoodPreference = FoodPreference.Normal,
                UserId = viewModel.User.Id,
                Allergen = muscleGroup,
            });
        }

        foreach (var family in viewModel.User.UserFamilies)
        {
            viewModel.UserFamilies.Add(new EditComponentViewModel.UserFamilyViewModel()
            {
                Person = family.Person,
                CaloriesPerDay = family.CaloriesPerDay,
                Weight = family.Weight,
                UserId = viewModel.User.Id,
            });
        }

        while (viewModel.UserFamilies.Count < 10)
        {
            viewModel.UserFamilies.Add(new EditComponentViewModel.UserFamilyViewModel()
            {
                UserId = viewModel.User.Id,
                Hide = viewModel.UserFamilies.Count > 0,
            });
        }

        return viewModel;
    }
}
