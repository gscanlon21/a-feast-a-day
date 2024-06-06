using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost]
    [Route("ingredient/add")]
    public async Task<IActionResult> AddIngredient(string email, string token, [FromForm] string name, [FromForm] Nutrients nutrients, [FromForm] IList<Allergy> allergens)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        context.Add(new Data.Entities.User.Ingredient()
        {
            User = user,
            Name = name,
            //Nutrients = nutrients,
            Allergens = allergens.Aggregate(Allergy.None, (curr, next) => curr | next),
        });

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("ingredient/remove")]
    public async Task<IActionResult> RemoveIngredient(string email, string token, [FromForm] int ingredientId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserIngredients
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == ingredientId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("ingredient/{ingredientId}")]
    public async Task<IActionResult> Manage(string email, string token, int ingredientId, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var ingredient = await context.UserIngredients.Include(i => i.Nutrients).FirstOrDefaultAsync(r => r.Id == ingredientId);
        if (ingredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var nutrients = new List<Nutrient>();
        foreach (var nutrient in EnumExtensions.GetValuesExcluding32(Nutrients.None, Nutrients.All)
            .OrderBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(n => n.GetSingleDisplayName(EnumExtensions.DisplayNameType.Name)))
        {
            var userNutrient = ingredient.Nutrients.FirstOrDefault(n => n.Nutrients == nutrient);
            if (userNutrient != null)
            {
                nutrients.Add(userNutrient);
            }
            else
            {
                nutrients.Add(new Nutrient()
                {
                    Nutrients = nutrient,
                    Ingredient = ingredient,
                });
            }
        }

        return View(new ManageIngredientViewModel()
        {
            User = user,
            Token = token,
            Ingredient = ingredient,
            WasUpdated = wasUpdated,
            Nutrients = nutrients
        });
    }

    [HttpPost]
    [Route("ingredient/{ingredientId}")]
    public async Task<IActionResult> ManagePost(string email, string token, Data.Entities.User.Ingredient ingredient, List<Data.Entities.User.Nutrient> nutrients)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingRecipe = await context.UserIngredients.Include(i => i.Nutrients).FirstOrDefaultAsync(r => r.Id == ingredient.Id);
        if (existingRecipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        existingRecipe.Name = ingredient.Name;
        existingRecipe.Notes = ingredient.Notes;
        existingRecipe.Allergens = ingredient.Allergens;
        existingRecipe.GramsPerCup = ingredient.GramsPerCup;
        existingRecipe.ServingSizeGrams = ingredient.ServingSizeGrams;
        existingRecipe.SkipShoppingList = ingredient.SkipShoppingList;
        existingRecipe.CaloriesPerServing = ingredient.CaloriesPerServing;

        foreach (var nutrient in nutrients)
        {
            var existingNutrient = existingRecipe.Nutrients.FirstOrDefault(n => n.Nutrients == nutrient.Nutrients);
            if (existingNutrient != null)
            {
                existingNutrient.Value = nutrient.Value;
                existingNutrient.Measure = nutrient.Measure;
            }
            else
            {
                existingRecipe.Nutrients.Add(new Nutrient()
                {
                    Nutrients = nutrient.Nutrients,
                    Measure = nutrient.Measure,
                    Value = nutrient.Value
                });
            }
        }

        await context.SaveChangesAsync();
        //TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.Manage), new { email, token, ingredientId = ingredient.Id });
    }
}
