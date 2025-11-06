using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.Users;

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
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var ingredients = await _context.Ingredients.Where(r => r.UserId == user.Id).ToListAsync();
        var recipes = await _context.Recipes.Include(r => r.Instructions).Include(r => r.RecipeIngredients)
            .Where(r => r.UserId == user.Id).ToListAsync();

        return Json(new { recipes, ingredients });
    }
}
