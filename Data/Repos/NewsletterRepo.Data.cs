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
    internal async Task<IList<QueryResults>> GetBreakfastRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var breakfastServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Breakfast);
        var scale = breakfastServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Breakfast)
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
            .Query(serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetLunchRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var lunchServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Lunch);
        var scale = lunchServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Lunch)
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
            .Query(serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDinnerRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dinnerServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Dinner);
        var scale = dinnerServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Dinner)
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
            .Query(serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSideRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var sideServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Sides);
        var scale = sideServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Sides)
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
            .Query(serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSnackRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var snackServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Snacks);
        var scale = snackServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Snacks)
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
            .Query(serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDessertRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dessertServing = newsletterContext.User.UserServings.First(us => us.Section == Section.Dessert);
        var scale = dessertServing.Count / (double)newsletterContext.User.UserServings.Sum(us => us.Count);
        return await new QueryBuilder(Section.Dessert)
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
            .Query(serviceScopeFactory);
    }

    private async Task<IList<QueryResults>> GetDebugRecipes(UserDto user)
    {
        return await new QueryBuilder(Section.Debug)
            .WithUser(user)
            .Build()
            .Query(serviceScopeFactory, take: 1);
    }

    /// <summary>
    /// Grab x-many exercises that the user hasn't seen in a long time.
    /// </summary>
    private async Task<IList<Ingredient>> GetDebugIngredients()
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var debugIngredients = await context.Ingredients.AsNoTracking().Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .OrderByDescending(i => i.LastUpdated == DateHelpers.Today)
            .ThenBy(i => i.LastUpdated)
            .ThenBy(_ => EF.Functions.Random())
            .Take(2).ToListAsync();

        foreach (var debugIngredient in debugIngredients)
        {
            debugIngredient.LastUpdated = DateHelpers.Today;
            scopedCoreContext.Ingredients.Update(debugIngredient);
        }

        await scopedCoreContext.SaveChangesAsync();
        return debugIngredients;
    }
}
