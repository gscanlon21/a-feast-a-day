using Core.Code.Extensions;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.User;
using Data.Models;
using Data.Query.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;

namespace Data.Query;

/// <summary>
/// Builds and runs an EF Core query for selecting exercises.
/// </summary>
public class QueryRunner(Section section)
{
    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    private class RecipesQueryResults
        : IRecipeCombo
    {
        public Recipe Recipe { get; init; } = null!;
        public UserRecipe UserRecipe { get; init; } = null!;
    }

    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    private class InProgressQueryResults(RecipesQueryResults queryResult) :
        IRecipeCombo
    {
        public int Scale { get; set; } = 1;
        public Recipe Recipe { get; } = queryResult.Recipe;
        public UserRecipe? UserRecipe { get; set; } = queryResult.UserRecipe;

        public override int GetHashCode() => HashCode.Combine(Recipe.Id);

        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Recipe.Id == Recipe.Id;
    }

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public required UserOptions UserOptions { get; init; }
    public required ServingsOptions ServingsOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required RecipeOptions RecipeOptions { get; init; }
    public required NutrientOptions NutrientOptions { get; init; }
    public required AllergenOptions AllergenOptions { get; init; }

    private IQueryable<RecipesQueryResults> CreateRecipesQuery(CoreContext context)
    {
        var query = context.UserRecipes.IgnoreQueryFilters().TagWith(nameof(CreateRecipesQuery))
            .Include(r => r.Instructions)
            .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                    .ThenInclude(i => i.Nutrients)
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            .Where(r => r.User.MaxIngredients == null || r.User.MaxIngredients >= r.Ingredients.Count(i => !i.Ingredient.SkipShoppingList))
            .Where(ev => ev.DisabledReason == null);


        return query.Select(i => new RecipesQueryResults()
        {
            Recipe = i,
            UserRecipe = i.UserUserRecipes.First(ue => ue.UserId == UserOptions.Id)
        });
    }

    private IQueryable<RecipesQueryResults> CreateFilteredRecipesQuery(CoreContext context, bool ignoreExclusions = false)
    {
        var filteredQuery = CreateRecipesQuery(context)
            .TagWith(nameof(CreateFilteredRecipesQuery))
            // Don't grab exercises that the user wants to ignore
            .Where(vm => UserOptions.IgnoreIgnored || vm.UserRecipe.Ignore != true);

        if (!ignoreExclusions)
        {
            filteredQuery = filteredQuery
                // Don't grab exercises that we want to ignore
                .Where(vm => !ExclusionOptions.RecipeIds.Contains(vm.Recipe.Id))
                // Don't grab variations that we want to ignore. Has any flag.
                .Where(vm => (ExclusionOptions.Allergens & vm.Recipe.Allergens) == 0);
        }

        return filteredQuery;
    }

