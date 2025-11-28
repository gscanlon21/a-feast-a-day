using Core.Code.Exceptions;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredients;
using Data.Entities.Newsletter;
using Data.Entities.Users;
using Data.Models.Newsletter;
using Data.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Data.Repos;

/// <summary>
/// User helpers.
/// </summary>
public class UserRepo
{
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserRepo(CoreContext context, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// Grab a user from the db with a specific token.
    /// Throws an exception if the user cannot be found.
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

        IQueryable<User> query = _context.Users.AsSplitQuery().TagWithCallSite();

        if (includeNutrients)
        {
            query = query.Include(u => u.UserNutrients);
        }

        if (includeServings)
        {
            query = query.Include(u => u.UserSections);
        }

        if (includeFamilies)
        {
            query = query.Include(u => u.UserFamilies);
        }

        if (includeIngredients)
        {
            query = query.Include(u => u.UserRecipeIngredients);
        }

        var user = await query
            // User token is valid.
            .Where(u => u.UserTokens.Any(ut => ut.Token == token && ut.Expires > DateTime.UtcNow))
            .FirstOrDefaultAsync(u => u.Email == email);

        if (!allowDemoUser && user?.IsDemoUser == true)
        {
            throw new UserException("User not authorized.");
        }

        if (user?.Features.HasFlag(Features.Debug) == true)
        {
            user.Verbosity = Verbosity.Debug;
        }

        return user;
    }

    private static string CreateToken(int count = 24) => Convert.ToBase64String(RandomNumberGenerator.GetBytes(count));
    public async Task<string> AddUserToken(User user, int durationDays = 1) => await AddUserToken(user, DateTime.UtcNow.AddDays(durationDays));
    public async Task<string> AddUserToken(User user, DateTime expires)
    {
        if (user.IsDemoUser)
        {
            return UserConsts.DemoToken;
        }

        var token = CreateToken();
        _context.UserTokens.Add(new UserToken(user, token)
        {
            Expires = expires
        });

        await _context.SaveChangesAsync();
        return token;
    }

    /// <summary>
    /// Get the user's persistent access token.
    /// </summary>
    public async Task<string?> GetPersistentToken(User user) => (await _context.UserTokens
        .Where(ut => ut.Expires == DateTime.MaxValue)
        .Where(ut => ut.UserId == user.Id)
        .FirstOrDefaultAsync())?.Token;

