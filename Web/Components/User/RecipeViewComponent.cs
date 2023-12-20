using Core.Models.Footnote;
using Data;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User.Components;

namespace Web.Components.User;

public class RecipeViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Recipe";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Custom footnotes must be enabled in the user edit form to show in the newsletter.
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return Content("");
        }

        var userRecipes = await context.UserRecipes
            .Where(f => f.UserId == user.Id)
            .OrderBy(f => f.Name)
            .ToListAsync();

        return View("Recipe", new RecipeViewModel()
        {
            User = user,
            Recipes = userRecipes,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            Recipe = new Data.Entities.User.UserRecipe()
            {
                User = user,
                Ingredients = Enumerable.Repeat(new Data.Entities.User.UserRecipeIngredient()
                {
                    Hide = true
                }, 10).ToList(),
                Instructions = Enumerable.Repeat(new Data.Entities.User.UserRecipeInstruction()
                {
                    Hide = true
                }, 10).ToList()
            }
        });
    }
}
