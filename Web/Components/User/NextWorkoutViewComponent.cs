using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.User.Components;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class NextWorkoutViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "NextWorkout";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var (_, timeUntilNextSend) = await userRepo.GetNextSendDate(user);
        if (!timeUntilNextSend.HasValue)
        {
            return Content("");
        }

        return View("NextWorkout", new NextWorkoutViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            TimeUntilNextSend = timeUntilNextSend,
            Today = DaysExtensions.FromDate(user.TodayOffset),
            NextWorkoutSendsToday = timeUntilNextSend.HasValue && DateOnly.FromDateTime(DateTime.UtcNow.Add(timeUntilNextSend.Value)) == user.TodayOffset
        });
    }
}
