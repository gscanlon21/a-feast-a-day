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
    public required SelectionOptions SelectionOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required RecipeOptions ExerciseOptions { get; init; }
    public required IngredientGroupOptions IngredientGroupOptions { get; init; }
    public required AllergenOptions AllergenOptions { get; init; }

    private IQueryable<RecipesQueryResults> CreateExercisesQuery(CoreContext context)
    {
        var query = context.UserRecipes.IgnoreQueryFilters().TagWith(nameof(CreateExercisesQuery))
            .Include(r => r.Instructions)
            .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            .Where(r => r.User.MaxIngredients == null || r.User.MaxIngredients >= r.Ingredients.Count(i => !i.Ingredient.SkipShoppingList))
            .Where(ev => ev.DisabledReason == null);


        return query.Select(i => new RecipesQueryResults()
        {
            Recipe = i,
            UserRecipe = i.UserUserRecipes.First(ue => ue.UserId == UserOptions.Id)
        });
    }

    private IQueryable<RecipesQueryResults> CreateFilteredExerciseVariationsQuery(CoreContext context, bool ignoreExclusions = false)
    {
        var filteredQuery = CreateExercisesQuery(context)
            .TagWith(nameof(CreateFilteredExerciseVariationsQuery))
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

        var filteredQuery = CreateFilteredExerciseVariationsQuery(context);

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterExercises(filteredQuery, ExerciseOptions.RecipeIds);
        filteredQuery = Filters.FilterMuscleGroup(filteredQuery, IngredientGroupOptions.MuscleGroups.Aggregate(Nutrient.None, (curr2, n2) => curr2 | n2), include: true);

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

        var muscleTarget = IngredientGroupOptions.MuscleTarget.Compile();
        var finalResults = new List<QueryResults>();
        do
        {
            foreach (var exercise in orderedResults)
            {
                // Don't choose two variations of the same exercise.
                if (SelectionOptions.UniqueExercises
                    && finalResults.Select(r => r.Recipe).Contains(exercise.Recipe))
                {
                    continue;
                }

                // Don't choose exercises under our desired number of servings.
                if (ServingsOptions.AtLeastXServingsPerRecipe != null
                    && BitOperations.PopCount((ulong)exercise.Recipe.Servings) < ServingsOptions.AtLeastXServingsPerRecipe)
                {
                    continue;
                }

                // Don't overwork weekly servings.
                if (ServingsOptions.AtLeastXServingsPerRecipe != null
                    && finalResults.Aggregate(exercise.Recipe.Servings, (curr, next) => curr + next.Recipe.Servings) > ServingsOptions.WeeklyServings)
                {
                    continue;
                }

                // Don't choose exercises under our desired number of worked muscles.
                if (IngredientGroupOptions.AtLeastXIngredientGroupsPerRecipe != null
                    && BitOperations.PopCount((ulong)muscleTarget(exercise)) < IngredientGroupOptions.AtLeastXIngredientGroupsPerRecipe)
                {
                    continue;
                }

                // Don't overwork muscle groups.
                var overworkedMuscleGroups = GetOverworkedMuscleGroups(finalResults, muscleTarget: muscleTarget);
                if (overworkedMuscleGroups.Any(mg => muscleTarget(exercise).HasAnyFlag32(mg)))
                {
                    continue;
                }

                finalResults.Add(new QueryResults(section, exercise.Recipe, exercise.UserRecipe));
            }
        }
        // If AtLeastXUniqueMusclesPerExercise is say 4 and there are 7 muscle groups, we don't want 3 isolation exercises at the end if there are no 3-muscle group compound exercises to find.
        // Choose a 3-muscle group compound exercise or a 2-muscle group compound exercise and then an isolation exercise.
        while (ServingsOptions.AtLeastXServingsPerRecipe != null && --ServingsOptions.AtLeastXServingsPerRecipe >= 1);


        /*
        do
        {
            foreach (var exercise in orderedResults)
            {
                // Choose exercises that cover at least X muscles in the targeted muscles set.
                if (IngredientGroupOptions.AtLeastXUniqueMusclesPerExercise != null)
                {
                    var unworkedMuscleGroups = GetUnworkedMuscleGroups(finalResults, muscleTarget: muscleTarget);

                    // We've already worked all unique muscles
                    if (unworkedMuscleGroups.Count == 0)
                    {
                        break;
                    }

                    // The exercise does not work enough unique muscles that we are trying to target.
                    // Allow the first exercise with any muscle group so the user does not get stuck from seeing certain exercises if, for example, a prerequisite only works one muscle group and that muscle group is otherwise worked by compound exercises.
                    if (unworkedMuscleGroups.Count(mg => muscleTarget(exercise).HasAnyFlag32(mg)) < Math.Max(1, finalResults.Count == 0 ? 1 : IngredientGroupOptions.AtLeastXUniqueMusclesPerExercise.Value))
                    {
                        continue;
                    }
                }

                finalResults.Add(new QueryResults(section, exercise.Recipe, exercise.UserRecipe));
            }
        }
        // If AtLeastXUniqueMusclesPerExercise is say 4 and there are 7 muscle groups, we don't want 3 isolation exercises at the end if there are no 3-muscle group compound exercises to find.
        // Choose a 3-muscle group compound exercise or a 2-muscle group compound exercise and then an isolation exercise.
        while (IngredientGroupOptions.AtLeastXUniqueMusclesPerExercise != null && --IngredientGroupOptions.AtLeastXUniqueMusclesPerExercise >= 1);
        */

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

    private List<Nutrient> GetUnworkedMuscleGroups(IList<QueryResults> finalResults, Func<IRecipeCombo, Nutrient> muscleTarget, Func<IRecipeCombo, Nutrient>? secondaryMuscleTarget = null)
    {
        // Not using MuscleGroups because MuscleTargets can contain unions 
        return IngredientGroupOptions.MuscleTargets.Where(kv =>
        {
            // We are targeting this muscle group.
            var workedCount = finalResults.WorkedAnyMuscleCount(kv.Key, muscleTarget: muscleTarget);
            if (secondaryMuscleTarget != null)
            {
                // Weight secondary muscles as half.
                workedCount += finalResults.WorkedAnyMuscleCount(kv.Key, muscleTarget: secondaryMuscleTarget, weightDivisor: 2);
            }

            return workedCount < kv.Value && IngredientGroupOptions.MuscleGroups.Any(mg => kv.Key.HasFlag(mg));
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrient> GetOverworkedMuscleGroups(IList<QueryResults> finalResults, Func<IRecipeCombo, Nutrient> muscleTarget, Func<IRecipeCombo, Nutrient>? secondaryMuscleTarget = null)
    {
        // Not using MuscleGroups because MuscleTargets can contain unions.
        return IngredientGroupOptions.MuscleTargets.Where(kv =>
        {
            // We have not overworked this muscle group.
            var workedCount = finalResults.WorkedAnyMuscleCount(kv.Key, muscleTarget: muscleTarget);
            if (secondaryMuscleTarget != null)
            {
                // Weight secondary muscles as half.
                workedCount += finalResults.WorkedAnyMuscleCount(kv.Key, muscleTarget: secondaryMuscleTarget, weightDivisor: 2);
            }

            return workedCount > kv.Value;
        }).Select(kv => kv.Key).ToList();
    }
}
