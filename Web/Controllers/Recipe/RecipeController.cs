﻿using Core.Consts;
using Core.Models.Newsletter;
using Data.Dtos.Newsletter;
using Data.Query.Builders;
using Microsoft.AspNetCore.Mvc;
using Web.Code;
using Web.Code.Attributes;
using Web.ViewModels.Recipe;

namespace Web.Controllers.Recipe;

[Route("recipe")]
public partial class RecipeController(IServiceScopeFactory serviceScopeFactory) : ViewController()
{
    /// <summary>
    /// The name of the controller for routing purposes
    /// </summary>
    public const string Name = "Recipe";

    [Route("all"), ResponseCompression(Enabled = !DebugConsts.IsDebug)]
    public async Task<IActionResult> All(RecipesViewModel? viewModel = null)
    {
        viewModel ??= new RecipesViewModel();

        var queryBuilder = new QueryBuilder(viewModel.Section ?? Section.None);

        viewModel.Recipes = (await queryBuilder.Build().Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r)
            .AsType<Lib.ViewModels.Newsletter.NewsletterRecipeViewModel, RecipeDto>()!)
            .ToList();

        if (!string.IsNullOrWhiteSpace(viewModel.Name))
        {
            viewModel.Recipes = viewModel.Recipes.Where(e =>
                e.Recipe.Name.Contains(viewModel.Name, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return View(viewModel);
    }
}