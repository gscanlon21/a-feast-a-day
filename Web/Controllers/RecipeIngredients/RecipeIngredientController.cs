using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.RecipeIngredient;
using Web.Views.Shared.Components.ManageRecipeIngredient;

namespace Web.Controllers.RecipeIngredients;

[Route($"ri/{UserRoute}", Order = 1)]
[Route($"recipe/ingredient/{UserRoute}", Order = 2)]
public class RecipeIngredientController : ViewController
{
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public RecipeIngredientController(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "RecipeIngredient";

    [HttpPost, Route("[action]/{recipeIngredientId}")]
    public async Task<IActionResult> IgnoreRecipeIngredient(string email, string token, int recipeIngredientId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userIngredient = await _context.UserRecipeIngredients
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            //.Where(ui => ui.RecipeId == recipeId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        // May be null if the ingredient was soft/hard deleted.
        if (userIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userIngredient.Ignore = !userIngredient.Ignore;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipeIngredient), new { email, token, recipeIngredientId, WasUpdated = true });
    }

    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet, Route("{recipeIngredientId}")]
    public async Task<IActionResult> ManageRecipeIngredient(string email, string token, int recipeIngredientId, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var recipeIngredient = await _context.RecipeIngredients.AsNoTracking()
            .Include(i => i.IngredientRecipe).Include(i => i.Ingredient).ThenInclude(i => i.Nutrients)
            // The ingredient alternatives, include their nutrients so we can show those on the page.
            .Include(i => i.Ingredient).ThenInclude(i => i.Alternatives).ThenInclude(ai => ai.AlternativeIngredient).ThenInclude(ai => ai.Nutrients)
            // For which ingredients is this ingredient is an alternative of. Don't need to include the nutrients for this.
            .Include(i => i.Ingredient).ThenInclude(i => i.AlternativeIngredients).ThenInclude(ai => ai.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == recipeIngredientId);

        if (recipeIngredient == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(nameof(ManageRecipeIngredient), new UserManageRecipeIngredientViewModel()
        {
            User = user,
            Token = token,
            WasUpdated = wasUpdated,
            RecipeIngredient = recipeIngredient,
            Parameters = new UserManageRecipeIngredientViewModel.Params(email, token, recipeIngredientId)
        });
    }

    [HttpPost, Route("{recipeIngredientId}")]
    public async Task<IActionResult> ManageRecipeIngredient(string email, string token, int recipeIngredientId, ManageRecipeIngredientViewModel viewModel)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (!ModelState.IsValid)
        {
            return await ManageRecipeIngredient(email, token, recipeIngredientId, wasUpdated: false);
        }

        var existingUserRecipeIngredient = await _context.UserRecipeIngredients
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (existingUserRecipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        existingUserRecipeIngredient.Notes = viewModel.UserRecipeIngredient.Notes;
        existingUserRecipeIngredient.SubstituteScale = viewModel.UserRecipeIngredient.SubstituteScale;
        existingUserRecipeIngredient.SubstituteRecipeId = viewModel.UserRecipeIngredient.SubstituteRecipeId;
        existingUserRecipeIngredient.SubstituteIngredientId = viewModel.UserRecipeIngredient.SubstituteIngredientId;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipeIngredient), new { email, token, recipeIngredientId, wasUpdated = true });
    }
}
