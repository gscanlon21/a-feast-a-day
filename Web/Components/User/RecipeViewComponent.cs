using Core.Models.User;
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

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe? recipe = null)
    {
        // User must own the recipe to be able to edit it.
        if (recipe != null && recipe.UserId != user.Id && !user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        recipe ??= new Recipe()
        {
            User = user
        };

        while (recipe.Ingredients.Count < 16)
        {
            recipe.Ingredients.Add(new RecipeIngredient
            {
                Hide = recipe.Ingredients.Count > 0
            });
        }

        while (recipe.Instructions.Count < 16)
        {
            recipe.Instructions.Add(new RecipeInstruction
            {
                Hide = recipe.Instructions.Count > 0
            });
        }

        return View("Recipe", new RecipeViewModel()
        {
            User = user,
            Recipe = recipe,
            Ingredients = await GetIngredients(user),
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }

    private async Task<IList<Ingredient>> GetIngredients(Data.Entities.User.User user)
    {
        return await context.Ingredients.AsNoTracking()
            // Only grab root ingredients.
            .Where(i => i.ParentId == null)
            .Where(i => i.UserId == null || i.UserId == user.Id)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }
}
