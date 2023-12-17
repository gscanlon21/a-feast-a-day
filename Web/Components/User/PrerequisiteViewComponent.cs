using Data;
using Data.Repos;
using Lib.ViewModels.Newsletter;
using Lib.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class PrerequisiteViewComponent(IServiceScopeFactory serviceScopeFactory, CoreContext coreContext, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Prerequisite";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Data.Entities.Exercise.Exercise exercise)
    {
        var token = await userRepo.AddUserToken(user, durationDays: 1);


        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterViewModel, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);
        var viewModel = new PrerequisiteViewModel()
        {
            UserNewsletter = userNewsletter,
            VisiblePrerequisites = new List<ExerciseVariationViewModel>(),
            InvisiblePrerequisites = new List<ExerciseVariationViewModel>()
        };

        var userExercises = await coreContext.UserExercises
            .Where(ue => ue.UserId == user.Id)
            .ToListAsync();

        return View("Prerequisite", viewModel);
    }
}
