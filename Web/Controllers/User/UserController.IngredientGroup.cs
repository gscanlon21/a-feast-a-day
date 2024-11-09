using Core.Consts;
using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
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
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = nutrient.DefaultRange();
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
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = nutrient.DefaultRange();
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
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = nutrient.DefaultRange();
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
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var nutrient in NutrientHelpers.All.Where(mg => nutrients.HasFlag(mg)))
        {
            var defaultRange = nutrient.DefaultRange();
            var userNutrient = await _context.UserNutrients.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == nutrient);
            if (userNutrient == null)
            {
                _context.UserNutrients.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = nutrient,
                    Start = defaultRange.Start.Value,
                    End = Math.Min(UserConsts.NutrientTargetMaxPercent, defaultRange.End.Value + UserConsts.IncrementNutrientTargetBy)
                });
            }
            else
            {
                userNutrient.End = Math.Min(UserConsts.NutrientTargetMaxPercent, userNutrient.End + UserConsts.IncrementNutrientTargetBy);

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
