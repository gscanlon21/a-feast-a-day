using Core.Consts;
using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost]
    [Route("muscle/reset")]
    public async Task<IActionResult> ResetMuscleRanges(string email, string token, [Bind(Prefix = "muscleGroup")] IngredientGroup muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserIngredientGroups
            .Where(um => um.User.Id == user.Id)
            .Where(um => muscleGroups.HasFlag(um.Group))
            .ExecuteDeleteAsync();

        TempData[TempData_User.SuccessMessage] = "Your muscle targets have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("muscle/start/decrease")]
    public async Task<IActionResult> DecreaseStartMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] IngredientGroup muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserIngredientGroup.MuscleTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Group == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserIngredientGroup()
                {
                    UserId = user.Id,
                    Group = muscleGroup,
                    Start = Math.Max(UserIngredientGroup.MuscleTargetMin, UserIngredientGroup.MuscleTargets[muscleGroup].Start.Value - UserConsts.IncrementMuscleTargetBy),
                    End = UserIngredientGroup.MuscleTargets[muscleGroup].End.Value
                });
            }
            else
            {
                userMuscleGroup.Start = Math.Max(UserIngredientGroup.MuscleTargetMin, userMuscleGroup.Start - UserConsts.IncrementMuscleTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserIngredientGroup.MuscleTargets[muscleGroup]))
                {
                    context.UserIngredientGroups.Remove(userMuscleGroup);
                }
            }
        }

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your muscle target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("muscle/start/increase")]
    public async Task<IActionResult> IncreaseStartMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] IngredientGroup muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserIngredientGroup.MuscleTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Group == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserIngredientGroup()
                {
                    UserId = user.Id,
                    Group = muscleGroup,
                    Start = UserIngredientGroup.MuscleTargets[muscleGroup].Start.Value + UserConsts.IncrementMuscleTargetBy,
                    End = UserIngredientGroup.MuscleTargets[muscleGroup].End.Value
                });
            }
            else
            {
                userMuscleGroup.Start = Math.Min(userMuscleGroup.End - UserConsts.IncrementMuscleTargetBy, userMuscleGroup.Start + UserConsts.IncrementMuscleTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserIngredientGroup.MuscleTargets[muscleGroup]))
                {
                    context.UserIngredientGroups.Remove(userMuscleGroup);
                }
            }
        }

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your muscle target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("muscle/end/decrease")]
    public async Task<IActionResult> DecreaseEndMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] IngredientGroup muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserIngredientGroup.MuscleTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Group == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserIngredientGroup()
                {
                    UserId = user.Id,
                    Group = muscleGroup,
                    Start = UserIngredientGroup.MuscleTargets[muscleGroup].Start.Value,
                    End = UserIngredientGroup.MuscleTargets[muscleGroup].End.Value - UserConsts.IncrementMuscleTargetBy
                });
            }
            else
            {
                userMuscleGroup.End = Math.Max(userMuscleGroup.Start + UserConsts.IncrementMuscleTargetBy, userMuscleGroup.End - UserConsts.IncrementMuscleTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserIngredientGroup.MuscleTargets[muscleGroup]))
                {
                    context.UserIngredientGroups.Remove(userMuscleGroup);
                }
            }
        }

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your muscle target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("muscle/end/increase")]
    public async Task<IActionResult> IncreaseEndMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] IngredientGroup muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var muscleTargetMax = UserIngredientGroup.MuscleTargets.Values.MaxBy(v => v.End.Value).End.Value;
        foreach (var muscleGroup in UserIngredientGroup.MuscleTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Group == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserIngredientGroup()
                {
                    UserId = user.Id,
                    Group = muscleGroup,
                    Start = UserIngredientGroup.MuscleTargets[muscleGroup].Start.Value,
                    End = Math.Min(muscleTargetMax, UserIngredientGroup.MuscleTargets[muscleGroup].End.Value + UserConsts.IncrementMuscleTargetBy)
                });
            }
            else
            {
                userMuscleGroup.End = Math.Min(muscleTargetMax, userMuscleGroup.End + UserConsts.IncrementMuscleTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserIngredientGroup.MuscleTargets[muscleGroup]))
                {
                    context.UserIngredientGroups.Remove(userMuscleGroup);
                }
            }
        }

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your muscle target has been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
