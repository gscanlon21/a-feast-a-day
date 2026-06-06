using Core.Models.User;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Microbiome;

namespace Web.Components.Users;

public class MicrobiomeViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Microbiome";

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        if (!user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        return View("Microbiome", new MicrobiomeViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
