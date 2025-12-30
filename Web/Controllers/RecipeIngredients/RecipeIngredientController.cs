using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Query;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Web.Code.Extensions;
using Web.Code.TempData;
using Web.Views.RecipeIngredient;

namespace Web.Controllers.RecipeIngredients;

[Route($"ri/{UserRoute}", Order = 1)]
[Route($"recipe/ingredient/{UserRoute}", Order = 2)]
public class RecipeIngredientController : ViewController
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public RecipeIngredientController(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
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
    /// Shows a form to the user where they can manage their recipe ingredients.
    /// </summary>
    [HttpGet, Route("{recipeIngredientId}")]
    public async Task<IActionResult> ManageRecipeIngredient(string email, string token, int recipeIngredientId, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        // AlternativeIngredientss are required for the select list.
        // IngredientRecipe is required for the name of the recipe ingredient.
        var recipeIngredient = await _context.RecipeIngredients.AsNoTracking()
            .Include(ri => ri.IngredientRecipe)
            .Include(i => i.Ingredient)
                .ThenInclude(i => i.Alternatives.Where(a => (a.AlternativeIngredient.Allergens & user.Allergens) == 0))
                    .ThenInclude(ai => ai.AlternativeIngredient)
            .Where(r => r.Id == recipeIngredientId)
            .FirstOrDefaultAsync();

        if (recipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipeIngredient = await _context.UserRecipeIngredients.AsNoTracking()
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userRecipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var substitutionRecipes = await GetBaseRecipes(user);
        var recipes = await GetBaseRecipeResults(user, substitutionRecipes, recipeIngredient);
        var recipe = recipes.FirstOrDefault(r => r.Recipe.Id == recipeIngredient.RecipeId);
        if (recipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var prepRecipes = recipes.Where(r => recipe.RecipeIngredients.Select(ri => ri.IngredientRecipeId).Contains(r.Recipe.Id)).ToList();
        var substituteIngredients = recipeIngredient.Ingredient?.Alternatives.Select(ai => ai.AlternativeIngredient).Where(ai => ai.DisabledReason == null).ToList()
            // Not excluding allergens from a user's custom ingredients because I assume they know what they want.
            ?? await _context.Ingredients.Where(i => i.UserId == null || i.UserId == user.Id).ToListAsync();

        // Restore the failed UserRecipeIngredient if the upsert model validation failed.
        var viewModel = TempData.ReadModel<UserRecipeIngredientViewModel>(nameof(UserRecipeIngredientViewModel));
        return View(nameof(ManageRecipeIngredient), new UserManageRecipeIngredientViewModel()
        {
            User = user,
            Token = token,
            WasUpdated = wasUpdated,
            Recipes = substitutionRecipes,
            Ingredients = substituteIngredients,
            RecipeIngredient = recipeIngredient,
            Recipe = recipe.AsType<NewsletterRecipeDto>()!,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            PrepRecipes = prepRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            UserRecipeIngredient = viewModel ?? new UserRecipeIngredientViewModel(userRecipeIngredient),
            AltRecipes = recipes.ExceptBy([recipe.Recipe.Id], r => r.Recipe.Id).Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        });
    }

    [HttpPost, Route("{recipeIngredientId}")]
    public async Task<IActionResult> ManageRecipeIngredient(string email, string token, int recipeIngredientId,
        [Bind(Prefix = nameof(UserManageRecipeIngredientViewModel.UserRecipeIngredient))] UserRecipeIngredientViewModel viewModel)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (!ModelState.IsValid)
        {
            TempData[nameof(UserRecipeIngredientViewModel)] = JsonSerializer.Serialize(viewModel);
            TempData[TempData_User.FailureMessage] = ModelState.GetHtmlListOfErrors(); // Post-Redirect-Get for GoBackOnSave.
            return RedirectToAction(nameof(ManageRecipeIngredient), new { email, token, recipeIngredientId, WasUpdated = false });
        }

        var existingUserRecipeIngredient = await _context.UserRecipeIngredients
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (existingUserRecipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        existingUserRecipeIngredient.Measure = viewModel.Measure;
        existingUserRecipeIngredient.QuantityNumerator = viewModel.QuantityNumerator;
        existingUserRecipeIngredient.QuantityDenominator = viewModel.QuantityDenominator;
        existingUserRecipeIngredient.SubstituteIngredientId = viewModel.SubstituteIngredientId;
        existingUserRecipeIngredient.SubstituteRecipeId = viewModel.SubstituteRecipeId;
        existingUserRecipeIngredient.Notes = viewModel.Notes?.NullIfEmpty();
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipeIngredient), new { email, token, recipeIngredientId, wasUpdated = true });
    }

    /// <summary>
    /// Get recipes that the user is able to select as an ingredient alternative.
    /// </summary>
    private async Task<IList<Recipe>> GetBaseRecipes(User user)
    {
        return await _context.Recipes.AsNoTracking().TagWithCallSite()
            .Where(r => r.UserId == null || r.UserId == user.Id) // Has any flag:
            .Where(r => r.Instructions.All(i => (i.Equipment & user.Equipment) != 0 || i.Equipment == Equipment.None))
            .Where(r => r.BaseRecipe)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    /// <summary>
    /// Get query results for the base recipes and original recipe ingredient.
    /// </summary>
    private async Task<IList<QueryResults>> GetBaseRecipeResults(User user, IList<Recipe> baseRecipes, RecipeIngredient recipeIngredient)
    {
        return await new UserQueryBuilder(user, Section.None)
            // Pass in the user so we can select their base recipes.
            .WithUser(options =>
            {
                options.IgnoreIgnored = true;
            })
            .WithEquipment(Equipment.All)
            .WithRecipes(x =>
            {
                if (bool.TryParse(Request.Query["showBase"], out bool showBase) && showBase)
                {
                    x.AddRecipes(baseRecipes);
                }
                x.AddRecipes(new Dictionary<int, int?>
                {
                    [recipeIngredient.RecipeId] = null,
                });
            })
            .Build()
            .Query(_serviceScopeFactory);
    }
}
