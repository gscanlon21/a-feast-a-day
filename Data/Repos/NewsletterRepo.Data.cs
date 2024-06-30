using Core.Code.Helpers;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Data.Entities.Ingredient;
using Data.Entities.User;
using Data.Models;
using Data.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    internal async Task<List<QueryResults>> GetBreakfastRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var breakfastServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Breakfast);
        var scale = breakfastServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Breakfast)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = breakfastServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = breakfastServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    internal async Task<List<QueryResults>> GetLunchRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var lunchServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Lunch);
        var scale = lunchServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Lunch)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = lunchServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = lunchServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    internal async Task<List<QueryResults>> GetDinnerRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dinnerServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Dinner);
        var scale = dinnerServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Dinner)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dinnerServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = dinnerServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    internal async Task<List<QueryResults>> GetSideRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var sideServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Sides);
        var scale = sideServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Sides)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = sideServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = sideServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    internal async Task<List<QueryResults>> GetSnackRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var snackServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Snacks);
        var scale = snackServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Snacks)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = snackServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = snackServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    internal async Task<List<QueryResults>> GetDessertRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dessertServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Dessert);
        var scale = dessertServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargets()
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dessertServing.AtLeastXNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = dessertServing.AtLeastXServingsPerRecipe;
            })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    private async Task<List<QueryResults>> GetDebugExercises(UserDto user)
    {
        var recipes = (await new QueryBuilder(Section.Debug)
            .WithUser(user)
            .Build()
            .Query(serviceScopeFactory, take: 1))
            .ToList();

        var prerequisiteRecipeIds = recipes.SelectMany(ar => ar.Recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).ToDictionary(ri => ri.IngredientRecipeId.GetValueOrDefault(), ri => ar.Scale));
        var prerequisiteRecipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(user)
            .WithRecipes(options =>
            {
                options.AddRecipes(prerequisiteRecipeIds);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        return [.. prerequisiteRecipes, .. recipes];
    }

    /// <summary>
    /// Grab x-many exercises that the user hasn't seen in a long time.
    /// </summary>
    private async Task<List<Ingredient>> GetDebugIngredients()
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var debugIngredients = await context.Ingredients.AsNoTracking()
            .Include(i => i.Alternatives)
                .ThenInclude(a => a.AlternativeIngredient)
            .OrderByDescending(i => i.LastUpdated == DateHelpers.Today)
            .ThenBy(i => i.LastUpdated)
            .ThenBy(_ => EF.Functions.Random())
            .Take(1).ToListAsync();

        foreach (var debugIngredient in debugIngredients)
        {
            debugIngredient.LastUpdated = DateHelpers.Today;
            scopedCoreContext.Ingredients.Update(debugIngredient);
        }

        await scopedCoreContext.SaveChangesAsync();
        return debugIngredients;
    }
}
