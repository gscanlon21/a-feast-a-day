using Core.Models.User;
using Data;
using Data.Entities.Ingredients;
using Data.Entities.Users;
using Data.Repos;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Controllers.Users;
using Web.Views.Shared.Components.ManageIngredient;
using Web.Views.UserIngredients;

namespace Web.Controllers.Ingredients;

[Route($"i/{UserRoute}", Order = 1)]
[Route($"ingredient/{UserRoute}", Order = 2)]
public class UserIngredientsController : ViewController
{
    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "UserIngredients";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly NewsletterService _newsletterService;

    public UserIngredientsController(CoreContext context, UserRepo userRepo, NewsletterService newsletterService)
    {
        _context = context;
        _userRepo = userRepo;
        _newsletterService = newsletterService;
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> RemoveIngredient(string email, string token, [FromForm] int ingredientId)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await _context.Ingredients
            // The user has control of this ingredient and is not a built-in ingredient.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == ingredientId)
            .ExecuteDeleteAsync();

        await _context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.Edit), UserController.Name, new { email, token });
    }

    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet, Route("{ingredientId}")]
    public async Task<IActionResult> ManageIngredient(string email, string token, int ingredientId, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var ingredient = await _context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            // The ingredient alternatives, include their nutrients so we can show those on the page.
            .Include(i => i.Alternatives).ThenInclude(ai => ai.AlternativeIngredient).ThenInclude(ai => ai.Nutrients)
            // For which ingredients is this ingredient is an alternative of. No nutrients.
            .Include(i => i.AlternativeIngredients).ThenInclude(ai => ai.Ingredient)
            .FirstOrDefaultAsync(r => r.Id == ingredientId);

        if (ingredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View(nameof(ManageIngredient), new UserManageIngredientViewModel()
        {
            User = user,
            Ingredient = ingredient,
            WasUpdated = wasUpdated,
            Parameters = new UserManageIngredientViewModel.Params(email, token, ingredientId)
        });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> UpsertIngredient(string email, string token, Ingredient ingredient, List<Nutrient> nutrients)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingIngredient = await _context.Ingredients.Include(i => i.Nutrients).FirstOrDefaultAsync(r => r.Id == ingredient.Id);
        if (existingIngredient != null)
        {
            existingIngredient.Name = ingredient.Name;
            existingIngredient.Link = ingredient.Link;
            existingIngredient.Notes = ingredient.Notes;
            existingIngredient.Group = ingredient.Group;
            existingIngredient.Category = ingredient.Category;
            existingIngredient.Allergens = ingredient.Allergens;
            existingIngredient.DefaultMeasure = ingredient.DefaultMeasure;
            existingIngredient.GramsPerFineCup = ingredient.GramsPerFineCup;
            existingIngredient.GramsPerMeasure = ingredient.GramsPerMeasure;
            existingIngredient.GramsPerServing = ingredient.GramsPerServing;
            existingIngredient.SkipShoppingList = ingredient.SkipShoppingList;
            existingIngredient.GramsPerCoarseCup = ingredient.GramsPerCoarseCup;

            foreach (var nutrient in nutrients.OrderBy(n => n.Nutrients.PopCount()))
            {
                // Sum all the parts of a nutrient if it was left empty.
                // FIXME: Not all of the precursors get converted into a nutrient. Need a conversion percentage.
                //if (nutrient.Value == 0 && BitOperations.PopCount((ulong)nutrient.Nutrients) > 1)
                //{
                //    nutrient.Measure = Measure.Grams;
                //    nutrient.Value = nutrients
                //        .Where(n => BitOperations.PopCount((ulong)n.Nutrients) == 1)
                //        .Where(n => nutrient.Nutrients.HasFlag(n.Nutrients))
                //        .Sum(n => n.Measure.ToGrams(n.Value));
                //}

                var existingNutrient = existingIngredient.Nutrients.FirstOrDefault(n => n.Nutrients == nutrient.Nutrients);
                if (existingNutrient != null)
                {
                    existingNutrient.Measure = nutrient.Measure;
                    existingNutrient.Value = nutrient.Value;
                    if (nutrient.Value == 0)
                    {
                        _context.Nutrients.Remove(existingNutrient);
                    }
                }
                else if (nutrient.Value > 0)
                {
                    existingIngredient.Nutrients.Add(new Nutrient()
                    {
                        Nutrients = nutrient.Nutrients,
                        Measure = nutrient.Measure,
                        Value = nutrient.Value,
                    });
                }
            }
        }
        else
        {
            existingIngredient = new Ingredient()
            {
                UserId = user.Id,
                Name = ingredient.Name,
                Link = ingredient.Link,
                Notes = ingredient.Notes,
                Group = ingredient.Group,
                Category = ingredient.Category,
                Allergens = ingredient.Allergens,
                DefaultMeasure = ingredient.DefaultMeasure,
                GramsPerFineCup = ingredient.GramsPerFineCup,
                GramsPerMeasure = ingredient.GramsPerMeasure,
                GramsPerServing = ingredient.GramsPerServing,
                SkipShoppingList = ingredient.SkipShoppingList,
                GramsPerCoarseCup = ingredient.GramsPerCoarseCup,
            };

            _context.Ingredients.Add(existingIngredient);
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your ingredient has been updated!";
        return RedirectToAction(nameof(ManageIngredient), new { email, token, ingredientId = existingIngredient.Id, recipeId = 0, wasUpdated = true });
    }

    [HttpPost, Route("{ingredientId}/[action]")]
    public async Task<IActionResult> LogIngredient(string email, string token, int ingredientId, ManageIngredientViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(ManageIngredient), new { email, token, ingredientId, WasUpdated = false });
        }

        var user = await _userRepo.GetUser(email, token, allowDemoUser: false);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userIngredient = await _context.UserIngredients
            .Where(ur => ur.IngredientId == ingredientId)
            .Where(ur => ur.UserId == user.Id)
            .Include(ur => ur.Ingredient)
            .FirstAsync();

        userIngredient.Notes = user.IsDemoUser ? null : viewModel.Notes;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(ManageIngredient), new { email, token, ingredientId, WasUpdated = true });
    }
}
