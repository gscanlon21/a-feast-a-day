using Data.Code.Extensions;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using static Data.Entities.Users.User;

namespace Web.Controllers.Users;

public partial class UserController
{
    /// <summary>
    /// Clears nutrient target data over 1 month old.
    /// </summary>
    [HttpPost, Route("nutrient/clear")]
    public async Task<IActionResult> ClearNutrientTargetData(string email, string token)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: false);
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
    public async Task<IActionResult> ResetNutrientRanges(string email, string token, [Bind(Prefix = "nutrient")] Core.Models.Nutrients.Nutrients nutrients)
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


    [HttpPost, Route("nutrient/save")]
    public async Task<IActionResult> SaveNutrientTargets(string email, string token, [Bind(Prefix = "nutrient")] Core.Models.Nutrients.Nutrients nutrients, double start, double end, double defaultStart, double defaultEnd)
    {
        var user = await _userRepo.GetUser(email, token, Includes.Families);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var defaultRange = user.UserFamilies.DefaultRange(nutrients);
        var userNutrient = await _context.UserNutrients
            .Where(un => un.Nutrient == nutrients)
            .Where(un => un.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userNutrient == null)
        {
            _context.UserNutrients.Add(new UserNutrient
            {
                UserId = user.Id,
                Nutrient = nutrients,
                Start = (int)(start / defaultStart * defaultRange.Start.Value),
                End = (int)(end / defaultEnd * defaultRange.End.Value),
            });
        }
        else
        {
            userNutrient.Start = (int)(start / defaultStart * defaultRange.Start.Value);
            userNutrient.End = (int)(end / defaultEnd * defaultRange.End.Value);
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient targets have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
