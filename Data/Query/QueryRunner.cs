using Core.Code.Extensions;
using Core.Consts;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using Data.Code.Extensions;
using Data.Dtos.Newsletter;
using Data.Entities.Exercise;
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
    [DebuggerDisplay("{Exercise}")]
    private class ExercisesQueryResults
    {
        public Exercise Exercise { get; init; } = null!;
        public UserExercise UserExercise { get; init; } = null!;
    }


    [DebuggerDisplay("{Exercise}: {Variation}")]
    private class ExerciseVariationsQueryResults
        : IExerciseVariationCombo
    {
        public Exercise Exercise { get; init; } = null!;
        public UserExercise UserExercise { get; init; } = null!;
        public bool UserOwnsEquipment { get; init; }
        public bool IsMinProgressionInRange { get; init; }
        public bool IsMaxProgressionInRange { get; init; }
    }

    [DebuggerDisplay("{Exercise}: {Variation}")]
    private class InProgressQueryResults(ExerciseVariationsQueryResults queryResult) :
        IExerciseVariationCombo
    {
        public Exercise Exercise { get; } = queryResult.Exercise;
        public UserExercise? UserExercise { get; set; } = queryResult.UserExercise;
        public bool UserOwnsEquipment { get; } = queryResult.UserOwnsEquipment;
        public bool IsMinProgressionInRange { get; } = queryResult.IsMinProgressionInRange;
        public bool IsMaxProgressionInRange { get; } = queryResult.IsMaxProgressionInRange;
        public bool IsProgressionInRange => IsMinProgressionInRange && IsMaxProgressionInRange;

        public bool AllCurrentVariationsIgnored { get; set; }
        public bool AllCurrentVariationsMissingEquipment { get; set; }
        public (string? name, string? reason) EasierVariation { get; set; }
        public (string? name, string? reason) HarderVariation { get; set; }
        public int? NextProgression { get; set; }

        public override int GetHashCode() => HashCode.Combine(Exercise.Id);

        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Exercise.Id == Exercise.Id;
    }

    [DebuggerDisplay("{ExerciseId}: {VariationName}")]
    private class AllVariationsQueryResults(ExerciseVariationsQueryResults queryResult)
    {
        public int ExerciseId { get; } = queryResult.Exercise.Id;
        public bool UserOwnsEquipment { get; } = queryResult.UserOwnsEquipment;
        public bool IsMinProgressionInRange { get; } = queryResult.IsMinProgressionInRange;
        public bool IsMaxProgressionInRange { get; } = queryResult.IsMaxProgressionInRange;
        public bool IsProgressionInRange => IsMinProgressionInRange && IsMaxProgressionInRange;
    }

    [DebuggerDisplay("{ExerciseId}")]
    private class PrerequisitesQueryResults(ExerciseVariationsQueryResults queryResult)
    {
        public int ExerciseId { get; } = queryResult.Exercise.Id;
        public int UserExerciseProgression { get; } = queryResult.UserExercise?.Progression ?? UserConsts.MinUserProgression;
        public DateOnly UserExerciseLastSeen { get; } = queryResult.UserExercise?.LastSeen ?? DateOnly.MinValue;
        public bool UserOwnsEquipment { get; } = queryResult.UserOwnsEquipment;
        public bool IsMinProgressionInRange { get; } = queryResult.IsMinProgressionInRange;
        public bool IsMaxProgressionInRange { get; } = queryResult.IsMaxProgressionInRange;
        public bool IsProgressionInRange => IsMinProgressionInRange && IsMaxProgressionInRange;
    }

    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public required UserOptions UserOptions { get; init; }
    public required SelectionOptions SelectionOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required ExerciseOptions ExerciseOptions { get; init; }
    public required MovementPatternOptions MovementPattern { get; init; }
    public required ExerciseTypeOptions ExerciseTypeOptions { get; init; }
    public required JointsOptions JointsOptions { get; init; }
    public required SportsOptions SportsOptions { get; init; }
    public required EquipmentOptions EquipmentOptions { get; init; }
    public required ExerciseFocusOptions ExerciseFocusOptions { get; init; }
    public required MuscleContractionsOptions MuscleContractionsOptions { get; init; }
    public required MuscleMovementOptions MuscleMovementOptions { get; init; }

    private IQueryable<ExercisesQueryResults> CreateExercisesQuery(CoreContext context, bool includePrerequisites)
    {
        var query = context.Exercises.IgnoreQueryFilters().TagWith(nameof(CreateExercisesQuery))
            .Where(ev => ev.DisabledReason == null);

        return query.Select(i => new ExercisesQueryResults()
        {
            Exercise = i,
            UserExercise = i.UserExercises.First(ue => ue.UserId == UserOptions.Id)
        });
    }

    private IQueryable<ExerciseVariationsQueryResults> CreateExerciseVariationsQuery(CoreContext context, bool includeInstructions, bool includePrerequisites)
    {
        return CreateExercisesQuery(context, includePrerequisites: includePrerequisites)
            .Select(a => new ExerciseVariationsQueryResults()
            {
                Exercise = a.Exercise,
                UserExercise = a.UserExercise,
            });
    }

    private IQueryable<ExerciseVariationsQueryResults> CreateFilteredExerciseVariationsQuery(CoreContext context, bool includeIntensities, bool includeInstructions, bool includePrerequisites, bool ignoreExclusions = false)
    {
        var filteredQuery = CreateExerciseVariationsQuery(context,
                includeInstructions: includeInstructions,
                includePrerequisites: includePrerequisites)
            .TagWith(nameof(CreateFilteredExerciseVariationsQuery))
            // Filter down to variations the user owns equipment for
            .Where(vm => UserOptions.IgnoreMissingEquipment || vm.UserOwnsEquipment)
            // Don't grab exercises that the user wants to ignore
            .Where(vm => UserOptions.IgnoreIgnored || vm.UserExercise.Ignore != true);

        if (!ignoreExclusions)
        {
            filteredQuery = filteredQuery
                // Don't grab groups that we want to ignore
                .Where(vm => (ExclusionOptions.ExerciseGroups & vm.Exercise.Groups) == 0)
                // Don't grab exercises that we want to ignore
                .Where(vm => !ExclusionOptions.ExerciseIds.Contains(vm.Exercise.Id));
        }

        if (!UserOptions.NoUser)
        {
            // Don't show dangerous exercises when the user is new to fitness.
            filteredQuery = filteredQuery.Where(vm => !UserOptions.IsNewToFitness);
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

        var filteredQuery = CreateFilteredExerciseVariationsQuery(context, includeIntensities: true, includeInstructions: true, includePrerequisites: true);

        filteredQuery = Filters.FilterExercises(filteredQuery, ExerciseOptions.ExerciseIds);

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

            // Grab a list of non-filtered variations for all the exercises we grabbed.
            // We only need exercise variations for the exercises in our query result set.
            var allExercisesVariations = await Filters.FilterExercises(CreateExerciseVariationsQuery(context, includeInstructions: false, includePrerequisites: false), queryResults.Select(qr => qr.Exercise.Id).ToList())
                .Select(a => new AllVariationsQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync();

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
            .OrderBy(a => a.UserExercise?.LastSeen.DayNumber)
            // Mostly for the demo, show mostly random exercises.
            // NOTE: When the two variation's LastSeen dates are the same:
            // ... The RefreshAfterXWeeks will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating exercises for the RefreshAfterXWeeks duration.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read
            .ToList();

        var finalResults = new List<QueryResults>();
        do
        {
            foreach (var exercise in orderedResults)
            {
                // Don't choose two variations of the same exercise.
                if (SelectionOptions.UniqueExercises
                    && finalResults.Select(r => r.Exercise).Contains(exercise.Exercise))
                {
                    continue;
                }

                // Don't choose two variations of the same group.
                if (SelectionOptions.UniqueExercises
                    && (finalResults.Aggregate(ExerciseGroup.None, (curr, n) => curr | n.Exercise.Groups) & exercise.Exercise.Groups) != 0)
                {
                    continue;
                }

                finalResults.Add(new QueryResults(section, exercise.Exercise, exercise.UserExercise));
            }
        }
        // If AtLeastXUniqueMusclesPerExercise is say 4 and there are 7 muscle groups, we don't want 3 isolation exercises at the end if there are no 3-muscle group compound exercises to find.
        // Choose a 3-muscle group compound exercise or a 2-muscle group compound exercise and then an isolation exercise.
        while (false);

        // REFACTORME
        return section switch
        {
            Section.None => [
                .. finalResults.Take(take)
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

        // Check this first so that the LastVisible date is not updated immediately after the UserExercise record is created.
        var exercisesUpdated = new HashSet<UserExercise>();
        foreach (var queryResult in queryResults.Where(qr => qr.UserExercise != null))
        {
            queryResult.UserExercise!.LastVisible = Today;
            if (exercisesUpdated.Add(queryResult.UserExercise))
            {
                context.UserExercises.Update(queryResult.UserExercise);
            }
        }

        var exercisesCreated = new HashSet<UserExercise>();
        foreach (var queryResult in queryResults.Where(qr => qr.UserExercise == null))
        {
            queryResult.UserExercise = new UserExercise()
            {
                ExerciseId = queryResult.Exercise.Id,
                UserId = UserOptions.Id,
                Progression = UserOptions.IsNewToFitness ? UserConsts.MinUserProgression : UserConsts.MidUserProgression
            };

            if (exercisesCreated.Add(queryResult.UserExercise))
            {
                context.UserExercises.Add(queryResult.UserExercise);
            }
        }

        await context.SaveChangesAsync();
    }
}
