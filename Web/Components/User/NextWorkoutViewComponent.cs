﻿using Core.Consts;
using Core.Models.User;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        DateOnly? nextSendDate = null;
        if (user.RestDays < Days.All)
        {
            nextSendDate = DateTime.UtcNow.Hour <= user.SendHour ? DateOnly.FromDateTime(DateTime.UtcNow) : DateOnly.FromDateTime(DateTime.UtcNow).AddDays(1);
            // Next send date is a rest day and user does not want off day workouts, next send date is the day after.
            while ((user.RestDays.HasFlag(DaysExtensions.FromDate(nextSendDate.Value)))
                // User was sent a newsletter for the next send date, next send date is the day after.
                // Checking for variations because we create a dummy newsletter record to advance the workout split.
                || await context.UserEmails
                    .Where(n => n.UserId == user.Id)
                    .Where(n => n.Subject == NewsletterConsts.SubjectWorkout)
                    .AnyAsync(n => n.Date == nextSendDate.Value)
                )
            {
                nextSendDate = nextSendDate.Value.AddDays(1);
            }
        }

        var nextSendDateTime = nextSendDate?.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.FromHours(user.SendHour)));
        var timeUntilNextSend = !nextSendDateTime.HasValue ? null : nextSendDateTime - DateTime.UtcNow;
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
