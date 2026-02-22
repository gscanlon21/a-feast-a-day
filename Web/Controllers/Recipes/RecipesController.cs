using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Web.Code.Attributes;
using Web.Views.Recipes;
using static System.Net.WebRequestMethods;

namespace Web.Controllers.Recipes;

[Route($"{Name}")]
public class RecipesController : ViewController
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Recipes";

    private readonly IServiceScopeFactory _serviceScopeFactory;

    private static readonly JsonSerializerOptions Options = new()
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        // Reduce the size of the serilized string for memory usage.
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public RecipesController(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    [Route(""), AcceptVerbs(Http.Get, Http.Post)]
    [ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(RecipesViewModel? viewModel = null)
    {
        viewModel ??= new RecipesViewModel();

        QueryBuilderBase queryBuilder = new QueryBuilder(viewModel.Section ?? Section.None).WithRecipes(x =>
        {
            x.IgnorePrepRecipes = true;
        });

        if (viewModel.Equipment.HasValue)
        {
            queryBuilder = queryBuilder.WithEquipment(viewModel.Equipment.Value);
        }

        if (viewModel.MinimumServings.HasValue)
        {
            queryBuilder = queryBuilder.WithServings(options =>
            {
                options.MinimumServings = viewModel.MinimumServings;
            });
        }

        if (!string.IsNullOrWhiteSpace(viewModel.Ingredient))
        {
            queryBuilder = queryBuilder.WithIngredients(options =>
            {
                options.IngredientName = viewModel.Ingredient;
            });
        }

        if (viewModel.PrepTime.HasValue || viewModel.CookTime.HasValue || viewModel.TotalTime.HasValue)
        {
            queryBuilder = queryBuilder.WithDuration(options =>
            {
                options.MaxPrepTimeMinutes = viewModel.PrepTime;
                options.MaxCookTimeMinutes = viewModel.CookTime;
                options.MaxTotalTimeMinutes = viewModel.TotalTime;
            });
        }

        var queryResults = await queryBuilder.Build().Query(_serviceScopeFactory, OrderBy.Name);
        viewModel.Recipes = FilterRecipes(queryResults, viewModel)
            .Select(r => r.AsType<NewsletterRecipeDto>(Options)!)
            .ToList();

        if (viewModel.Equipment.HasValue)
        {
            viewModel.Recipes = viewModel.Recipes.Where(vm => !string.IsNullOrWhiteSpace(vm.Recipe.Equipment)).ToList();
        }

        return View(viewModel);
    }

    /// <summary>
    /// Do this right after the query to reduce json class conversions.
    /// </summary>
    private IEnumerable<QueryResults> FilterRecipes(IEnumerable<QueryResults> queryResults, RecipesViewModel viewModel)
    {
        if (viewModel.Section == Section.Prep)
        {
            queryResults = queryResults.Where(vm => vm.Recipe.BaseRecipe);
        }

        if (!string.IsNullOrWhiteSpace(viewModel.Name))
        {
            queryResults = queryResults.Where(vm => vm.Recipe.Name.Contains(viewModel.Name, StringComparison.OrdinalIgnoreCase));
        }

        return queryResults;
    }
}
