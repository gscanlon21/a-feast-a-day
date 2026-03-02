using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Core.Models;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Entities.External;
using Data.Entities.Users;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    private async Task<IList<QueryResults>> GetDebugRecipes(User user)
    {
        var debugRecipes = await new UserQueryBuilder(user, Section.Debug)
            .WithEquipment(Equipment.All)
            .WithRecipes(options =>
            {
                options.IgnorePrepRecipes = true;
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

        // OrderBy must come after the query or you get cartesian explosion. Allow disabled ingredients.
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
                Link = debugIngredient.Link,
                Notes = debugIngredient.Notes,
                Category = debugIngredient.Category,
                Allergens = debugIngredient.Allergens,
                DefaultMeasure = debugIngredient.DefaultMeasure,
                GramsPerFineCup = debugIngredient.GramsPerFineCup,
                GramsPerMeasure = debugIngredient.GramsPerMeasure,
                GramsPerServing = debugIngredient.GramsPerServing,
                SkipShoppingList = debugIngredient.SkipShoppingList,
                GramsPerCoarseCup = debugIngredient.GramsPerCoarseCup,
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

    private async Task<IList<DietaryIntake>> GetDebugDietaryIntakes(User user)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        // Allow tracking to update last updated date.
        var debugDietaryIntakes = await scopedCoreContext.DietaryIntakes
            .OrderByDescending(i => i.Updated == DateHelpers.Today)
            .ThenBy(di => di.Updated).GroupBy(di => di.Key)
            .Select(g => g.ToList())
            .FirstAsync();

        foreach (var debugDietaryIntake in debugDietaryIntakes)
        {
            debugDietaryIntake.Updated = DateHelpers.Today;
        }

        await scopedCoreContext.SaveChangesAsync();
        return debugDietaryIntakes;
    }
}
