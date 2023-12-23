using Data;
using Data.Entities.User;
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

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, UserRecipe? recipe = null)
    {
        // User must own the recipe to be able to edit it.
        if (recipe != null && recipe.UserId != user.Id)
        {
            return Content("");
        }

        return View("Recipe", new RecipeViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            Ingredients = await context.UserIngredients.Where(i => i.UserId == null || i.UserId == user.Id).OrderBy(i => i.Name).ToListAsync(),
            Recipe = recipe ?? new UserRecipe()
            {
                User = user,
                Ingredients = GetIngredients().ToList(),
                Instructions = GetInstructions().ToList()
            }
        });
    }

    private static IEnumerable<UserRecipeIngredient> GetIngredients()
    {
        for (var i = 0; i < 16; i++)
        {
            yield return new UserRecipeIngredient()
            {
                Hide = i > 0
            };
        }
    }

    private static IEnumerable<UserRecipeInstruction> GetInstructions()
    {
        for (var i = 0; i < 16; i++)
        {
            yield return new UserRecipeInstruction()
            {
                Hide = i > 0
            };
        }
    }
}
