using Core.Consts;
using Core.Models.User;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
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
        bool allowDemoUser = false)
    {
        if (email == null || token == null)
        {
            return null;
        }

        IQueryable<User> query = _context.Users.AsSplitQuery().TagWithCallSite();

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

    public async Task<(DateTime? NextWorkoutSendDate, TimeSpan? TimeUntilNextSend)> GetNextSendDate(User user)
    {
        DateOnly? nextSendDate = null;
        if (user.RestDays < Days.All)
        {
            nextSendDate = DateTime.UtcNow.Hour <= user.SendHour ? DateOnly.FromDateTime(DateTime.UtcNow) : DateOnly.FromDateTime(DateTime.UtcNow).AddDays(1);
            // Next send date is a rest day and user does not want off day workouts, next send date is the day after.
            while ((user.RestDays.HasFlag(DaysExtensions.FromDate(nextSendDate.Value)))
                // User was sent a newsletter for the next send date, next send date is the day after.
                // Checking for variations because we create a dummy newsletter record to advance the workout split.
                || await context.UserEmails
                    .Where(n => n.UserId == user.Id)
                    .Where(n => n.Subject == NewsletterConsts.SubjectWorkout)
                    .AnyAsync(n => n.Date == nextSendDate.Value)
                )
            {
                nextSendDate = nextSendDate.Value.AddDays(1);
            }
        }

        var nextSendDateTime = nextSendDate?.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.FromHours(user.SendHour)));
        var timeUntilNextSend = !nextSendDateTime.HasValue ? null : nextSendDateTime - DateTime.UtcNow;

        return (nextSendDateTime, timeUntilNextSend);
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
    /// Get the user's current workout.
    /// </summary>
    public async Task<UserFeast?> GetCurrentWorkout(User user)
    {
        return await _context.UserFeasts.AsNoTracking().TagWithCallSite()
            .Include(uw => uw.UserFeastRecipes)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date <= user.TodayOffset)
            // Checking the newsletter variations because we create a dummy newsletter to advance the workout split and we want actual workouts.
            .Where(n => n.UserFeastRecipes.Any())
            // For testing/demo. When two newsletters get sent in the same day, I want a different exercise set.
            // Dummy records that are created when the user advances their workout split may also have the same date.
            .OrderByDescending(n => n.Date)
            .ThenByDescending(n => n.Id)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Get the last 7 days of workouts for the user. Excludes the current workout.
    /// </summary>
    public async Task<IList<UserFeast>> GetPastWorkouts(User user)
    {
        return (await _context.UserFeasts
            .Where(uw => uw.UserId == user.Id)
            // Checking the newsletter variations because we create a dummy newsletter to advance the workout split and we want actual workouts.
            .Where(n => n.UserFeastRecipes.Any())
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

