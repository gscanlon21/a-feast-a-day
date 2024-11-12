using Core.Consts;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Clears nutrient target data over 1 month old.
    /// </summary>
    [HttpPost, Route("nutrient/clear")]
    public async Task<IActionResult> ClearNutrientTargetData(string email, string token)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Delete all feasts older than this week, so the user's current feast doesn't change.
        // Nutrient adjustments ignore the current week, so leaving the current feast won't affect those.
        await _context.UserFeasts.Where(uw => uw.UserId == user.Id)
            .Where(uw => uw.Date < user.StartOfWeekOffset).ExecuteDeleteAsync();

        // Back-fill several weeks of feasts so nutrient targets can take effect immediately.
        await _newsletterService.Backfill(user.Email, token);

        TempData[TempData_User.SuccessMessage] = "Your nutrient target data has been reset!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("nutrient/reset")]
    public async Task<IActionResult> ResetNutrientRanges(string email, string token, [Bind(Prefix = "nutrient")] Nutrients nutrients)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await _context.UserNutrients
            .Where(um => um.User.Id == user.Id)
            .Where(um => nutrients.HasFlag(um.Nutrient))
            .ExecuteDeleteAsync();

        TempData[TempData_User.SuccessMessage] = "Your nutrient targets have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("nutrient/start/decrease")]
    public async Task<IActionResult> DecreaseStartNutrientRange(string email, string token, [Bind(Prefix = "nutrient")] Nutrients nutrients)
    {
        var user = await _userRepo.GetUser(email, token, includeFamilies: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = user.UserFamilies.DefaultRange(nutrient);
            var userNutrient = await _context.UserNutrients.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == nutrient);
            if (userNutrient == null)
            {
                _context.UserNutrients.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = nutrient,
                    Start = Math.Max(UserNutrient.NutrientTargetMin, defaultRange.Start.Value - UserConsts.IncrementNutrientTargetBy),
                    End = defaultRange.End.Value
                });
            }
            else
            {
                userNutrient.Start = Math.Max(UserNutrient.NutrientTargetMin, userNutrient.Start - UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userNutrient.Range.Equals(defaultRange))
                {
                    _context.UserNutrients.Remove(userNutrient);
                }
            }
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("nutrient/start/increase")]
    public async Task<IActionResult> IncreaseStartNutrientRange(string email, string token, [Bind(Prefix = "nutrient")] Nutrients nutrients)
    {
        var user = await _userRepo.GetUser(email, token, includeFamilies: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = user.UserFamilies.DefaultRange(nutrient);
            var userNutrient = await _context.UserNutrients.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == nutrient);
            if (userNutrient == null)
            {
                _context.UserNutrients.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = nutrient,
                    Start = defaultRange.Start.Value + UserConsts.IncrementNutrientTargetBy,
                    End = defaultRange.End.Value
                });
            }
            else
            {
                userNutrient.Start = Math.Min(userNutrient.End - UserConsts.IncrementNutrientTargetBy, userNutrient.Start + UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userNutrient.Range.Equals(defaultRange))
                {
                    _context.UserNutrients.Remove(userNutrient);
                }
            }
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("nutrient/end/decrease")]
    public async Task<IActionResult> DecreaseEndNutrientRange(string email, string token, [Bind(Prefix = "nutrient")] Nutrients nutrients)
    {
        var user = await _userRepo.GetUser(email, token, includeFamilies: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = user.UserFamilies.DefaultRange(nutrient);
            var userNutrient = await _context.UserNutrients.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == nutrient);
            if (userNutrient == null)
            {
                _context.UserNutrients.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = nutrient,
                    Start = defaultRange.Start.Value,
                    End = defaultRange.End.Value - UserConsts.IncrementNutrientTargetBy
                });
            }
            else
            {
                userNutrient.End = Math.Max(userNutrient.Start + UserConsts.IncrementNutrientTargetBy, userNutrient.End - UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userNutrient.Range.Equals(defaultRange))
                {
                    _context.UserNutrients.Remove(userNutrient);
                }
            }
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost, Route("nutrient/end/increase")]
    public async Task<IActionResult> IncreaseEndNutrientRange(string email, string token, [Bind(Prefix = "nutrient")] Nutrients nutrients)
    {
        var user = await _userRepo.GetUser(email, token, includeFamilies: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = user.UserFamilies.DefaultRange(nutrient);
            var userNutrient = await _context.UserNutrients.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == nutrient);
            if (userNutrient == null)
            {
                _context.UserNutrients.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = nutrient,
                    Start = defaultRange.Start.Value,
                    End = Math.Min(defaultRange.End.Value, defaultRange.End.Value + UserConsts.IncrementNutrientTargetBy)
                });
            }
            else
            {
                userNutrient.End = Math.Min(defaultRange.End.Value, userNutrient.End + UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userNutrient.Range.Equals(defaultRange))
                {
                    _context.UserNutrients.Remove(userNutrient);
                }
            }
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
