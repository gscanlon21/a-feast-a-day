using Core.Models.User;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.BackupRestore;

namespace Web.Components.Users;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class BackupRestoreViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "BackupRestore";

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        // Don't demo this. Its not that important.
        if (user.Features.HasFlag(Features.Demo))
        {
            return Content("");
        }

        // This is still a work in progress.
        if (user.Features.HasFlag(Features.Admin))
        {
            return View("BackupRestore", new BackupRestoreViewModel(user, token));
        }

        return Content("");
    }
}
