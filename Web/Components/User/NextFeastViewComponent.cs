using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.NextFeast;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class NextFeastViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "NextFeast";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var (_, timeUntilNextSend) = await userRepo.GetNextSendDate(user);
        if (!timeUntilNextSend.HasValue)
        {
            return Content("");
        }

        return View("NextFeast", new NextFeastViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            TimeUntilNextSend = timeUntilNextSend,
        });
    }
}
