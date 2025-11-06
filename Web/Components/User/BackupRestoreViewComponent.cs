using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.BackupRestore;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class BackupRestoreViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "BackupRestore";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        return View("BackupRestore", new BackupRestoreViewModel(user, token));
    }
}
