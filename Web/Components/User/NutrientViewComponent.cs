﻿using Core.Consts;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.Nutrient;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of how often each muscle the user has worked over the course of a month.
/// </summary>
public class NutrientViewComponent(UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Nutrient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        if (user == null)
        {
            return Content(string.Empty);
        }

        int weeks = int.TryParse(Request.Query["weeks"], out int weeksTmp) ? weeksTmp : UserConsts.TrainingVolumeWeeks;
        var (weeksOfData, weeklyMuscles) = await userRepo.GetWeeklyNutrientVolume(user, weeks);
        if (weeklyMuscles == null)
        {
            return Content(string.Empty);
        }

        //var usersWorkedMuscles = (await userRepo.GetUpcomingRotations(user, user.Frequency)).Aggregate(MuscleGroups.None, (curr, n) => curr | n.MuscleGroups.Aggregate(MuscleGroups.None, (curr2, n2) => curr2 | n2));
        return View("Nutrient", new NutrientViewModel()
        {
            User = user,
            Weeks = weeks,
            WeeksOfData = weeksOfData,
            WeeklyVolume = weeklyMuscles,
            UsersWorkedMuscles = Core.Models.User.Nutrients.All,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
