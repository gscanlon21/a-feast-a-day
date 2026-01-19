using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.ManageIngredient;
using Web.Views.UserIngredients;

namespace Web.Components.User;

public class ManageIngredientViewComponent : ViewComponent
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public ManageIngredientViewComponent(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageIngredient";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.Users.User user, Ingredient ingredient, UserManageIngredientViewModel.Params parameters)
    {
        var userIngredient = await _context.UserIngredients.AsNoTracking()
            .Where(r => r.IngredientId == parameters.IngredientId)
            .Where(r => r.UserId == user.Id)
            .FirstOrDefaultAsync();

        if (userIngredient == null)
        {
            userIngredient = new Data.Entities.Users.UserIngredient()
            {
                IngredientId = ingredient.Id,
                UserId = user.Id,
            };

            _context.UserIngredients.Add(userIngredient);
            await _context.SaveChangesAsync();
        }

        var userFeast = await _userRepo.GetCurrentFeast(user);
        if (userFeast == null)
        {
            return Content("");
        }

        return View("ManageIngredient", new ManageIngredientViewModel()
        {
            User = user,
            Ingredient = ingredient,
            Parameters = parameters,
            Notes = userIngredient.Notes,
            UserIngredient = userIngredient,
        });
    }
}
