using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("{section:section}/{exerciseId}/{variationId}", Order = 1)]
    public async Task<IActionResult> ManageExerciseVariation(string email, string token, int exerciseId, int variationId, Section section, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageExerciseVariationViewModel.Parameters(section, email, token, exerciseId, variationId);

        var exerciseViewModel = new UserManageExerciseViewModel()
        {
            Parameters = parameters,
            User = user,
        };

        return View(new UserManageExerciseVariationViewModel()
        {
            WasUpdated = wasUpdated,
            Exercise = exerciseViewModel,
        });
    }

    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/ie", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/ignore-exercise", Order = 2)]
    public async Task<IActionResult> IgnoreExercise(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/re", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/refresh-exercise", Order = 2)]
    public async Task<IActionResult> RefreshExercise(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/iv", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/ignore-variation", Order = 2)]
    public async Task<IActionResult> IgnoreVariation(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/rv", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/refresh-variation", Order = 2)]
    public async Task<IActionResult> RefreshVariation(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/l", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/log", Order = 2)]
    public async Task<IActionResult> LogVariation(string email, string token, int exerciseId, int variationId, Section section, [Range(0, 999)] int weight)
    {
        if (ModelState.IsValid)
        {
            var user = await userRepo.GetUser(email, token, allowDemoUser: true);
            if (user == null)
            {
                return NotFound();
            }


            await context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
        }

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = false });
    }
}
