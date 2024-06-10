using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

public class CurrentFeastViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "CurrentFeast";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // User has not confirmed their account, they cannot see a workout yet.
        if (!user.LastActive.HasValue)
        {
            return Content("");
        }

        return View("CurrentFeast", new CurrentFeastViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
