using Core.Consts;
using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.NextFeast;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next feast will become available.
/// </summary>
public class NextFeastViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "NextFeast";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        var nextSendDate = DateTime.UtcNow.Hour <= user.SendHour ? DateHelpers.Today : DateHelpers.Today.AddDays(1);
        // Next send date is a rest day and user is not the debug user, next send date is the day after.
        while ((user.SendDay != nextSendDate.DayOfWeek && !user.Features.HasFlag(Features.Debug))
            // User was sent a newsletter for the next send date, next send date is the day after.
            || await context.UserEmails
                .Where(n => n.UserId == user.Id)
                .Where(n => n.Subject == NewsletterConsts.SubjectFeast)
                .AnyAsync(n => n.Date == nextSendDate)
            )
        {
            nextSendDate = nextSendDate.AddDays(1);
        }

        var nextSendDateTime = nextSendDate.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.FromHours(user.SendHour)));
        var timeUntilNextSend = nextSendDateTime - DateTime.UtcNow;
        return View("NextFeast", new NextFeastViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            TimeUntilNextSend = timeUntilNextSend,
        });
    }
}
