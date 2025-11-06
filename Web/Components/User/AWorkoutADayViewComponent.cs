using Microsoft.AspNetCore.Mvc;

namespace Web.Components.User;

public class AWorkoutADayViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "AWorkoutADay";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, string token)
    {
        return View("AWorkoutADay");
    }
}
