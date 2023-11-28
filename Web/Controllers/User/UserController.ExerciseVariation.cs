using Core.Consts;
using Core.Models.Newsletter;
using Data.Dtos.Newsletter;
using Data.Entities.Exercise;
using Data.Entities.User;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web.Code;
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
      
        var userExercise = await context.UserExercises
            .IgnoreQueryFilters()
            .Include(ue => ue.Exercise)
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.ExerciseId == exerciseId);

        if (userExercise == null)
        {
            userExercise = new UserExercise()
            {
                UserId = user.Id,
                ExerciseId = exerciseId,
                Progression = user.IsNewToFitness ? UserConsts.MinUserProgression : UserConsts.MidUserProgression,
                Exercise = await context.Exercises.FirstAsync(e => e.Id == exerciseId),
            };

            context.UserExercises.Add(userExercise);
            await context.SaveChangesAsync();
        }

        var exercises = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreProgressions: true, ignorePrerequisites: true, ignoreIgnored: true, ignoreMissingEquipment: true, uniqueExercises: false)
            .WithExercises(x =>
            {
                x.AddExercises(new List<Data.Entities.Exercise.Exercise>(1) { userExercise.Exercise });
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new ExerciseVariationDto(r)
            .AsType<Lib.ViewModels.Newsletter.ExerciseVariationViewModel, ExerciseVariationDto>()!)
            .DistinctBy(vm => vm.Variation)
            .ToList();

        var exerciseViewModel = new UserManageExerciseViewModel()
        {
            Parameters = parameters,
            User = user,
            Exercise = userExercise.Exercise,
            Exercises = exercises,
            UserExercise = userExercise,
        };

        return View(new UserManageExerciseVariationViewModel()
        {
            WasUpdated = wasUpdated,
            Exercise = exerciseViewModel,
        });
    }

    /// <summary>
    /// Reduces the user's progression of an exercise.
    /// </summary>
    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/r", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/regress", Order = 2)]
    public async Task<IActionResult> ThatWorkoutWasTough(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserExercises
            .Include(p => p.Exercise)
            .FirstOrDefaultAsync(p => p.UserId == user.Id && p.ExerciseId == exerciseId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
    }

    /// <summary>
    /// Increases the user's progression of an exercise.
    /// </summary>
    [HttpPost]
    [Route("{section:section}/{exerciseId}/{variationId}/p", Order = 1)]
    [Route("{section:section}/{exerciseId}/{variationId}/progress", Order = 2)]
    public async Task<IActionResult> ThatWorkoutWasEasy(string email, string token, int exerciseId, int variationId, Section section)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserExercises
            .Include(p => p.Exercise)
            .FirstOrDefaultAsync(p => p.UserId == user.Id && p.ExerciseId == exerciseId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return RedirectToAction(nameof(ManageExerciseVariation), new { email, token, exerciseId, variationId, section, WasUpdated = true });
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