    /// <summary>
    /// Get the user's current feast.
    /// </summary>
    public async Task<UserFeast?> GetCurrentFeast(User user)
    {
        return await _context.UserFeasts.AsNoTracking().TagWithCallSite()
            .Include(uw => uw.UserFeastRecipes)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date <= user.StartOfWeekOffset)
            // For the demo/test accounts. Multiple newsletters may be sent in one day,
            // ... so order by the most recently created and select the first.
            .OrderByDescending(n => n.Date)
            .ThenByDescending(n => n.Id)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Get the last 7 days of feasts for the user. Excludes the current feast.
    /// </summary>
    public async Task<IList<PastFeast>> GetPastFeasts(User user, int? count = null)
    {
        return await _context.UserFeasts
            .Where(uf => uf.UserId == user.Id)
            // Don't show backfill feasts to the user.
            .Where(uf => uf.Date >= user.CreatedDate)
            // Using NotEqual in case the user changes from
            // ... a late send day to an early one mid-week.
            .Where(uf => uf.Date != user.StartOfWeekOffset)
            // Select the most recent feast per send week.
            .GroupBy(uf => uf.Date.AddDays(-1 * ((7 + (uf.Date.DayOfWeek - user.SendDay)) % 7)))
            .OrderByDescending(g => g.Key) /// Order after grouping.
            // Can't be passed through the constructor or it's slow.
            .Select(g => new PastFeast() { Date = g.OrderByDescending(n => n.Id).First().Date })
            .Take(count ?? 7).IgnoreQueryFilters().AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Common properties surrounding today's feast.
    /// </summary>
    public async Task<FeastContext> BuildFeastContext(User user, string token, DateOnly date)
    {
        var (weeks, volumeRDA) = await GetWeeklyNutrientVolume(user, UserConsts.NutrientVolumeWeeks, rawValues: true);
        var (_, volumeTUL) = await GetWeeklyNutrientVolume(user, UserConsts.NutrientVolumeWeeks, rawValues: true, tul: true);
        return new FeastContext()
        {
            Date = date,
            User = user,
            Token = token,
            WeeklyNutrientsWeeks = weeks,
            WeeklyNutrientsRDA = volumeRDA,
            WeeklyNutrientsTUL = volumeTUL,
        };
    }

    /// <summary>
    /// Updates the last seen date of the recipe by the user.
    /// </summary>
    /// <param name="refreshAfter">
    /// When set and the date is > Today, hold off on refreshing the LastSeen date so that we see the same recipes in each feast.
    /// </param>
    public async Task UpdateLastSeenDate(IEnumerable<QueryResults> recipes)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        foreach (var recipe in recipes.DistinctBy(e => e.UserRecipe))
        {
            // >= so that today is the last day seeing the same recipes and tomorrow the recipes will refresh.
            if (recipe.UserRecipe != null && (recipe.UserRecipe.RefreshAfter == null || DateHelpers.Today >= recipe.UserRecipe.RefreshAfter))
            {
                var refreshAfter = recipe.UserRecipe.LagRefreshXWeeks == 0 ? (DateOnly?)null : DateHelpers.StartOfWeek.AddDays(7 * recipe.UserRecipe.LagRefreshXWeeks);
                // If refresh after is today, we want to see a different recipes tomorrow so update the last seen date.
                if (recipe.UserRecipe.RefreshAfter == null && refreshAfter.HasValue && refreshAfter.Value > DateHelpers.Today)
                {
                    recipe.UserRecipe.RefreshAfter = refreshAfter.Value;
                }
                else
                {
                    recipe.UserRecipe.RefreshAfter = null;
                    recipe.UserRecipe.LastSeen = DateHelpers.Today.AddDays(7 * recipe.UserRecipe.PadRefreshXWeeks);
                }
                scopedCoreContext.UserRecipes.Update(recipe.UserRecipe);
            }
        }

        await scopedCoreContext.SaveChangesAsync();
    }

    /// <summary>
    /// Get the user's average percent daily value for each nutrient.
    /// </summary>
    /// <param name="rawValues">
    /// If true, returns how much left of a nutrient to work per week.
    /// If false, returns returns the percentage a nutrient has been worked.
    /// </param>
    public async Task<(double weeks, IDictionary<Nutrients, double?>? volume)> GetWeeklyNutrientVolume(User user, int weeks, bool rawValues = false, bool tul = false, bool includeToday = false)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(weeks, 1);

        var (actualWeeks, weeklyNutrientVolume) = await GetWeeklyNutrientVolumeFromRecipeIngredients(user, weeks, includeToday: includeToday);

        var familyPeople = user.UserFamilies.GroupBy(uf => uf.Person).ToDictionary(g => g.Key, g => g);
        var familyNutrientServings = EnumExtensions.GetValuesExcluding(Nutrients.All, Nutrients.None).ToDictionary(n => n, n =>
        {
            var gramsOfRDATUL = familyPeople.Sum(fp => n.DailyAllowance(fp.Key).GramsOfRDATUL(fp.Value, tul: tul));
            var weeklyGramsOfRDATUL = gramsOfRDATUL * 7; // Get the weekly, not daily value. 7 days in a week.
            return rawValues ? (weeklyGramsOfRDATUL + (weeklyGramsOfRDATUL / weeks)) : weeklyGramsOfRDATUL;
        });

