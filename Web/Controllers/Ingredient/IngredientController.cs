using Core.Consts;
using Core.Models.Newsletter;
using Data;
using Data.Entities.User;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.Code.Attributes;
using Web.ViewModels.Ingredient;

namespace Web.Controllers.Ingredient;

[Route("ingredient")]
public partial class IngredientController(CoreContext context) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Ingredient";

    [Route("all"), ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(IngredientsViewModel? viewModel = null)
    {
        viewModel ??= new IngredientsViewModel();

        var queryBuilder = new QueryBuilder(viewModel.Section ?? Section.None);

        viewModel.Ingredients = (await context.UserIngredients.ToListAsync())
            .Select(r => r.AsType<Lib.ViewModels.Newsletter.IngredientViewModel, Data.Entities.User.Ingredient>()!)
            .ToList();

        if (!string.IsNullOrWhiteSpace(viewModel.Name))
        {
            viewModel.Ingredients = viewModel.Ingredients.Where(e =>
                e.Name.Contains(viewModel.Name, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return View(viewModel);
    }
}
