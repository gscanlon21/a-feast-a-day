using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Entities.Recipe;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.UpsertRecipe;

namespace Web.Components.User;

public class UpsertRecipeViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public UpsertRecipeViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "UpsertRecipe";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe? recipe = null, Section section = Section.None)
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

        while (recipe.RecipeIngredients.Count < RecipeConsts.MaxIngredients)
        {
            recipe.RecipeIngredients.Add(new RecipeIngredient
            {
                Hide = recipe.RecipeIngredients.Count > 0
            });
        }

        while (recipe.Instructions.Count < RecipeConsts.MaxInstructions)
        {
            recipe.Instructions.Add(new RecipeInstruction
            {
                Hide = recipe.Instructions.Count > 0
            });
        }

        return View("UpsertRecipe", new UpsertRecipeViewModel()
        {
            User = user,
            Section = section,
            Recipe = recipe.AsType<UpsertRecipeModel>()!,
            RecipeSelect = await GetRecipeSelect(user),
            IngredientSelect = await GetIngredientSelect(user),
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }

    private async Task<IList<SelectListItem>> GetRecipeSelect(Data.Entities.User.User user)
    {
        var allEquipment = user.Equipment.WithOptionalEquipment();
        return (await _context.Recipes.AsNoTracking().TagWithCallSite()
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => allEquipment.HasFlag(r.Equipment))
            // Some ingredients recipes can stand on their own, such as a simple salad that can be used in a sandwich.
            //.Where(r => singleOrNoneSections.Contains(r.Section)) // This doesn't work for Hard Boiled Eggs.
            .OrderBy(r => r.Name)
            .ToListAsync())
            .Select(i => new SelectListItem() { Text = i.Name, Value = i.Id.ToString() })
            .Prepend(new SelectListItem())
            .ToList();
    }

    private async Task<IList<SelectListItem>> GetIngredientSelect(Data.Entities.User.User user)
    {
        return (await _context.Ingredients.AsNoTracking().TagWithCallSite()
            .Where(i => i.UserId == null || i.UserId == user.Id)
            .OrderBy(i => i.Name)
            .ToListAsync())
            .Select(i => new SelectListItem() { Text = i.Name, Value = i.Id.ToString() })
            .Prepend(new SelectListItem())
            .ToList();
    }
}
