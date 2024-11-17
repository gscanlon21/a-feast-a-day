using Core.Consts;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.User;

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

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User? user = null)
    {
        user ??= await _userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true, includeNutrients: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private static async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        foreach (var section in UserServing.DefaultServings.Keys.OrderBy(mg => mg))
        {
            var userMuscleMobility = viewModel.User.UserServings.SingleOrDefault(umm => umm.Section == section);
            viewModel.UserServings.Add(userMuscleMobility != null ? new UserEditViewModel.UserServingViewModel(userMuscleMobility) : new UserEditViewModel.UserServingViewModel()
            {
                UserId = viewModel.User.Id,
                Section = section,
                Count = UserServing.DefaultServings.TryGetValue(section, out int countTmp) ? countTmp : 0
            });
        }

        foreach (var family in viewModel.User.UserFamilies)
        {
            viewModel.UserFamilies.Add(new UserEditViewModel.UserFamilyViewModel()
            {
                Person = family.Person,
                CaloriesPerDay = family.CaloriesPerDay,
                Weight = family.Weight,
                UserId = viewModel.User.Id,
            });
        }

        while (viewModel.UserFamilies.Count < 10)
        {
            viewModel.UserFamilies.Add(new UserEditViewModel.UserFamilyViewModel()
            {
                UserId = viewModel.User.Id,
                Hide = viewModel.UserFamilies.Count > 0,
            });
        }

        return viewModel;
    }
}
