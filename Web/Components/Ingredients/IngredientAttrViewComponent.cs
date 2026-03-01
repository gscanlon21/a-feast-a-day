using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.UpsertIngredient;

namespace Web.Components.Ingredients;


public class IngredientAttrViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public IngredientAttrViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "IngredientAttr";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, Ingredient? ingredient = null)
    {
        if (ingredient == null)
        {
            return Content("");
        }

        var ingredientAttr = await _context.IngredientAttrs
            .Where(ia => ia.IngredientId == ingredient.Id)
            .FirstOrDefaultAsync();

        return View("IngredientAttr", new IngredientAttrViewModel()
        {
            User = user,
            Ingredient = ingredient,
            IngredientAttr = ingredientAttr ?? new IngredientAttr()
            {
                IngredientId = ingredient.Id,
            },
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
