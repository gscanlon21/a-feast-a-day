using Core.Models.Ingredients;
using Core.Models.User;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.User;
using Data.Repos;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Controllers.User;
using Web.Views.Ingredient;

namespace Web.Controllers.Ingredients;

[Route($"i/{UserRoute}", Order = 1)]
[Route($"ingredient/{UserRoute}", Order = 2)]
public class IngredientController : ViewController
{
    private readonly NewsletterService _newsletterService;
    private readonly CoreContext _context;
    private readonly UserRepo _userRepo;

    public IngredientController(CoreContext context, UserRepo userRepo, NewsletterService newsletterService)
    {
        _context = context;
        _userRepo = userRepo;
        _newsletterService = newsletterService;
    }

    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "Ingredient";

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
    [HttpGet, Route("{recipeId}/{ingredientId}")]
    public async Task<IActionResult> ManageIngredient(string email, string token, int recipeId, int ingredientId, bool? wasUpdated = null)
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

        if (ingredient == null) { return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage)); }
        return View(nameof(ManageIngredient), new UserManageIngredientViewModel()
        {
            User = user,
            Token = token,
            Ingredient = ingredient,
            WasUpdated = wasUpdated,
            HasUserIngredient = true,
            Parameters = new UserManageIngredientViewModel.Params(email, token, recipeId, ingredientId)
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
            existingIngredient.Notes = ingredient.Notes;
            existingIngredient.Category = ingredient.Category;
            existingIngredient.Allergens = ingredient.Allergens;
            existingIngredient.GramsPerCup = ingredient.GramsPerCup;
            existingIngredient.DefaultMeasure = ingredient.DefaultMeasure;
            existingIngredient.GramsPerMeasure = ingredient.GramsPerMeasure;
            existingIngredient.GramsPerServing = ingredient.GramsPerServing;
            existingIngredient.SkipShoppingList = ingredient.SkipShoppingList;

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
            _context.Add(new Ingredient()
            {
                User = user,
                Name = name,
                Category = category,
                //Nutrients = nutrients,
                Allergens = allergens.Aggregate(Allergens.None, (curr, next) => curr | next),
            });
        } 

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your ingredient has been updated!";
        return RedirectToAction(nameof(ManageIngredient), new { email, token, ingredientId = ingredient.Id, recipeId = 0, wasUpdated = true });
    }
}
