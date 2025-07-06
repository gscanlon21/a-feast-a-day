using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Query.Builders;
using Data.Repos;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Web.Code.TempData;
using Web.Controllers.User;
using Web.Views.Recipe;
using Web.Views.Shared.Components.ManageRecipe;
using Web.Views.Shared.Components.UpsertRecipe;

namespace Web.Controllers.Recipes;

[Route($"r/{UserRoute}", Order = 1)]
[Route($"recipe/{UserRoute}", Order = 2)]
public class RecipeController : ViewController
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly NewsletterService _newsletterService;
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public RecipeController(CoreContext context, UserRepo userRepo, NewsletterService newsletterService, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _newsletterService = newsletterService;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "Recipe";

    /// <summary>
    /// Shows a form to the user where they can update their recipe.
    /// </summary>
    [HttpGet, Route("{section:section}/{recipeId}")]
    public async Task<IActionResult> ManageRecipe(string email, string token, int recipeId, Section section, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var recipe = await _context.Recipes.AsNoTracking()
            .Include(r => r.RecipeIngredients.OrderBy(ri => ri.Order))
            .Include(r => r.Instructions.OrderBy(i => i.Order))
            .FirstOrDefaultAsync(r => r.Id == recipeId);

        if (recipe == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        var hasUserRecipe = await _context.UserRecipes.AnyAsync(ur => ur.UserId == user.Id && ur.RecipeId == recipeId && ur.Section == section);
        return View(nameof(ManageRecipe), new UserManageRecipeViewModel()
        {
            User = user,
            Recipe = recipe,
            WasUpdated = wasUpdated,
            HasUserRecipe = hasUserRecipe,
            Parameters = new UserManageRecipeViewModel.Params(email, token, recipeId, section)
        });
    }

    [HttpPost, Route("{section:section}/[action]")]
    public async Task<IActionResult> UpsertRecipe(string email, string token, Section section, UpsertRecipeModel recipe)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (recipe.Id == default)
        {
            // Adding recipe.
            if (!ModelState.IsValid)
            {
                TempData[TempData_Recipe.UpsertRecipe] = JsonSerializer.Serialize(recipe);
                return RedirectToAction(nameof(UserController.Edit), UserController.Name, new { email, token, WasUpdated = false });
            }

            _context.Add(new Recipe()
            {
                User = user,
                Name = recipe.Name,
                Link = recipe.Link,
                Notes = recipe.Notes,
                Enabled = recipe.Enabled,
                Section = recipe.Section,
                Measure = recipe.Measure,
                Servings = recipe.Servings,
                CookTime = recipe.CookTime,
                PrepTime = recipe.PrepTime,
                BaseRecipe = recipe.BaseRecipe,
                AdjustableServings = recipe.AdjustableServings,
                KeepIngredientOrder = recipe.KeepIngredientOrder,
                Instructions = recipe.Instructions.Where(i => !i.Hide).ToList(),
                RecipeIngredients = recipe.RecipeIngredients.Where(i => !i.Hide).ToList()
            });

            await _context.SaveChangesAsync();
            TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
            return RedirectToAction(nameof(UserController.Edit), UserController.Name, new { email, token });
        }
        else
        {
            // Editing recipe.
            if (!ModelState.IsValid)
            {
                return await ManageRecipe(email, token, recipe.Id, section, wasUpdated: false);
            }

            var existingRecipe = await _context.Recipes
                .Include(r => r.Instructions)
                .Include(r => r.RecipeIngredients)
                .FirstOrDefaultAsync(r => r.Id == recipe.Id);
            if (existingRecipe == null)
            {
                return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
            }

            existingRecipe.Name = recipe.Name;
            existingRecipe.Link = recipe.Link;
            existingRecipe.Notes = recipe.Notes;
            existingRecipe.Section = recipe.Section;
            existingRecipe.Enabled = recipe.Enabled;
            existingRecipe.Measure = recipe.Measure;
            existingRecipe.Servings = recipe.Servings;
            existingRecipe.CookTime = recipe.CookTime;
            existingRecipe.PrepTime = recipe.PrepTime;
            existingRecipe.BaseRecipe = recipe.BaseRecipe;
            existingRecipe.AdjustableServings = recipe.AdjustableServings;
            existingRecipe.KeepIngredientOrder = recipe.KeepIngredientOrder;
            existingRecipe.Instructions = recipe.Instructions.Where(i => !i.Hide).ToList();
            existingRecipe.RecipeIngredients = recipe.RecipeIngredients.Where(i => !i.Hide).ToList();

            await _context.SaveChangesAsync();
            TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
            return RedirectToAction(nameof(ManageRecipe), new { email, token, section, recipeId = recipe.Id, wasUpdated = true });
        }
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> RemoveRecipe(string email, string token, [FromForm] int recipeId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // The user has control of this recipe and is not a built-in recipe.
        // Always try to delete recipes for the user because debug users can have their own recipes as well.
        await _context.Recipes.Where(r => r.UserId == user.Id).Where(r => r.Id == recipeId).ExecuteDeleteAsync();

        if (user.Features.HasFlag(Features.Debug))
        {
            // The recipe does not have a user and is a system recipe.
            await _context.Recipes.Where(r => r.UserId == null).Where(r => r.Id == recipeId).ExecuteDeleteAsync();
        }

        TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.Edit), UserController.Name, new { email, token });
    }

    [HttpPost, Route("{section:section}/{recipeId}/[action]")]
    public async Task<IActionResult> SkipRecipe(string email, string token, int recipeId, Section section)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipe = await _context.UserRecipes
            .Where(ur => ur.RecipeId == recipeId)
            .Where(ur => ur.Section == section)
            .Where(ur => ur.UserId == user.Id)
            .FirstAsync();

        // May be null if the recipe was soft/hard deleted.
        if (userRecipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Make sure the skip date persists for at least the feast's week...may carry over into next week as well.
        bool unskipped = !userRecipe.IgnoreUntil.HasValue || userRecipe.IgnoreUntil == DateOnly.MaxValue;
        userRecipe.IgnoreUntil = unskipped ? user.StartOfWeekOffset.AddDays(7) : null;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{recipeId}/[action]")]
    public async Task<IActionResult> SwapRecipe(string email, string token, int recipeId, Section section)
    {
        var user = await _userRepo.GetUser(email, token, includeServings: true, includeFamilies: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipe = await _context.UserRecipes
            .Where(ur => ur.RecipeId == recipeId)
            .Where(ur => ur.Section == section)
            .Where(ur => ur.UserId == user.Id)
            .FirstAsync();

        // May be null if the recipe was soft/hard deleted.
        if (userRecipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userFeast = await _userRepo.GetCurrentFeast(user);
        if (userFeast == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var feastRecipe = userFeast.UserFeastRecipes.FirstOrDefault(ufr => ufr.RecipeId == recipeId);
        if (feastRecipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // Delete the old recipe before querying to free up the nutrients.
        await _context.UserFeastRecipes.Where(ufr => ufr.Id == feastRecipe.Id).ExecuteDeleteAsync();

        var context = await _userRepo.BuildFeastContext(user, token, userFeast.Date);
        var serving = context.User.UserSections.FirstOrDefault(us => us.Section == feastRecipe.Section) ?? new UserSection(feastRecipe.Section);
        if (serving.Weight > 0)
        {
            var scale = serving.Weight / (double)context.User.UserSections.Sum(us => us.Weight);

            var newRecipe = (await new QueryBuilder(feastRecipe.Section)
                .WithUser(user)
                .WithNutrients(NutrientTargetsBuilder
                    .WithNutrients(context, NutrientHelpers.All)
                    .WithNutrientTargets()
                    .AdjustNutrientTargets(scale: 1), options =>
                    {
                        options.AtLeastXNutrientsPerRecipe = serving.AtLeastXNutrientsPerRecipe;
                    })
                .WithExcludeRecipes(x =>
                {
                    x.RecipeIds = userFeast.UserFeastRecipes.Select(ufr => ufr.RecipeId).ToList();
                })
                .WithSelectionOptions(options =>
                {
                    options.Randomized = context.IsBackfill;
                })
                .Build()
                .Query(_serviceScopeFactory, take: 1))
                .FirstOrDefault();

            if (newRecipe == null)
            {
                return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
            }

            _context.UserFeastRecipes.Add(new UserFeastRecipe(userFeast, newRecipe, feastRecipe.Order));
            await _context.SaveChangesAsync();
        }

        TempData[TempData_User.SuccessMessage] = "Your recipe has been swapped. Reload the feast to view the new recipe.";
        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{recipeId}/[action]")]
    public async Task<IActionResult> IgnoreRecipe(string email, string token, int recipeId, Section section)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipes = await _context.UserRecipes
            .Where(ur => ur.RecipeId == recipeId)
            .Where(ur => ur.UserId == user.Id)
            .ToListAsync();

        foreach (var userRecipe in userRecipes)
        {
            // Don't ignore the base "None" section if ignoring other sections.
            if (section != Section.None && userRecipe.Section == Section.None)
            {
                continue;
            }

            userRecipe.IgnoreUntil = userRecipe.IgnoreUntil != DateOnly.MaxValue ? DateOnly.MaxValue : null;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{recipeId}/[action]")]
    public async Task<IActionResult> RefreshRecipe(string email, string token, int recipeId, Section section)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipe = await _context.UserRecipes
            .Where(ur => ur.RecipeId == recipeId)
            .Where(ur => ur.Section == section)
            .Where(ur => ur.UserId == user.Id)
            .FirstAsync();

        // May be null if the recipe was soft/hard deleted.
        if (userRecipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userRecipe.RefreshAfter = null;
        userRecipe.LastSeen = userRecipe.LastSeen > DateHelpers.Today ? DateHelpers.Today : userRecipe.LastSeen;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }

    [HttpPost, Route("{section:section}/{recipeId}/[action]")]
    public async Task<IActionResult> LogRecipe(string email, string token, int recipeId, Section section, ManageRecipeViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = false });
        }

        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return NotFound();
        }

        var userRecipe = await _context.UserRecipes
            .Where(ur => ur.RecipeId == recipeId)
            .Where(ur => ur.Section == section)
            .Where(ur => ur.UserId == user.Id)
            .Include(ur => ur.Recipe)
            .FirstAsync();

        // Apply refresh padding immediately.
        if (viewModel.PadRefreshXWeeks != userRecipe.PadRefreshXWeeks && userRecipe.LastSeen > DateOnly.MinValue)
        {
            var difference = viewModel.PadRefreshXWeeks - userRecipe.PadRefreshXWeeks; // 11 new - 1 old = 10 weeks.
            userRecipe.LastSeen = userRecipe.LastSeen?.AddDays(7 * difference); // Add 70 days onto the LastSeen date.
        }

        // Apply refresh lagging immediately.
        if (viewModel.LagRefreshXWeeks != userRecipe.LagRefreshXWeeks)
        {
            var difference = viewModel.LagRefreshXWeeks - userRecipe.LagRefreshXWeeks; // 11 new - 1 old = 10 weeks.
            var refreshAfterOrTodayWithLag = (userRecipe.RefreshAfter ?? DateHelpers.Today).AddDays(7 * difference);
            userRecipe.RefreshAfter = refreshAfterOrTodayWithLag > DateHelpers.Today ? refreshAfterOrTodayWithLag : null;
            // NOTE: Not updating the LastSeen date if RefreshAfter is null, so the user may see this recipe again tomorrow.
        }

        userRecipe.Servings = viewModel.Servings;
        userRecipe.LagRefreshXWeeks = viewModel.LagRefreshXWeeks;
        userRecipe.PadRefreshXWeeks = viewModel.PadRefreshXWeeks;
        userRecipe.Notes = user.IsDemoUser ? null : viewModel.Notes;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }
}
