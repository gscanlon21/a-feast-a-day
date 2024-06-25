using Core.Code.Exceptions;
using Core.Code.Extensions;
using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Newsletter;
using Data.Entities.User;
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
    /// Grab a user from the db with a specific token.
    /// </summary>
    public async Task<User> GetUserStrict(string? email, string? token,
        bool includeNutrients = false,
        bool includeServings = false,
        bool includeFamilies = false,
        bool includeIngredients = false,
        bool allowDemoUser = false)
    {
        return await GetUser(email, token,
            includeNutrients: includeNutrients,
            includeServings: includeServings,
            includeFamilies: includeFamilies,
            includeIngredients: includeIngredients,
            allowDemoUser: allowDemoUser) ?? throw new UserException("User is null.");
    }

    /// <summary>
    /// Grab a user from the db with a specific token.
    /// </summary>
    public async Task<User?> GetUser(string? email, string? token,
        bool includeNutrients = false,
        bool includeServings = false,
        bool includeFamilies = false,
        bool includeIngredients = false,
        bool allowDemoUser = false)
    {
        if (email == null || token == null)
        {
            return null;
        }

        IQueryable<User> query = context.Users.AsSplitQuery().TagWithCallSite();

        if (includeNutrients)
        {
            query = query.Include(u => u.UserNutrients);
        }

        if (includeServings)
        {
            query = query.Include(u => u.UserServings);
        }

        if (includeFamilies)
        {
            query = query.Include(u => u.UserFamilies);
        }

        if (includeIngredients)
        {
            query = query.Include(u => u.UserIngredients);
        }

        var user = await query
            // User token is valid.
            .Where(u => u.UserTokens.Any(ut => ut.Token == token && ut.Expires > DateTime.UtcNow))
            .FirstOrDefaultAsync(u => u.Email == email);

        if (!allowDemoUser && user?.IsDemoUser == true)
        {
            throw new UserException("User not authorized.");
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
                    .Where(n => n.Subject == NewsletterConsts.SubjectFeast)
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

    private async Task<(double weeks, IDictionary<Nutrients, int?> volume)> GetWeeklyMuscleVolumeFromStrengthWorkouts(User user, int weeks)
    {
        var onlySections = Section.Dinner | Section.Lunch | Section.Breakfast;
        var userServings = UserServing.DefaultServings.Where(s => onlySections.HasFlag(s.Key)).Sum(s => user.UserServings.FirstOrDefault(us => us.Section == s.Key)?.Count ?? s.Value) / 21d;
        double familyCount = Math.Max(1, user.UserFamilies.Count);
        var familyPeople = Enum.GetValues<Person>().ToDictionary(p => p, p => user.UserFamilies.Where(f => f.Person == p));

        var weeklyFeasts = await context.UserFeasts
            .AsNoTracking().TagWithCallSite()
            .Include(f => f.UserFeastRecipes)
                .ThenInclude(r => r.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                        .ThenInclude(r => r.Ingredient)
                            .ThenInclude(r => r.Nutrients)
            .Where(n => n.UserId == user.Id)
            // Only look at records where the user is not new to fitness.
            //.Where(n => user.IsNewToFitness || n.Date > user.SeasonedDate)
            // Checking the newsletter variations because we create a dummy newsletter to advance the workout split.
            .Where(n => n.UserFeastRecipes.Any())
            // Look at strengthening workouts only that are within the last X weeks.
            //.Where(n => n.Frequency != Frequency.OffDayStretches)
            .Where(n => n.Date >= DateHelpers.Today.AddDays(-7 * weeks))
            .GroupBy(n => n.Date)
            .Select(g => new
            {
                g.Key,
                // For the demo/test accounts. Multiple newsletters may be sent in one day, so order by the most recently created and select first.
                Recipes = g.OrderByDescending(n => n.Id).First().UserFeastRecipes
                    // Only select variations that worked a strengthening intensity.
                    .Where(nv => onlySections.HasFlag(nv.Section))
            }).ToListAsync();

        var userIngredients = await context.UserIngredients
           .Include(i => i.SubstituteIngredient)
               .ThenInclude(i => i.Nutrients)
           .Where(i => i.UserId == user.Id)
           .ToListAsync();

        // .Max/.Min throw exceptions when the collection is empty.
        if (weeklyFeasts.Count != 0)
        {
            // sa. Drop 4 weeks down to 3.5 weeks if we only have 3.5 weeks of data.
            var actualWeeks = (DateHelpers.Today.DayNumber - weeklyFeasts.Min(n => n.Key).DayNumber) / 7d;
            // User must have more than one week of data before we return anything.
            if (actualWeeks > UserConsts.NutrientTargetsTakeEffectAfterXWeeks)
            {
                //var weeklyServings = UserServing.DefaultServings.Sum(ds => user.UserServings.FirstOrDefault(us => us.Section == ds.Key)?.Count ?? ds.Value) / familyCount / UserServing.DefaultServings.Count;
                var totalCaloricIntake = weeklyFeasts.Sum(f => f.Recipes.Sum(r => r.Recipe.RecipeIngredients.Sum(i => i.NumberOfServings(i.Ingredient, r.Scale) * i.Ingredient.CaloriesPerServing)));
                var familyNutrientServings = EnumExtensions.GetValuesExcluding32(Nutrients.All, Nutrients.None).ToDictionary(n => n, n =>
                {
                    return (double?)familyPeople.Sum(fp => n.DailyAllowance(fp.Key).GramsOfRDA(fp.Value, totalCaloricIntake)); //* weeklyServings / 7d;
                });

                var monthlyMuscles = weeklyFeasts
                    .SelectMany(feast => feast.Recipes
                        .SelectMany(recipe => recipe.Recipe.RecipeIngredients
                            .SelectMany(recipeIngredient =>
                            {
                                var userIngredient = userIngredients.FirstOrDefault(ui => ui.IngredientId == recipeIngredient.IngredientId);
                                var substitutedIngredient = recipeIngredient.Ingredient.SubstitutedIngredient(userIngredient);
                                return substitutedIngredient.Nutrients.Select(nutrient =>
                                {
                                    var familyGrams = familyNutrientServings.FirstOrDefault(fn => fn.Key == nutrient.Nutrients).Value ?? 100;
                                    var servingsOfIngredientUsed = recipeIngredient.NumberOfServings(substitutedIngredient, recipe.Scale);
                                    var gramsOfNutrientPerServing = nutrient.Measure.ToGrams(nutrient.Value);
                                    var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing;
                                    return new
                                    {
                                        Nutrient = nutrient.Nutrients,
                                        PercentDailyValue = gramsOfNutrientPerRecipe / (familyGrams > 0 ? familyGrams : 100) * 100,
                                    };
                                });
                            })
                        )
                    ).ToList();

                return (weeks: actualWeeks, volume: UserNutrient.NutrientTargets.Keys
                    .ToDictionary(m => m, m => (int?)Convert.ToInt32(
                            monthlyMuscles.Sum(mm => m.HasFlag(mm.Nutrient) ? mm.PercentDailyValue / BitOperations.PopCount((ulong)m) : 0)
                        / actualWeeks)
                    )
                );
            }
        }

        return (weeks: 0, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(m => m, m => (int?)null));
    }

    /// <summary>
    /// Get the user's average percent daily value for each nutrient.
    /// 
    /// Returns `null` when the user is new to fitness.
    /// </summary>
    public async Task<(double weeks, IDictionary<Nutrients, int?>? volume)> GetWeeklyMuscleVolume(User user, int weeks)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(weeks, 1);

        var (strengthWeeks, weeklyMuscleVolumeFromStrengthWorkouts) = await GetWeeklyMuscleVolumeFromStrengthWorkouts(user, weeks);
        return (weeks: strengthWeeks, volume: weeklyMuscleVolumeFromStrengthWorkouts);
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
        await context.SaveChangesAsync();

        return token.Token;
    }

    public async Task<string> AddUserToken(User user, int durationDays = 1)
    {
        return await AddUserToken(user, DateTime.UtcNow.AddDays(durationDays));
    }

    /// <summary>
    /// Get the user's current workout.
    /// </summary>
    public async Task<UserFeast?> GetCurrentFeast(User user)
    {
        return await context.UserFeasts.AsNoTracking().TagWithCallSite()
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
    public async Task<IList<UserFeast>> GetPastFeasts(User user)
    {
        return (await context.UserFeasts
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
                Feast = g.OrderByDescending(n => n.Id).First()
            })
            .OrderByDescending(n => n.Key)
            .Take(7)
            .ToListAsync())
            .Select(n => n.Feast)
            .ToList();
    }
}

