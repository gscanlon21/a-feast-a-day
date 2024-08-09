using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.BackupRestore;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class BackupRestoreViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public BackupRestoreViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "BackupRestore";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        return View("BackupRestore", new BackupRestoreViewModel(user, token));
    }
}
