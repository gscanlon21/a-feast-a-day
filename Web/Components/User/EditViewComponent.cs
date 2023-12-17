using Core.Consts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.User;

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
        user ??= await userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, includeExerciseVariations: true, includeMuscles: true, includeFrequencies: true, allowDemoUser: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        return viewModel;
    }
}
