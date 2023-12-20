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

        recipe.User = user;
        recipe.Ingredients = recipe.Ingredients.Where(i => !i.Hide).ToList();
        recipe.Instructions = recipe.Instructions.Where(i => !i.Hide).ToList();
        context.Add(recipe);

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your footnotes have been updated!";
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

        TempData[TempData_User.SuccessMessage] = "Your footnotes have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }
}
