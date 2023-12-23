using Core.Models.Newsletter;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.ViewModels.User;

namespace Web.Controllers.User;

public partial class UserController
{

    [HttpPost]
    [Route("recipe/add")]
    public async Task<IActionResult> AddRecipe(string email, string token, UserRecipe recipe)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        if (recipe.Id == default)
        {
            recipe.User = user;
            recipe.Ingredients = recipe.Ingredients.Where(i => !i.Hide).ToList();
            recipe.Instructions = recipe.Instructions.Where(i => !i.Hide).ToList();
            context.Add(recipe);
        }
        else
        {
            var existingRecipe = await context.UserRecipes
                .Include(r => r.Instructions)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == recipe.Id);
            if (existingRecipe == null)
            {
                return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
            }

            existingRecipe.Ingredients = recipe.Ingredients.Where(i => !i.Hide).ToList();
            existingRecipe.Instructions = recipe.Instructions.Where(i => !i.Hide).ToList();
            existingRecipe.Name = recipe.Name;
            existingRecipe.Notes = recipe.Notes;
            existingRecipe.Type = recipe.Type;
        }

        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("recipe/remove")]
    public async Task<IActionResult> RemoveRecipe(string email, string token, [FromForm] int recipeId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.UserRecipes
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == recipeId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }


    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("{section:section}/{recipeId}", Order = 1)]
    public async Task<IActionResult> ManageRecipe(string email, string token, int recipeId, Section section, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var parameters = new UserManageRecipeViewModel.Parameters(section, email, token, recipeId);
        var recipe = await context.UserRecipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)
            .FirstOrDefaultAsync(r => r.Id == recipeId);

        if (recipe == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View(new UserManageRecipeViewModel()
        {
            User = user,
            WasUpdated = wasUpdated,
            Recipe = recipe,
        });
    }

    [HttpPost]
    [Route("{section:section}/{recipeId}/ie", Order = 1)]
    [Route("{section:section}/{recipeId}/ignore-exercise", Order = 2)]
    public async Task<IActionResult> IgnoreExercise(string email, string token, int recipeId, Section section)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }

    [HttpPost]
    [Route("{section:section}/{recipeId}/re", Order = 1)]
    [Route("{section:section}/{recipeId}/refresh-exercise", Order = 2)]
    public async Task<IActionResult> RefreshExercise(string email, string token, int recipeId, Section section)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageRecipe), new { email, token, recipeId, section, WasUpdated = true });
    }
}
