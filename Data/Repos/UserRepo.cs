using Core.Consts;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Cryptography;

namespace Data.Repos;

/// <summary>
/// User helpers.
/// </summary>
public class UserRepo(CoreContext context)
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    // Keep this relatively low so it is less jarring when the user switches away from IsNewToFitness.
    private const double WeightUserIsNewXTimesMore = 1.25;

    private readonly CoreContext _context = context;

    /// <summary>
    /// Grab a user from the db with a specific token
    /// </summary>
    public async Task<User?> GetUser(string? email, string? token,
        bool includeUserExerciseVariations = false,
        bool includeExerciseVariations = false,
        bool includeMuscles = false,
        bool includeFrequencies = false,
        bool allowDemoUser = false)
    {
        if (email == null || token == null)
        {
            return null;
        }

        IQueryable<User> query = _context.Users.AsSplitQuery().TagWithCallSite();

        if (includeFrequencies)
        {
            query = query.Include(u => u.UserFrequencies);
        }

        if (includeExerciseVariations)
        {
            query = query.Include(u => u.UserExercises).ThenInclude(ue => ue.Exercise);
        }
        else if (includeUserExerciseVariations)
        {
            query = query.Include(u => u.UserExercises);
        }

        var user = await query
            // User token is valid.
            .Where(u => u.UserTokens.Any(ut => ut.Token == token && ut.Expires > DateTime.UtcNow))
            .FirstOrDefaultAsync(u => u.Email == email);

        if (!allowDemoUser && user?.IsDemoUser == true)
        {
            throw new ArgumentException("User not authorized.", nameof(email));
        }

        return user;
    }

    public static string CreateToken(int count = 24)
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(count));
    }

    public async Task<string> AddUserToken(User user, DateTime expires)
    {
        if (user.IsDemoUser)
        {
            return UserConsts.DemoToken;
        }

        var token = new UserToken(user.Id, CreateToken())
        {
            Expires = expires
        };
        user.UserTokens.Add(token);
        await _context.SaveChangesAsync();

        return token.Token;
    }

    public async Task<string> AddUserToken(User user, int durationDays = 1)
    {
        return await AddUserToken(user, DateTime.UtcNow.AddDays(durationDays));
    }

    /// <summary>
    /// Checks if the user should deload for a week.
    /// 
    /// Deloads are weeks with a message to lower the intensity of the workout so muscle growth doesn't stagnate.
    /// Also to ease up the stress on joints.
    /// </summary>
    public async Task<(bool needsDeload, TimeSpan timeUntilDeload)> CheckNewsletterDeloadStatus(User user)
    {
        var lastDeload = await _context.UserWorkouts.AsNoTracking().TagWithCallSite()
            .Where(n => n.UserId == user.Id)
            .OrderByDescending(n => n.Date)
            .FirstOrDefaultAsync(n => n.IsDeloadWeek);

        // Grabs the date of Sunday of the current week.
        var currentWeekStart = Today.AddDays(-1 * (int)Today.DayOfWeek);
        // Grabs the Sunday that was the start of the last deload.
        var lastDeloadStartOfWeek = lastDeload != null ? lastDeload.Date.AddDays(-1 * (int)lastDeload.Date.DayOfWeek) : DateOnly.MinValue;
        // Grabs the Sunday at or before the user's created date.
        var createdDateStartOfWeek = user.CreatedDate.AddDays(-1 * (int)user.CreatedDate.DayOfWeek);
        // How far away the last deload need to be before another deload.
        var countUpToNextDeload = Today.AddDays(-7 * user.DeloadAfterEveryXWeeks);

        bool isSameWeekAsLastDeload = lastDeload != null && lastDeloadStartOfWeek == currentWeekStart;
        TimeSpan timeUntilDeload = (isSameWeekAsLastDeload, lastDeload) switch
        {
            // There's never been a deload before, calculate the next deload date using the user's created date.
            (false, null) => TimeSpan.FromDays(createdDateStartOfWeek.DayNumber - countUpToNextDeload.DayNumber),
            // Calculate the next deload date using the last deload's date.
            (false, not null) => TimeSpan.FromDays(lastDeloadStartOfWeek.DayNumber - countUpToNextDeload.DayNumber),
            // Dates are the same week. Keep the deload going until the week is over.
            _ => TimeSpan.Zero
        };

        return (timeUntilDeload <= TimeSpan.Zero, timeUntilDeload);
    }

    /// <summary>
    /// Get the user's current workout.
    /// </summary>
    public async Task<UserWorkout?> GetCurrentWorkout(User user)
    {
        return await _context.UserWorkouts.AsNoTracking().TagWithCallSite()
            .Include(uw => uw.UserWorkoutVariations)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date <= user.TodayOffset)
            // Checking the newsletter variations because we create a dummy newsletter to advance the workout split and we want actual workouts.
            .Where(n => n.UserWorkoutVariations.Any())
            // For testing/demo. When two newsletters get sent in the same day, I want a different exercise set.
            // Dummy records that are created when the user advances their workout split may also have the same date.
            .OrderByDescending(n => n.Date)
            .ThenByDescending(n => n.Id)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Get the last 7 days of workouts for the user. Excludes the current workout.
    /// </summary>
    public async Task<IList<UserWorkout>> GetPastWorkouts(User user)
    {
        return (await _context.UserWorkouts
            .Where(uw => uw.UserId == user.Id)
            // Checking the newsletter variations because we create a dummy newsletter to advance the workout split and we want actual workouts.
            .Where(n => n.UserWorkoutVariations.Any())
            .Where(n => n.Date < user.TodayOffset)
            // Only select 1 workout per day, the most recent.
            .GroupBy(n => n.Date)
            .Select(g => new
            {
                g.Key,
                // For testing/demo. When two newsletters get sent in the same day, I want a different exercise set.
                // Dummy records that are created when the user advances their workout split may also have the same date.
                Workout = g.OrderByDescending(n => n.Id).First()
            })
            .OrderByDescending(n => n.Key)
            .Take(7)
            .ToListAsync())
            .Select(n => n.Workout)
            .ToList();
    }
}

