using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Users;
using Data.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    internal async Task<IList<QueryResults>> GetBreakfastRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var breakfastServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Breakfast) ?? new UserSection(Section.Breakfast);
        if (breakfastServing.Weight == 0) return [];

        var scale = breakfastServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Breakfast)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = breakfastServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetLunchRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var lunchServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Lunch) ?? new UserSection(Section.Lunch);
        if (lunchServing.Weight == 0) return [];

        var scale = lunchServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Lunch)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = lunchServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDinnerRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dinnerServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Dinner) ?? new UserSection(Section.Dinner);
        if (dinnerServing.Weight == 0) return [];

        var scale = dinnerServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Dinner)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dinnerServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSideRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var sideServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Sides) ?? new UserSection(Section.Sides);
        if (sideServing.Weight == 0) return [];

        var scale = sideServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Sides)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = sideServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSnackRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var snackServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Snacks) ?? new UserSection(Section.Snacks);
        if (snackServing.Weight == 0) return [];

        var scale = snackServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Snacks)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = snackServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDrinkRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var drinkServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Drinks) ?? new UserSection(Section.Drinks);
        if (drinkServing.Weight == 0) return [];

        var scale = drinkServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Drinks)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = drinkServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDessertRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dessertServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Dessert) ?? new UserSection(Section.Dessert);
        if (dessertServing.Weight == 0) return [];

        var scale = dessertServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dessertServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    private async Task<IList<QueryResults>> GetDebugRecipes(User user)
    {
        var debugRecipes = await new QueryBuilder(Section.Debug)
            .WithUser(user)
            .WithEquipment(Equipment.All)
            .WithRecipes(options =>
            {
                options.IgnorePrerequisites = true;
            })
            .Build()
            .Query(_serviceScopeFactory);

        foreach (var debugRecipe in debugRecipes)
        {
            // If a recipe has a recipe ingredient that uses a different measure type than the prep recipe.
            if (debugRecipe.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe)
                .Any(ri => ri.Measure != Measure.None && ri.IngredientRecipe?.Recipe.Measure == Measure.None))
            {
                UserLogs.Log(user, $"Recipe:{debugRecipe.Recipe.Id} \"{debugRecipe.Recipe.Name}\" has an invalid configuration: 1.");
            }

            // If a recipe has a recipe ingredient that uses a different measure type than the prep recipe.
            if (debugRecipe.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe)
                .Any(ri => ri.Measure == Measure.None && ri.IngredientRecipe?.Recipe.Measure != Measure.None))
            {
                UserLogs.Log(user, $"Recipe:{debugRecipe.Recipe.Id} \"{debugRecipe.Recipe.Name}\" has an invalid configuration: 2.");
            }
        }

        return debugRecipes.Take(1).ToList();
    }

    /// <summary>
    /// Grab x-many ingredients that the user hasn't seen in a long time.
    /// </summary>
    private async IAsyncEnumerable<IngredientDto> GetDebugIngredients(User user)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        // Do a quick check that there are no invalid alternative ingredients (is an altternative of itself).
        var invalidAlternatives = await _context.IngredientAlternatives.Where(ia => ia.IngredientId == ia.AlternativeIngredientId).ToListAsync();
        foreach (var invalidAlternative in invalidAlternatives)
        {
            UserLogs.Log(user, $"AlternativeIngredient:{invalidAlternative.IngredientId}:{invalidAlternative.AlternativeIngredientId} has an invalid configuration: 0.");
        }

        // OrderBy must come after the query or you get cartesian explosion.
        var debugIngredients = await scopedCoreContext.Ingredients.Include(i => i.Nutrients)
            .Include(i => i.Alternatives).ThenInclude(a => a.AlternativeIngredient)
            .Include(i => i.AlternativeIngredients).ThenInclude(a => a.Ingredient)
            .ToArrayAsync();

        foreach (var debugIngredient in debugIngredients)
        {
            // If an ingredient has no nutrients and the ingredient isn't a composite ingredient.
            if (!debugIngredient.Nutrients.Any(n => n.Value > 0) && !debugIngredient.Name.Contains('|'))
            {
                UserLogs.Log(user, $"Ingredient:{debugIngredient.Id} \"{debugIngredient.Name}\" has an invalid configuration: 1.");
            }
        }

        Random.Shared.Shuffle(debugIngredients);
        foreach (var debugIngredient in debugIngredients
            .OrderByDescending(i => i.LastUpdated == DateHelpers.Today)
            .ThenBy(i => i.LastUpdated)
            .Take(2))
        {
            debugIngredient.LastUpdated = DateHelpers.Today;

            // .AsType Mapper returns a cycle error
            // even with ReferenceHandler.Preserve.
            yield return new IngredientDto()
            {
                Id = debugIngredient.Id,
                Name = debugIngredient.Name,
                Notes = debugIngredient.Notes,
                Category = debugIngredient.Category,
                Allergens = debugIngredient.Allergens,
                GramsPerCup = debugIngredient.GramsPerCup,
                DefaultMeasure = debugIngredient.DefaultMeasure,
                GramsPerMeasure = debugIngredient.GramsPerMeasure,
                GramsPerServing = debugIngredient.GramsPerServing,
                SkipShoppingList = debugIngredient.SkipShoppingList,
                Nutrients = debugIngredient.Nutrients.Select(n => new NutrientDto()
                {
                    Id = n.Id,
                    Value = n.Value,
                    Notes = n.Notes,
                    Measure = n.Measure,
                    Nutrients = n.Nutrients,
                    IngredientId = n.IngredientId,
                }).ToList(),
                Alternatives = debugIngredient.Alternatives.Select(a => new IngredientAlternativeDto()
                {
                    Scale = a.Scale,
                    IngredientId = a.IngredientId,
                    AlternativeIngredientId = a.AlternativeIngredientId,
                    AlternativeIngredient = new IngredientDto(a.AlternativeIngredient.Name),
                    Ingredient = new IngredientDto(a.Ingredient.Name),
                }).ToList(),
                AlternativeIngredients = debugIngredient.AlternativeIngredients.Select(ai => new IngredientAlternativeDto()
                {
                    Scale = ai.Scale,
                    IngredientId = ai.IngredientId,
                    AlternativeIngredientId = ai.AlternativeIngredientId,
                    AlternativeIngredient = new IngredientDto(ai.AlternativeIngredient.Name),
                    Ingredient = new IngredientDto(ai.Ingredient.Name),
                }).ToList(),
            };
        }

        await scopedCoreContext.SaveChangesAsync();
    }
}
