using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Web.Components.Users;

public class AWorkoutADayViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "AWorkoutADay";

    public async Task<IViewComponentResult> InvokeAsync(User user, string token)
    {
        return View("AWorkoutADay");
    }
}
