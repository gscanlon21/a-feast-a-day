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
    public async Task<IActionResult> ResetMuscleRanges(string email, string token, [Bind(Prefix = "muscleGroup")] Nutrients muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserIngredientGroups
            .Where(um => um.User.Id == user.Id)
            .Where(um => muscleGroups.HasFlag(um.Nutrient))
            .ExecuteDeleteAsync();

        TempData[TempData_User.SuccessMessage] = "Your muscle targets have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("muscle/start/decrease")]
    public async Task<IActionResult> DecreaseStartMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] Nutrients muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserNutrient.NutrientTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = muscleGroup,
                    Start = Math.Max(UserNutrient.MuscleTargetMin, UserNutrient.NutrientTargets[muscleGroup].Start.Value - UserConsts.IncrementNutrientTargetBy),
                    End = UserNutrient.NutrientTargets[muscleGroup].End.Value
                });
            }
            else
            {
                userMuscleGroup.Start = Math.Max(UserNutrient.MuscleTargetMin, userMuscleGroup.Start - UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserNutrient.NutrientTargets[muscleGroup]))
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
    public async Task<IActionResult> IncreaseStartMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] Nutrients muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserNutrient.NutrientTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = muscleGroup,
                    Start = UserNutrient.NutrientTargets[muscleGroup].Start.Value + UserConsts.IncrementNutrientTargetBy,
                    End = UserNutrient.NutrientTargets[muscleGroup].End.Value
                });
            }
            else
            {
                userMuscleGroup.Start = Math.Min(userMuscleGroup.End - UserConsts.IncrementNutrientTargetBy, userMuscleGroup.Start + UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserNutrient.NutrientTargets[muscleGroup]))
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
    public async Task<IActionResult> DecreaseEndMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] Nutrients muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        foreach (var muscleGroup in UserNutrient.NutrientTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = muscleGroup,
                    Start = UserNutrient.NutrientTargets[muscleGroup].Start.Value,
                    End = UserNutrient.NutrientTargets[muscleGroup].End.Value - UserConsts.IncrementNutrientTargetBy
                });
            }
            else
            {
                userMuscleGroup.End = Math.Max(userMuscleGroup.Start + UserConsts.IncrementNutrientTargetBy, userMuscleGroup.End - UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserNutrient.NutrientTargets[muscleGroup]))
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
    public async Task<IActionResult> IncreaseEndMuscleRange(string email, string token, [Bind(Prefix = "muscleGroup")] Nutrients muscleGroups)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var muscleTargetMax = UserNutrient.NutrientTargets.Values.MaxBy(v => v.End.Value).End.Value;
        foreach (var muscleGroup in UserNutrient.NutrientTargets.Keys.Where(mg => muscleGroups.HasFlag(mg)))
        {
            var userMuscleGroup = await context.UserIngredientGroups.FirstOrDefaultAsync(um => um.User.Id == user.Id && um.Nutrient == muscleGroup);
            if (userMuscleGroup == null)
            {
                context.UserIngredientGroups.Add(new UserNutrient()
                {
                    UserId = user.Id,
                    Nutrient = muscleGroup,
                    Start = UserNutrient.NutrientTargets[muscleGroup].Start.Value,
                    End = Math.Min(muscleTargetMax, UserNutrient.NutrientTargets[muscleGroup].End.Value + UserConsts.IncrementNutrientTargetBy)
                });
            }
            else
            {
                userMuscleGroup.End = Math.Min(muscleTargetMax, userMuscleGroup.End + UserConsts.IncrementNutrientTargetBy);

                // If the user target matches the default, delete this range so that any default updates take effect.
                if (userMuscleGroup.Range.Equals(UserNutrient.NutrientTargets[muscleGroup]))
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
