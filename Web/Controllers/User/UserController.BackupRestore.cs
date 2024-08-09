using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    /// <summary>
    /// User backup of recipe data.
    /// </summary>
    [HttpPost]
    [Route("b", Order = 1)]
    [Route("backup", Order = 2)]
    public async Task<IActionResult> Backup(string email, string token)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var ingredients = await context.Ingredients.Where(r => r.UserId == user.Id).ToListAsync();
        var recipes = await context.Recipes.Where(r => r.UserId == user.Id).ToListAsync();
        return Json(new { recipes, ingredients });
    }
}
