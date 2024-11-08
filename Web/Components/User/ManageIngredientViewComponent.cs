using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Recipe;
using Data;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Views.Shared.Components.ManageIngredient;
using Web.Views.User;

namespace Web.Components.User;

public class ManageIngredientViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageIngredient";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public ManageIngredientViewComponent(CoreContext context, UserRepo userRepo)
    {
        _userRepo = userRepo;
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Ingredient ingredient, UserManageIngredientViewModel.Params parameters)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
        var userNewsletter = user.AsType<UserNewsletterDto, Data.Entities.User.User>()!;
        userNewsletter.Token = await _userRepo.AddUserToken(user, durationDays: 1);

        var userIngredient = await _context.UserIngredients.AsNoTracking()
            .FirstOrDefaultAsync(r => r.UserId == user.Id && r.IngredientId == parameters.IngredientId);

        if (userIngredient == null)
        {
            userIngredient = new UserIngredient()
            {
                UserId = user.Id,
                IngredientId = ingredient.Id,
            };
            _context.UserIngredients.Add(userIngredient);
            await _context.SaveChangesAsync();
        }

        return View("ManageIngredient", new ManageIngredientViewModel()
        {
            User = user,
            Parameters = parameters,
            UserNewsletter = userNewsletter,
            UserIngredient = userIngredient,
            Recipes = await GetRecipes(user),
            Ingredient = ingredient.AsType<IngredientDto, Ingredient>()!,
            Ingredients = ingredient.Alternatives.Select(ai => ai.AlternativeIngredient.AsType<IngredientDto, Ingredient>()!).ToList(),
        });
    }

    private async Task<IList<Recipe>> GetRecipes(Data.Entities.User.User user)
    {
        var allEquipment = user.Equipment.WithOptionalEquipment();
        return await _context.Recipes.AsNoTracking()
            .Where(r => r.UserId == null || r.UserId == user.Id)
            .Where(r => allEquipment.HasFlag(r.Equipment))
            // Some ingredients recipes can stand on their own, such as a simple salad that can be used in a sandwich.
            //.Where(r => r.Section == Section.None)
            .OrderBy(r => r.Name)
            .ToListAsync();
    }
}
