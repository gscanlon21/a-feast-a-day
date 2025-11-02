using Data;
using Data.Entities.User;
using Data.Repos;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Views.Shared.Components.Advanced;
using Web.Views.Shared.Components.Edit;
using Web.Views.User;

namespace Web.Controllers.User;

[Route($"u/{UserRoute}", Order = 1)]
[Route($"user/{UserRoute}", Order = 2)]
public partial class UserController : ViewController
{
    private readonly NewsletterService _newsletterService;
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public UserController(CoreContext context, UserRepo userRepo, NewsletterService newsletterService)
    {
        _context = context;
        _userRepo = userRepo;
        _newsletterService = newsletterService;
    }

    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "User";

    /// <summary>
    /// The reason for disabling the user's account when directed by the user.
    /// </summary>
    public const string UserDisabledByUserReason = "Disabled by user.";

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
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true, includeNutrients: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View("Edit", new UserEditViewModel(user)
        {
            WasUpdated = wasUpdated,
        });
    }

    [HttpPost]
    [Route("", Order = 1)]
    [Route("e", Order = 2)]
    [Route("edit", Order = 3)]
    public async Task<IActionResult> Edit(string email, string token, EditComponentViewModel viewModel)
    {
        if (token != viewModel.Token || email != viewModel.Email)
        {
            return NotFound();
        }

        viewModel.User = await _userRepo.GetUser(viewModel.Email, viewModel.Token) ?? throw new ArgumentException(string.Empty, nameof(email));
        if (!ModelState.IsValid)
        {
            viewModel.WasUpdated = false;
            return View("Edit", viewModel);
        }

        try
        {
            viewModel.User.SendDay = viewModel.SendDay;
            viewModel.User.SendHour = viewModel.SendHour;
            viewModel.User.Equipment = viewModel.Equipment;
            viewModel.User.Allergens = viewModel.Allergens;
            viewModel.User.Verbosity = viewModel.Verbosity;
            viewModel.User.FootnoteType = viewModel.FootnoteType;
            viewModel.User.MaxIngredients = viewModel.MaxIngredients;
            viewModel.User.FontSizeAdjust = viewModel.FontSizeAdjust;

            var oldUserFamilies = await _context.UserFamilies.Where(uf => uf.UserId == viewModel.User.Id).ToListAsync();
            var newUserFamilies = viewModel.UserFamilies.Where(f => !f.Hide).Select(umm => new UserFamily(viewModel.User)
            {
                Person = umm.Person,
                CaloriesPerDay = umm.CaloriesPerDay,
                Weight = umm.Weight
            });
            _context.UserFamilies.RemoveRange(oldUserFamilies);
            _context.UserFamilies.AddRange(newUserFamilies);

            _context.UserSections.RemoveRange(_context.UserSections.Where(uf => uf.UserId == viewModel.User.Id));
            _context.UserSections.AddRange(viewModel.UserSections.Select(umm => new UserSection(viewModel.User, umm.Section)
            {
                Weight = umm.Weight,
                AtLeastXNutrientsPerRecipe = umm.AtLeastXNutrientsPerRecipe,
            }));

            if (viewModel.User.NewsletterEnabled != viewModel.NewsletterEnabled)
            {
                viewModel.User.NewsletterDisabledReason = viewModel.NewsletterEnabled ? null : UserDisabledByUserReason;
            }

            await _context.SaveChangesAsync();

            if (!oldUserFamilies.SequenceEqual(newUserFamilies, new UserFamily.PersonComparer()))
            {
                // Back-fill new nutrient target data when switching family members, so we're not weighting with old data.
                return await ClearNutrientTargetData(viewModel.User.Email, viewModel.Token);
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!(_context.Users?.Any(e => e.Email == viewModel.Email)).GetValueOrDefault())
            {
                // User does not exist.
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction(nameof(Edit), new { email, token, WasUpdated = true });
    }

    #endregion
    #region Advanced Settings

    [HttpPost]
    [Route("e/a", Order = 1)]
    [Route("edit/advanced", Order = 2)]
    public async Task<IActionResult> EditAdvanced(string email, string token, AdvancedViewModel viewModel)
    {
        var user = await _userRepo.GetUser(email, token) ?? throw new ArgumentException(string.Empty, nameof(email));
        if (ModelState.IsValid)
        {
            try
            {
                user.IngredientOrder = viewModel.IngredientOrder;
                user.FootnoteCountTop = viewModel.FootnoteCountTop;
                user.FootnoteCountBottom = viewModel.FootnoteCountBottom;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.Users?.Any(e => e.Email == email)).GetValueOrDefault())
                {
                    // User does not exist.
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
    public async Task<IActionResult> IAmStillHere(string email, string token, string? to = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userIsConfirmingAccount = !user.LastActive.HasValue;
        user.LastActive = DateHelpers.Today;
        await _context.SaveChangesAsync();

        if (!string.IsNullOrWhiteSpace(to))
        {
            return Redirect(to);
        }

        // User is enabling their account or preventing it from being disabled for inactivity.
        TempData[TempData_User.SuccessMessage] = userIsConfirmingAccount
            ? "Thank you! Your first feast is on its way."
            : "Thank you!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    #endregion
    #region User Tokens

    [HttpPost, Route("token/create")]
    public async Task<IActionResult> CreateToken(string email, string token)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Delete old app tokens.
        await _context.UserTokens
            .Where(ut => ut.UserId == user.Id)
            .Where(ut => ut.Expires == DateTime.MaxValue)
            .ExecuteDeleteAsync();

        var newToken = await _userRepo.AddUserToken(user, DateTime.MaxValue);
        TempData[TempData_User.SuccessMessage] = $"Your new app token: {newToken}"; // For your security we wonʼt show this password again, so make sure youʼve got it right before you close this dialog.
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    #endregion
}