    /// <summary>
    /// Queries the db for the data
    /// </summary>
    public async Task<IList<QueryResults>> Query(IServiceScopeFactory factory, int take = int.MaxValue)
    {
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var filteredQuery = CreateFilteredRecipesQuery(context);

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds);
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients.Aggregate(Nutrients.None, (curr2, n2) => curr2 | n2), include: true);

        var queryResults = await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync();

        var filteredResults = new List<InProgressQueryResults>();
        if (UserOptions.NoUser)
        {
            filteredResults = queryResults;
        }
        else
        {
            // Do this before querying prerequisites so that the user records also exist for the prerequisites.
            await AddMissingUserRecords(context, queryResults);

            foreach (var queryResult in queryResults)
            {
                filteredResults.Add(queryResult);
            }
        }

        // OrderBy must come after the query or you get cartesian explosion.
        var orderedResults = filteredResults
            // Show exercise variations that the user has rarely seen.
            // Adding the two in case there is a warmup and main variation in the same exercise.
            // ... Otherwise, since the warmup section is always chosen first, the last seen date is always updated and the main variation is rarely chosen.
            .OrderBy(a => a.UserRecipe?.LastSeen.DayNumber)
            // Mostly for the demo, show mostly random exercises.
            // NOTE: When the two variation's LastSeen dates are the same:
            // ... The RefreshAfterXWeeks will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating exercises for the RefreshAfterXWeeks duration.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read
            .ToList();

        var nutrientTarget = NutrientOptions.NutrientTarget.Compile();
        var finalResults = new List<QueryResults>();
        do
        {
            foreach (var recipe in orderedResults)
            {
                // Don't choose recipes under our desired number of servings.
                if (ServingsOptions.AtLeastXServingsPerRecipe != null
                    && BitOperations.PopCount((ulong)recipe.Recipe.Servings) < ServingsOptions.AtLeastXServingsPerRecipe)
                {
                    if (recipe.Recipe.AdjustableServings)
                    {
                        var servings = recipe.Recipe.Servings;
                        while (servings < ServingsOptions.AtLeastXServingsPerRecipe)
                        {
                            servings += servings;
                        }

                        var servingsDifference = servings % recipe.Recipe.Servings;
                        recipe.Scale = servingsDifference;
                        foreach (var ingredient in recipe.Recipe.Ingredients)
                        {
                            ingredient.QuantityNumerator *= servingsDifference;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                // Don't overwork weekly servings.
                if (ServingsOptions.AtLeastXServingsPerRecipe != null
                    && finalResults.Aggregate(recipe.Recipe.Servings, (curr, next) => curr + next.Recipe.Servings) > ServingsOptions.WeeklyServings)
                {
                    continue;
                }

                // Don't choose exercises under our desired number of worked muscles.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe != null
                    && BitOperations.PopCount((ulong)nutrientTarget(recipe)) < NutrientOptions.AtLeastXNutrientsPerRecipe)
                {
                    continue;
                }

                // Don't overwork muscle groups.
                var overworkedMuscleGroups = GetOverworkedMuscleGroups(finalResults, nutrientTarget: nutrientTarget);
                if (overworkedMuscleGroups.Any(mg => nutrientTarget(recipe).HasAnyFlag32(mg)))
                {
                    continue;
                }

                // Choose exercises that cover at least X muscles in the targeted muscles set.
                if (NutrientOptions.AtLeastXUniqueNutrientsPerRecipe != null)
                {
                    var unworkedMuscleGroups = GetUnworkedMuscleGroups(finalResults, nutrientTarget: nutrientTarget);

                    // We've already worked all unique muscles
                    if (unworkedMuscleGroups.Count == 0)
                    {
                        break;
                    }

                    // The exercise does not work enough unique muscles that we are trying to target.
                    // Allow the first exercise with any muscle group so the user does not get stuck from seeing certain exercises if, for example, a prerequisite only works one muscle group and that muscle group is otherwise worked by compound exercises.
                    if (unworkedMuscleGroups.Count(mg => nutrientTarget(recipe).HasAnyFlag32(mg)) < Math.Max(1, finalResults.Count == 0 ? 1 : NutrientOptions.AtLeastXUniqueNutrientsPerRecipe.Value))
                    {
                        continue;
                    }
                }

                finalResults.Add(new QueryResults(section, recipe.Recipe, recipe.UserRecipe, recipe.Scale));
            }
        }
        // If AtLeastXUniqueMusclesPerExercise is say 4 and there are 7 muscle groups, we don't want 3 isolation exercises at the end if there are no 3-muscle group compound exercises to find.
        // Choose a 3-muscle group compound exercise or a 2-muscle group compound exercise and then an isolation exercise.
        while (ServingsOptions.AtLeastXServingsPerRecipe != null && --ServingsOptions.AtLeastXServingsPerRecipe >= 1
            || NutrientOptions.AtLeastXUniqueNutrientsPerRecipe != null && --NutrientOptions.AtLeastXUniqueNutrientsPerRecipe >= 1
        );

        // REFACTORME
        return section switch
        {
            Section.None => [
                .. finalResults.Take(take)
                    // Not in a workout context, order by progression levels.
                    .OrderBy(vm => vm.Recipe.Name)
            ],
            _ => finalResults.Take(take).ToList() // We are in a workout context, keep the result order.
        };
    }

    /// <summary>
    /// Reference updates to QueryResult.UserExercise and QueryResult.UserVariation to set them to default and save to db if they are null.
    /// </summary>
    private async Task AddMissingUserRecords(CoreContext context, IList<InProgressQueryResults> queryResults)
    {
        // User is not viewing a newsletter, don't log.
        if (section == Section.None)
        {
            return;
        }

        var exercisesCreated = new HashSet<UserRecipe>();
        foreach (var queryResult in queryResults.Where(qr => qr.UserRecipe == null))
        {
            queryResult.UserRecipe = new UserRecipe()
            {
                UserId = UserOptions.Id,
                RecipeId = queryResult.Recipe.Id
            };

            if (exercisesCreated.Add(queryResult.UserRecipe))
            {
                context.UserUserRecipes.Add(queryResult.UserRecipe);
            }
        }

        await context.SaveChangesAsync();
    }

    private List<Nutrients> GetUnworkedMuscleGroups(IList<QueryResults> finalResults, Func<IRecipeCombo, Nutrients> nutrientTarget, Func<IRecipeCombo, Nutrients>? secondaryMuscleTarget = null)
    {
        // Not using MuscleGroups because MuscleTargets can contain unions 
        return NutrientOptions.NutrientTargets.Where(kv =>
        {
            // We are targeting this muscle group.
            var workedCount = finalResults.WorkedAnyNutrientCount(kv.Key, nutrientTarget: nutrientTarget);
            if (secondaryMuscleTarget != null)
            {
                // Weight secondary muscles as half.
                workedCount += finalResults.WorkedAnyNutrientCount(kv.Key, nutrientTarget: secondaryMuscleTarget, weightDivisor: 2);
            }

            return workedCount < kv.Value && NutrientOptions.Nutrients.Any(mg => kv.Key.HasFlag(mg));
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrients> GetOverworkedMuscleGroups(IList<QueryResults> finalResults, Func<IRecipeCombo, Nutrients> nutrientTarget, Func<IRecipeCombo, Nutrients>? secondaryMuscleTarget = null)
    {
        // Not using MuscleGroups because MuscleTargets can contain unions.
        return NutrientOptions.NutrientTargets.Where(kv =>
        {
            // We have not overworked this muscle group.
            var workedCount = finalResults.WorkedAnyNutrientCount(kv.Key, nutrientTarget: nutrientTarget);
            if (secondaryMuscleTarget != null)
            {
                // Weight secondary muscles as half.
                workedCount += finalResults.WorkedAnyNutrientCount(kv.Key, nutrientTarget: secondaryMuscleTarget, weightDivisor: 2);
            }

            return workedCount > kv.Value;
        }).Select(kv => kv.Key).ToList();
    }
}
