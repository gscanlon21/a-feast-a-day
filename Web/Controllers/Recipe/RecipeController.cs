using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Web.Code.Attributes;
using Web.Views.Recipe;

namespace Web.Controllers.Recipe;

[Route("recipe", Order = 1)]
[Route("recipes", Order = 2)]
public class RecipeController(IServiceScopeFactory serviceScopeFactory) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Recipe";

    [Route("", Order = 2)]
    [Route("all", Order = 1)]
    [ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(RecipesViewModel? viewModel = null)
    {
        viewModel ??= new RecipesViewModel();

        var queryBuilder = new QueryBuilder(viewModel.Section ?? Section.None);

        if (viewModel.Equipment.HasValue)
        {
            queryBuilder = queryBuilder.WithEquipment(viewModel.Equipment.Value);
        }

        viewModel.Recipes = (await queryBuilder.Build().Query(serviceScopeFactory))
            .Select(r => r.AsType<NewsletterRecipeDto>()!)
            .ToList();

        if (viewModel.Equipment.HasValue)
        {
            viewModel.Recipes = viewModel.Recipes.Where(vm => vm.Recipe.Equipment != Equipment.None).ToList();
        }

        if (!string.IsNullOrWhiteSpace(viewModel.Name))
        {
            viewModel.Recipes = viewModel.Recipes.Where(vm =>
                vm.Recipe.Name.Contains(viewModel.Name, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return View(viewModel);
    }
}
