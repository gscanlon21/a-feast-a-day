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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Breakfast).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Breakfast)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXUniqueNutrientsPerRecipe = newsletterContext.User.AtLeastXUniqueNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Breakfast)?.Count
                    ?? UserServing.DefaultServings[Section.Breakfast];
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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Lunch).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Lunch)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXUniqueNutrientsPerRecipe = newsletterContext.User.AtLeastXUniqueNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Lunch)?.Count
                    ?? UserServing.DefaultServings[Section.Lunch];
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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Dinner).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Dinner)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXUniqueNutrientsPerRecipe = newsletterContext.User.AtLeastXUniqueNutrientsPerRecipe;
                })
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Dinner)?.Count
                    ?? UserServing.DefaultServings[Section.Dinner];
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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Sides).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Sides)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale))
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Sides)?.Count
                    ?? UserServing.DefaultServings[Section.Sides];
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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Snacks).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Snacks)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale))
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Snacks)?.Count
                    ?? UserServing.DefaultServings[Section.Snacks];
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
        var scale = newsletterContext.User.UserServings.First(us => us.Section == Section.Dessert).Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        var recipes = (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithNutrients(NutrientTargetsBuilder
                .WithNutrients(newsletterContext, UserNutrient.NutrientTargets.Select(mt => mt.Key).ToList())
                .WithNutrientTargetsFromNutrients(null)
                .AdjustNutrientTargets(scale: scale))
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = newsletterContext.User.AtLeastXServingsPerRecipe;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Dessert)?.Count
                    ?? UserServing.DefaultServings[Section.Dessert];
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

        var debugIngredients = await context.Ingredients
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