        return (weeks: actualWeeks, volume: NutrientHelpers.All.ToDictionary(n => n, n =>
        {
            // If there is no RDA or TUL.
            if (familyNutrientServings[n] <= 0) { return null; }

            // Return the percentage that each nutrient has been worked this week.
            return !rawValues ? (weeklyNutrientVolume[n] / familyNutrientServings[n] * 100)
                // Return how much left of each nutrient to work each week. Defaults to max per week.
                : ((familyNutrientServings[n] - weeklyNutrientVolume[n]) ?? familyNutrientServings[n]);
        }));
    }

    private async Task<(double weeks, IDictionary<Nutrients, double?> volume)> GetWeeklyNutrientVolumeFromRecipeIngredients(User user, int weeks, bool includeToday = false)
    {
        var weeklyFeasts = await _context.UserFeasts
            .Include(f => f.UserFeastRecipes) // Only include ingredients that have nutrients.
                .ThenInclude(r => r.UserFeastRecipeIngredients.Where(ufri => !ufri.CookedOff))
                    .ThenInclude(ufri => ufri.Ingredient)
            .Where(n => n.UserId == user.Id)
            // Include this week's data or filter out this week's data.
            .Where(n => includeToday || n.Date < user.StartOfWeekOffset)
            // Look at newsletters only that are within the last X weeks.
            .Where(n => n.Date >= user.StartOfWeekOffset.AddDays(-7 * weeks))
            // Group by the week so there's only one feast returned per week.
            .GroupBy(n => n.Date.AddDays(-1 * ((7 + (n.Date.DayOfWeek - user.SendDay)) % 7)))
            .Select(g => new { g.Key, g.OrderByDescending(n => n.Id).First().UserFeastRecipes })
            .IgnoreQueryFilters().AsNoTracking().TagWithCallSite().ToListAsync();

        // .Max/.Min throw exceptions when the collection is empty.
        if (weeklyFeasts.Count != 0)
        {
            // sa. Drop 4 weeks down to 3.5 weeks if we only have 3.5 weeks of data. Use the max newsletter date instead of today for backfilling support.
            var endDate = includeToday ? weeklyFeasts.Max(n => n.Key) : weeklyFeasts.Max(n => n.Key).EndOfWeek();
            var actualWeeks = (endDate.DayNumber - weeklyFeasts.Min(n => n.Key).StartOfWeek().DayNumber) / 7d;
            // User must have more than one week of data before we return anything.
            if (actualWeeks > UserConsts.NutrientTargetsTakeEffectAfterXWeeks)
            {
                var recipeIngredientIds = weeklyFeasts.SelectMany(f => f.UserFeastRecipes.SelectMany(r => r.UserFeastRecipeIngredients).Select(i => i.IngredientId)).ToList();
                var altIngredientIds = await _context.IngredientAlternatives.AsNoTracking()
                    .Where(ia => recipeIngredientIds.Contains(ia.IngredientId))
                    .Where(ia => ia.IsAggregateElement)
                    // Select before grouping so EF Core can optimize.
                    .Select(ia => new IngredientAlternative(/* EF can't optimize */)
                    {
                        IngredientId = ia.IngredientId,
                        AlternativeIngredientId = ia.AlternativeIngredientId,
                    })
                    .GroupBy(ia => ia.IngredientId)
                    .ToDictionaryAsync(g => g.Key, g => g.Select(ia => ia.AlternativeIngredientId).ToList());

                var allIngredientIds = recipeIngredientIds.Union(altIngredientIds.Values.SelectMany(ids => ids)).ToList();
                var allNutrients = await _context.Nutrients.AsNoTracking()
                    .Where(n => allIngredientIds.Contains(n.IngredientId))
                    // Select before grouping so EF Core can optimize.
                    .Select(n => new Nutrient(/* EF can't optimize */)
                    {
                        IngredientId = n.IngredientId,
                        Nutrients = n.Nutrients,
                        Measure = n.Measure,
                        Value = n.Value,
                    })
                    .GroupBy(n => n.IngredientId)
                    .ToDictionaryAsync(g => g.Key, g => g.Select(n => n).ToList());

                var nutrientsWorked = weeklyFeasts
                    .SelectMany(feast => feast.UserFeastRecipes
                        .SelectMany(ufr => ufr.UserFeastRecipeIngredients
                            .SelectMany(ufri => ufri.GetNutrients(allNutrients, altIngredientIds.GetValueOrDefault(ufri.IngredientId)))
                        )
                    ).ToList();

                return (weeks: actualWeeks, volume: NutrientHelpers.All.ToDictionary(m => m, m =>
                {
                    return (double?)nutrientsWorked.Sum(mm => m.HasFlag(mm.Key) ? mm.Value : 0) / actualWeeks;
                }));
            }
        }

        return (weeks: 0, volume: NutrientHelpers.All.ToDictionary(m => m, m => (double?)null));
    }

    /// <summary>
    /// Get the user's average percent daily value for each nutrient.
    /// </summary>
    /// <param name="rawValues">
    /// If true, returns how much left of a nutrient to work per week.
    /// If false, returns returns the percentage a nutrient has been worked.
    /// </param>
    public async Task<(double weeks, IDictionary<Allergens, double?>? volume)> GetWeeklyAllergens(User user, int weeks, bool includeToday = false)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(weeks, 1);

        var (actualWeeks, weeklyAllergenVolume) = await GetWeeklyAllergensFromRecipeIngredients(user, weeks, includeToday: includeToday);
        return (weeks: actualWeeks, volume: EnumExtensions.GetValuesExcluding(Allergens.None).ToDictionary(n => n, n => weeklyAllergenVolume[n]));
    }

    private async Task<(double weeks, IDictionary<Allergens, double?> volume)> GetWeeklyAllergensFromRecipeIngredients(User user, int weeks, bool includeToday = false)
    {
        var weeklyFeasts = await _context.UserFeasts
            .Include(f => f.UserFeastRecipes)
                .ThenInclude(r => r.UserFeastRecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
            .Where(n => n.UserId == user.Id)
            // Include this week's data or filter out this week's data.
            .Where(n => includeToday || n.Date < user.StartOfWeekOffset)
            // Look at newsletters only that are within the last X weeks.
            .Where(n => n.Date >= user.StartOfWeekOffset.AddDays(-7 * weeks))
            // Group by the week so there's only one feast returned per week.
            .GroupBy(n => n.Date.AddDays(-1 * ((7 + (n.Date.DayOfWeek - user.SendDay)) % 7)))
            .Select(g => new { g.Key, g.OrderByDescending(n => n.Id).First().UserFeastRecipes })
            .IgnoreQueryFilters().AsNoTracking().TagWithCallSite().ToListAsync();

        // .Max/.Min throw exceptions when the collection is empty.
        if (weeklyFeasts.Count != 0)
        {
            // sa. Drop 4 weeks down to 3.5 weeks if we only have 3.5 weeks of data. Use the max newsletter date instead of today for backfilling support.
            var endDate = includeToday ? weeklyFeasts.Max(n => n.Key) : weeklyFeasts.Max(n => n.Key).EndOfWeek();
            var actualWeeks = (endDate.DayNumber - weeklyFeasts.Min(n => n.Key).StartOfWeek().DayNumber) / 7d;
            var monthlyAllergens = weeklyFeasts
                .SelectMany(feast => feast.UserFeastRecipes
                    .SelectMany(ufr => ufr.UserFeastRecipeIngredients
                        .Select(ufri => ufri.Ingredient.Allergens)
                    )
                ).ToList();

            return (weeks: actualWeeks, volume: EnumExtensions.GetValuesExcluding(Allergens.None).ToDictionary(m => m, m =>
            {
                return (double?)monthlyAllergens.Sum(mm => (m.HasFlag(mm) && mm != Allergens.None) ? 1 : 0) / actualWeeks;
            }));
        }

        return (weeks: 0, volume: EnumExtensions.GetValuesExcluding(Allergens.None).ToDictionary(m => m, m => (double?)null));
    }
}

