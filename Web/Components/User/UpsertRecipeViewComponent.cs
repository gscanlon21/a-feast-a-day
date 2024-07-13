using Core.Models.Recipe;
using Core.Models.User;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.UpsertRecipe;

namespace Web.Components.User;

public class UpsertRecipeViewComponent(CoreContext context, UserRepo userRepo) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "UpsertRecipe";

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

        while (recipe.RecipeIngredients.Count < 16)
        {
            recipe.RecipeIngredients.Add(new RecipeIngredient
            {
                Hide = recipe.RecipeIngredients.Count > 0
            });
        }

        while (recipe.Instructions.Count < 16)
        {
            recipe.Instructions.Add(new RecipeInstruction
            {
                Hide = recipe.Instructions.Count > 0
            });
        }

        return View("UpsertRecipe", new UpsertRecipeViewModel()
        {
            User = user,
            Recipe = recipe.AsType<UpsertRecipeModel, Recipe>()!,
            Recipes = await GetRecipes(user),
            Ingredients = await GetIngredients(user),
            Token = await userRepo.AddUserToken(user, durationDays: 1),
        });
    }

    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        return await context.Recipes.AsNoTracking()
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => r.Equipment == Equipment.None || user.Equipment.HasFlag(r.Equipment))
            // Some ingredients recipes can stand on their own, such as a simple salad that can be used in a sandwich.
            //.Where(r => r.Section == Section.None)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }

    private async Task<IList<Ingredient>> GetIngredients(Data.Entities.User.User user)
    {
        return await context.Ingredients.AsNoTracking()
            .Where(i => i.UserId == null || i.UserId == user.Id)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }
}
