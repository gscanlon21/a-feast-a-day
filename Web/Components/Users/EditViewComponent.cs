using Core.Models.Users;
using Data.Entities.Users;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Web.Views.Shared.Components.Edit;
using static Core.Code.Extensions.EnumerableExtensions;
using static Data.Entities.Users.User;

namespace Web.Components.Users;

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

    public async Task<IViewComponentResult> InvokeAsync(User? user = null)
    {
        user ??= await _userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, Includes.All, allowDemoUser: true);
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
            var userSection = viewModel.User.UserSections.SingleOrDefault(umm => umm.Section == section);
            viewModel.UserSections.Add(userSection != null ? new EditComponentViewModel.UserSectionViewModel(userSection) : new EditComponentViewModel.UserSectionViewModel()
            {
                Section = section,
                UserId = viewModel.User.Id,
                Weight = UserSection.DefaultWeight.TryGetValue(section, out int countTmp) ? countTmp : 0
            });
        }

        var foodPreferenceMap = EnumExtensions.GetMultiValues<Allergens>().SelectMany(k => EnumExtensions.GetSubValues(k).Append(k).Select(v => (Key: k, Value: v))).ToDictionary(g => g.Value, g => g.Key);
        foreach (var foodPreference in EnumExtensions.GetNotNoneValues<Allergens>()
            .OrderBy(fp => fp.GetSingleDisplayNameOrNull(DisplayType.GroupName), NullOrder.NullsFirst)
            .ThenByDescending(fp => BitOperations.PopCount((ulong)fp))
            .ThenBy(fp => fp.GetOrder(), NullOrder.NullsFirst)
            .ThenBy(fp => fp.GetSingleDisplayName()))
        {
            var userFoodPreference = viewModel.User.UserFoodPreferences.SingleOrDefault(umm => umm.Allergen == foodPreference);
            viewModel.UserFoodPreferences.Add(userFoodPreference switch
            {
                not null => new EditComponentViewModel.UserEditFoodPreferencesViewModel(userFoodPreference)
                {
                    Group = foodPreferenceMap.GetValueOrDefault(foodPreference),
                },
                null => new EditComponentViewModel.UserEditFoodPreferencesViewModel()
                {
                    Group = foodPreferenceMap.GetValueOrDefault(foodPreference),
                    FoodPreference = FoodPreference.Normal,
                    UserId = viewModel.User.Id,
                    Allergen = foodPreference,
                },
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
