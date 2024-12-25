using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Microbiome;

namespace Web.Components.User;

public class MicrobiomeViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Microbiome";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        return View("Microbiome", new MicrobiomeViewModel()
        {
            User = user,
            Token = token,
        });
    }
}
