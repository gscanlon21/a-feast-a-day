using Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Genetics;

namespace Web.Components.User;

public class GeneticsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Genetics";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        if (!user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        return View("Genetics", new GeneticsViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
