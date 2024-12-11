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

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        // User has not confirmed their account, let the backfill finish first.
        if (!user.LastActive.HasValue)
        {
            return Content("");
        }

        // Use the persistent token so the user can bookmark this.
        token = await _userRepo.GetPersistentToken(user) ?? token;
        return View("CurrentFeast", new CurrentFeastViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
