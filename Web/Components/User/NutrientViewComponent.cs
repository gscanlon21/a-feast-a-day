using Core.Models.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Web.Views.Shared.Components.Nutrient;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of how often each nutrient the user has worked over the course of a month.
/// </summary>
public class NutrientViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;

    public NutrientViewComponent(UserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "Nutrient";

    [SuppressMessage("Style", "IDE0075:Simplify conditional expression", Justification = "Easier to read as is.")]
    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        if (user == null)
        {
            return Content(string.Empty);
        }

        var weeks = int.TryParse(Request.Query["weeks"], out int weeksTmp) ? weeksTmp : UserConsts.NutrientVolumeWeeks;
        var includeToday = bool.TryParse(Request.Query["includeToday"], out bool includeTodayTmp) ? includeTodayTmp : true;
        var (weeksOfData, weeklyMuscles) = await _userRepo.GetWeeklyNutrientVolume(user, weeks, includeToday: includeToday);
        if (weeklyMuscles == null)
        {
            return Content(string.Empty);
        }

        return View("Nutrient", new NutrientViewModel()
        {
            User = user,
            Token = token,
            Weeks = weeks,
            WeeksOfData = weeksOfData,
            WeeklyVolume = weeklyMuscles,
            // Removing calories since that should be changed from a user family.
            UsersWorkedNutrients = NutrientHelpers.All.Where(n => n != Nutrients.Calories).ToList(),
        });
    }
}
