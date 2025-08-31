using Core.Models.Newsletter;
using Core.Models.User;
using Data;
using Data.Entities.Recipe;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Web.Code.Extensions;
using Web.Code.TempData;
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

    /// <param name="recipe">The existing recipe to edit.</param>
    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Recipe? recipe = null, Section section = Section.None)
    {
        // User must have created the recipe to be able to edit it.
        if (recipe != null && user.Id != recipe.UserId && !user.Features.HasFlag(Features.Admin))
        {
            return Content("");
        }

        // Restore the failed recipe if the upsert model validation failed.
        var upsertRecipe = TempData.ReadModel<UpsertRecipeModel>(TempData_Recipe.UpsertRecipe);
        if (upsertRecipe != null)
        {
            // Show error messages to the user.
            var validationErrors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(upsertRecipe, new ValidationContext(upsertRecipe), validationErrors, validateAllProperties: true))
            {
                foreach (var error in validationErrors)
                {
                    foreach (var member in error.MemberNames)
                    {
                        ModelState.AddModelError($"recipe.{member}", error.ErrorMessage ?? "Invalid value.");
                    }
                }
            }
        }

        upsertRecipe ??= recipe?.AsType<UpsertRecipeModel>() ?? new UpsertRecipeModel();
        while (upsertRecipe.RecipeIngredients.Count < RecipeConsts.MaxIngredients)
        {
            upsertRecipe.RecipeIngredients.Add(new RecipeIngredient
            {
                Hide = upsertRecipe.RecipeIngredients.Count > 0
            });
        }

        while (upsertRecipe.Instructions.Count < RecipeConsts.MaxInstructions)
        {
            upsertRecipe.Instructions.Add(new RecipeInstruction
            {
                Hide = upsertRecipe.Instructions.Count > 0
            });
        }

        return View("UpsertRecipe", new UpsertRecipeViewModel()
        {
            User = user,
            Section = section,
            Recipe = upsertRecipe,
            RecipeSelect = await GetRecipeSelect(user),
            IngredientSelect = await GetIngredientSelect(user),
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }

    private async Task<IList<SelectListItem>> GetRecipeSelect(Data.Entities.User.User user)
    {
        return (await _context.Recipes.AsNoTracking().TagWithCallSite() // Has any flag:
            .Where(r => r.UserId == null || r.Instructions.All(i => (i.Equipment & user.Equipment) != 0 || i.Equipment == Equipment.None))
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => r.BaseRecipe)
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
