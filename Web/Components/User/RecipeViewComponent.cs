using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
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
        // Don't let the demo user add new recipes.
        if (user.IsDemoUser)
        {
            return Content("");
        }

        // User must own the recipe to be able to edit it.
        if (recipe != null && recipe.UserId != user.Id)
        {
            return Content("");
        }

        return View("Recipe", new RecipeViewModel()
        {
            User = user,
            Token = await userRepo.AddUserToken(user, durationDays: 1),
            Recipe = recipe ?? new UserRecipe()
            {
                User = user,
                Ingredients = Enumerable.Repeat(new UserRecipeIngredient()
                {
                    Hide = true
                }, 10).ToList(),
                Instructions = Enumerable.Repeat(new UserRecipeInstruction()
                {
                    Hide = true
                }, 10).ToList()
            }
        });
    }
}
