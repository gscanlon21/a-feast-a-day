using Core.Dtos.Ingredient;
using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Query;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Web.Code.Extensions;
using Web.Code.TempData;
using Web.Views.RecipeIngredients;

namespace Web.Controllers.RecipeIngredients;

[Route($"ri/{UserRoute}", Order = 1)]
[Route($"recipe/ingredient/{UserRoute}", Order = 2)]
public class RecipeIngredientsController : ViewController
{
    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "RecipeIngredients";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RecipeIngredientsController(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

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
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true, includeFoodPreferences: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var allergens = user.UserFoodPreferences
            .Where(f => f.FoodPreference == FoodPreference.Exclude)
            .Aggregate(Allergens.None, (c, n) => c | n.Allergen);

        // AlternativeIngredientss are required for the select list.
        // IngredientRecipe is required for the name of the recipe ingredient.
        var recipeIngredient = await _context.RecipeIngredients.AsNoTracking()
            .Include(ri => ri.IngredientRecipe)
            .Include(i => i.Ingredient)
                .ThenInclude(i => i.Alternatives.Where(a => (a.AlternativeIngredient.Allergens & allergens) == 0))
                    .ThenInclude(ai => ai.AlternativeIngredient)
            .Where(r => r.Id == recipeIngredientId)
            .FirstOrDefaultAsync();

        if (recipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userRecipeIngredient = await _context.UserRecipeIngredients.AsNoTracking()
            .Include(uri => uri.SubstituteIngredient)
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userRecipeIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var baseRecipes = await GetBaseRecipes(user);
        var recipe = await GetOrigRecipe(user, recipeIngredient);
        if (recipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var prepRecipes = baseRecipes.Where(r => recipe.RecipeIngredients.Select(ri => ri.IngredientRecipeId).Contains(r.Recipe.Id)).ToList();
        var substituteIngredients = recipeIngredient.Ingredient?.Alternatives.Select(ai => ai.AlternativeIngredient).Where(ai => ai.DisabledReason == null).ToList()
            // Not excluding allergens from a user's custom ingredients because I assume they know what they want.
            ?? await _context.Ingredients.Where(i => i.UserId == null || i.UserId == user.Id)
            .OrderBy(i => i.Group).ThenBy(i => i.Name).ToListAsync();

        // Ingredients to show to the user.
        var ingredients = new List<IngredientDto?>()
        {
            recipeIngredient.Ingredient?.AsType<IngredientDto>(),
            userRecipeIngredient.SubstituteIngredient?.AsType<IngredientDto>(),
        }.RemoveNullEntries();

        // Restore the failed UserRecipeIngredient if the upsert model validation failed.
        var viewModel = TempData.ReadModel<UserRecipeIngredientViewModel>(nameof(UserRecipeIngredientViewModel));
        return View(nameof(ManageRecipeIngredient), new UserManageRecipeIngredientViewModel()
        {
            User = user,
            Token = token,
            WasUpdated = wasUpdated,
            Ingredients = ingredients,
            RecipeIngredient = recipeIngredient,
            SubstituteIngredients = substituteIngredients,
            Recipe = recipe.AsType<NewsletterRecipeDto>()!,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            PrepRecipes = prepRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            BaseRecipes = baseRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            UserRecipeIngredient = viewModel ?? new UserRecipeIngredientViewModel(userRecipeIngredient),
            BaseRecipeSelect = baseRecipes.ConvertAll(r => new SelectListItem(r.Recipe.Name, r.Recipe.Id.ToString())),
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
    /// Get query results for the user's available base recipes.
    /// </summary>
    private async Task<List<QueryResults>> GetBaseRecipes(User user)
    {
        // Pass in the user so we can select their base recipes.
        return await new UserQueryBuilder(user, Section.Prep)
            .WithEquipment(Equipment.All)
            .Build()
            .Query(_serviceScopeFactory, OrderBy.Name);
    }

    /// <summary>
    /// Get query results for the original recipe ingredient.
    /// </summary>
    private async Task<QueryResults?> GetOrigRecipe(User user, RecipeIngredient recipeIngredient)
    {
        // Pass in the user so we can select their base recipes.
        return (await new UserQueryBuilder(user, Section.None)
            .WithUser(options =>
            {
                options.IgnoreIgnored = true;
                options.MaxIngredients = null;
                options.FoodPreferences.Clear();
            })
            .WithEquipment(Equipment.All)
            .WithRecipes(x =>
            {
                x.IgnorePrepRecipes = true;
                x.AddRecipes(new Dictionary<int, int?>
                {
                    [recipeIngredient.RecipeId] = null,
                });
            })
            .Build()
            .Query(_serviceScopeFactory))
            .FirstOrDefault();
    }
}
