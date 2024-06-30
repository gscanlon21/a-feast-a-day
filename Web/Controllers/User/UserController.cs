using Core.Code.Helpers;
using Core.Consts;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Views.Index;
using Web.Views.Shared.Components.Advanced;
using Web.Views.User;

namespace Web.Controllers.User;

[Route($"u/{{email:regex({UserCreateViewModel.EmailRegex})}}", Order = 1)]
[Route($"user/{{email:regex({UserCreateViewModel.EmailRegex})}}", Order = 2)]
public partial class UserController(CoreContext context, UserRepo userRepo) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "User";

    /// <summary>
    /// The reason for disabling the user's account when directed by the user.
    /// </summary>
    public const string UserDisabledByUserReason = "Disabled by user.";

    /// <summary>
    /// Message to show to the user when a link has expired.
    /// </summary>
    public const string LinkExpiredMessage
        = "This link has expired.";

    #region Edit User

    /// <summary>
    /// Where the user edits their preferences.
    /// </summary>
    [HttpGet]
    [Route("", Order = 1)]
    [Route("e", Order = 2)]
    [Route("edit", Order = 3)]
    public async Task<IActionResult> Edit(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true, includeNutrients: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View("Edit", new UserEditViewModel(user, token)
        {
            WasUpdated = wasUpdated
        });
    }

    [HttpPost]
    [Route("", Order = 1)]
    [Route("e", Order = 2)]
    [Route("edit", Order = 3)]
    public async Task<IActionResult> Edit(string email, string token, UserEditViewModel viewModel)
    {
        if (token != viewModel.Token || email != viewModel.Email)
        {
            return NotFound();
        }

        viewModel.User = await userRepo.GetUser(viewModel.Email, viewModel.Token) ?? throw new ArgumentException(string.Empty, nameof(email));
        if (ModelState.IsValid)
        {
            try
            {
                viewModel.User.Verbosity = viewModel.Verbosity;
                viewModel.User.FootnoteType = viewModel.FootnoteType;
                viewModel.User.SendDay = viewModel.SendDay;
                viewModel.User.SendHour = viewModel.SendHour;
                viewModel.User.Equipment = viewModel.Equipment;
                viewModel.User.MaxIngredients = viewModel.MaxIngredients;
                viewModel.User.ExcludeAllergens = viewModel.ExcludeAllergens;

                context.UserFamilies.RemoveRange(context.UserFamilies.Where(uf => uf.UserId == viewModel.User.Id));
                context.UserFamilies.AddRange(viewModel.UserFamilies.Where(f => !f.Hide)
                    .Select(umm => new UserFamily()
                    {
                        UserId = umm.UserId,
                        Person = umm.Person,
                        CaloriesPerDay = umm.CaloriesPerDay,
                        Weight = umm.Weight
                    })
                );

                context.UserServings.RemoveRange(context.UserServings.Where(uf => uf.UserId == viewModel.User.Id));
                context.UserServings.AddRange(viewModel.UserServings
                    .Select(umm => new UserServing()
                    {
                        UserId = umm.UserId,
                        Count = umm.Count,
                        AtLeastXServingsPerRecipe = umm.AtLeastXServingsPerRecipe,
                        AtLeastXNutrientsPerRecipe = umm.AtLeastXNutrientsPerRecipe,
                        Section = umm.Section
                    })
                );

                if (viewModel.User.NewsletterEnabled != viewModel.NewsletterEnabled)
                {
                    viewModel.User.NewsletterDisabledReason = viewModel.NewsletterEnabled ? null : UserDisabledByUserReason;
                }

                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(context.Users?.Any(e => e.Email == viewModel.Email)).GetValueOrDefault())
                {
                    // User does not exist
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Edit), new { email, token, WasUpdated = true });
        }

        viewModel.WasUpdated = false;
        return View("Edit", viewModel);
    }

    #endregion
    #region Advanced Settings

    [HttpPost]
    [Route("e/a", Order = 1)]
    [Route("edit/advanced", Order = 2)]
    public async Task<IActionResult> EditAdvanced(string email, string token, AdvancedViewModel viewModel)
    {
        var user = await userRepo.GetUser(email, token) ?? throw new ArgumentException(string.Empty, nameof(email));
        if (ModelState.IsValid)
        {
            try
            {
                user.FootnoteCountTop = viewModel.FootnoteCountTop;
                user.FootnoteCountBottom = viewModel.FootnoteCountBottom;

                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(context.Users?.Any(e => e.Email == email)).GetValueOrDefault())
                {
                    // User does not exist
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Edit), new { email, token, WasUpdated = true });
        }

        return RedirectToAction(nameof(Edit), new { email, token, WasUpdated = true });
    }

    #endregion
    #region Still Active Redirect

    /// <summary>
    /// Updates the user's LastActive date and redirects them to their final destination.
    /// </summary>
    [HttpGet]
    [Route("r", Order = 1)]
    [Route("redirect", Order = 2)]
    public async Task<IActionResult> IAmStillHere(string email, string token, string? to = null, string? redirectTo = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userIsConfirmingAccount = !user.LastActive.HasValue;
        user.LastActive = DateOnly.FromDateTime(DateTime.UtcNow);
        await context.SaveChangesAsync();

        if (!string.IsNullOrWhiteSpace(to))
        {
            return Redirect(to);
        }

        if (!string.IsNullOrWhiteSpace(redirectTo))
        {
            return Redirect(redirectTo);
        }

        // User is enabling their account or preventing it from being disabled for inactivity.
        TempData[TempData_User.SuccessMessage] = userIsConfirmingAccount
            ? "Thank you! Your first workout is on its way."
            : "Thank you! Take a moment to update your Workout Intensity to avoid adaptions.";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    #endregion
    #region Workout Split

    [HttpPost]
    [Route("split/progress")]
    public async Task<IActionResult> AdvanceSplit(string email, string token)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Add a dummy newsletter to advance the workout split
        var newsletter = new Data.Entities.Newsletter.UserFeast(DateHelpers.Today, user);
        context.UserFeasts.Add(newsletter);

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your workout split has been advanced!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    #endregion
    #region User Tokens

    [HttpPost]
    [Route("token/create")]
    public async Task<IActionResult> CreateToken(string email, string token)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Delete old app tokens
        await context.UserTokens
            .Where(ut => ut.UserId == user.Id)
            .Where(ut => ut.Expires == DateTime.MaxValue)
            .ExecuteDeleteAsync();

        var newToken = await userRepo.AddUserToken(user, DateTime.MaxValue);
        TempData[TempData_User.SuccessMessage] = $"Your new app token: {newToken}"; // For your security we wonʼt show this password again, so make sure youʼve got it right before you close this dialog.
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    #endregion
}
