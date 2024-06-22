using Core.Code.Extensions;
using Core.Consts;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.User;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class EditViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Edit";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User? user = null)
    {
        user ??= await userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true, includeNutrients: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private static async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        foreach (var muscleGroup in UserServing.MuscleTargets.Keys
            .OrderBy(mg => mg.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(mg => mg.GetSingleDisplayName()))
        {
            var userMuscleMobility = viewModel.User.UserServings.SingleOrDefault(umm => umm.Section == muscleGroup);
            viewModel.UserServings.Add(userMuscleMobility != null ? new UserEditViewModel.UserServingViewModel(userMuscleMobility) : new UserEditViewModel.UserServingViewModel()
            {
                UserId = viewModel.User.Id,
                Section = muscleGroup,
                Count = UserServing.MuscleTargets.TryGetValue(muscleGroup, out int countTmp) ? countTmp : 0
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
