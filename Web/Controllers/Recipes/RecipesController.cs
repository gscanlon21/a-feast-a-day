using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Web.Code.Attributes;
using Web.Views.Recipes;

namespace Web.Controllers.Recipes;

[Route($"{Name}")]
public class RecipesController : ViewController
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RecipesController(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Recipes";

    [Route("")]
    [ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(RecipesViewModel? viewModel = null)
    {
        viewModel ??= new RecipesViewModel();

        var queryBuilder = new QueryBuilder(viewModel.Section ?? Section.None);

        if (viewModel.Equipment.HasValue)
        {
            queryBuilder = queryBuilder.WithEquipment(viewModel.Equipment.Value);
        }

        viewModel.Recipes = (await queryBuilder.Build().Query(_serviceScopeFactory))
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
