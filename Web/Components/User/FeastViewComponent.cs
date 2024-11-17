using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.CurrentFeast;

namespace Web.Components.User;

public class CurrentFeastViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public CurrentFeastViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
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
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
