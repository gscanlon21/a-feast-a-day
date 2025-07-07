using Core.Dtos.Ingredient;
using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Data;
using Data.Entities.Recipe;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        var userRecipeIngredient = await _context.UserRecipeIngredients.AsNoTracking()
            .Where(ui => ui.RecipeIngredientId == recipeIngredientId)
            //.Where(ui => ui.RecipeId == parameters.RecipeId)
            .Where(ui => ui.UserId == user.Id)
            .FirstOrDefaultAsync();

        var substitutionRecipes = await GetRecipes(user);
        var recipeDtos = (await new QueryBuilder(Section.None)
            .WithUser(user, ignoreHardFiltering: true)
            .WithRecipes(x =>
            {
                x.AddRecipes(substitutionRecipes);
                x.AddRecipes(new Dictionary<int, int?>
                {
                    [recipeIngredient.RecipeId] = null,
                });
            })
            .Build()
            .Query(_serviceScopeFactory))
            .Select(r => r.AsType<NewsletterRecipeDto>()!);

        var recipeDto = recipeDtos.FirstOrDefault(r => r.Recipe.Id == recipeIngredient.RecipeId);
        if (recipeDto == null)
        {
            return Content("");
        }

        // Must be managed from a recipe context.
        if (userRecipeIngredient == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(nameof(ManageRecipeIngredient), new UserManageRecipeIngredientViewModel()
        {
            User = user,
            Token = token,
            Recipe = recipeDto,
            WasUpdated = wasUpdated,
            Recipes = substitutionRecipes,
            RecipeIngredient = recipeIngredient,
            UserNewsletter = new UserNewsletterDto(user.AsType<UserDto>()!, token),
            UserRecipeIngredient = new UserRecipeIngredientViewModel(userRecipeIngredient),
            AltRecipes = recipeDtos.ExceptBy([recipeDto.Recipe.Id], r => r.Recipe.Id).ToList(),
            Ingredients = recipeIngredient.Ingredient?.Alternatives.Select(ai => ai.AlternativeIngredient.AsType<IngredientDto>()!).ToList() ?? [],
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

        existingUserRecipeIngredient.Notes = viewModel.Notes;
        existingUserRecipeIngredient.SubstituteScale = viewModel.SubstituteScale;
        existingUserRecipeIngredient.SubstituteRecipeId = viewModel.SubstituteRecipeId;
        existingUserRecipeIngredient.SubstituteIngredientId = viewModel.SubstituteIngredientId;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipeIngredient), new { email, token, recipeIngredientId, wasUpdated = true });
    }

    /// <summary>
    /// Get recipes that the user is able to select as an ingredient alternative.
    /// </summary>
    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        return await _context.Recipes.AsNoTracking().TagWithCallSite()
            .Where(r => r.UserId == null || r.UserId == user.Id) // Has any flag:
            .Where(r => r.Instructions.All(i => (i.Equipment & user.Equipment) != 0 || i.Equipment == Equipment.None))
            .Where(r => r.BaseRecipe)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }
}
