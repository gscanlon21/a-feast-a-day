using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.PastFeasts;

namespace Web.Components.User;

public class PastFeastsViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "PastFeasts";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var pastFeasts = await userRepo.GetPastFeasts(user);
        if (!pastFeasts.Any())
        {
            return Content("");
        }

        return View("PastFeasts", new PastFeastsViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            PastFeasts = pastFeasts,
        });
    }
}
