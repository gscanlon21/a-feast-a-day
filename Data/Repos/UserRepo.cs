using Core.Code.Exceptions;
using Core.Code.Extensions;
using Core.Code.Helpers;
using Core.Consts;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Data.Repos;

/// <summary>
/// User helpers.
/// </summary>
public class UserRepo
{
    private readonly CoreContext _context;

    public UserRepo(CoreContext context)
    {
        _context = context;
    }

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

        IQueryable<User> query = _context.Users.AsSplitQuery().TagWithCallSite();

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
    /// Get the user's current feast.
    /// </summary>
    public async Task<UserFeast?> GetCurrentFeast(User user)
    {
        return await _context.UserFeasts.AsNoTracking().TagWithCallSite()
            .Include(uw => uw.UserFeastRecipes)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date <= user.StartOfWeekOffset)
            // For testing/demo. When two newsletters get sent in the same day, I want a different exercise set.
            // Dummy records that are created when the user advances their workout split may also have the same date.
            .OrderByDescending(n => n.Date)
            .ThenByDescending(n => n.Id)
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Get the last 7 days of feasts for the user. Excludes the current feast.
    /// </summary>
    public async Task<IList<UserFeast>> GetPastFeasts(User user)
    {
        return (await _context.UserFeasts
            .Where(uw => uw.UserId == user.Id)
            .Where(n => n.Date < user.StartOfWeekOffset)
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

    /// <summary>
    /// Get the user's average percent daily value for each nutrient.
    /// 
    /// Returns `null` when the user is new to fitness.
    /// </summary>
    public async Task<(double weeks, IDictionary<Nutrients, double?>? volume)> GetWeeklyNutrientVolume(User user, int weeks, bool rawValues = false, bool tul = false, bool includeToday = false)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(weeks, 1);

        var (strengthWeeks, weeklyNutrientVolumeFromRecipeIngredients) = await GetWeeklyNutrientVolumeFromRecipeIngredients(user, weeks, includeToday: includeToday);
        var (_, weeklyNutrientVolumeFromRecipeIngredientRecipes) = await GetWeeklyNutrientVolumeFromRecipeIngredientRecipes(user, weeks, includeToday: includeToday);

        var familyPeople = user.UserFamilies.GroupBy(uf => uf.Person).ToDictionary(g => g.Key, g => g);
        var familyNutrientServings = EnumExtensions.GetValuesExcluding32(Nutrients.All, Nutrients.None).ToDictionary(n => n, n =>
        {
            var gramsOfRDATUL = familyPeople.Sum(fp => n.DailyAllowance(fp.Key).GramsOfRDATUL(fp.Value, tul: tul));
            return gramsOfRDATUL * 7; // Get the weekly, not daily value. 7 days in a week.
        });

        return (weeks: strengthWeeks, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(n => n, n =>
        {
            // If there is no RDA or TUL.
            if (familyNutrientServings[n] <= 0) { return null; }

            if (weeklyNutrientVolumeFromRecipeIngredients[n].HasValue && weeklyNutrientVolumeFromRecipeIngredientRecipes[n].HasValue)
            {
                return rawValues ? familyNutrientServings[n] - (weeklyNutrientVolumeFromRecipeIngredients[n].GetValueOrDefault() + weeklyNutrientVolumeFromRecipeIngredientRecipes[n].GetValueOrDefault())
                    : (weeklyNutrientVolumeFromRecipeIngredients[n].GetValueOrDefault() + weeklyNutrientVolumeFromRecipeIngredientRecipes[n].GetValueOrDefault()) / familyNutrientServings[n] * 100;
            }

            return rawValues ? familyNutrientServings[n] - weeklyNutrientVolumeFromRecipeIngredients[n]
                : weeklyNutrientVolumeFromRecipeIngredients[n] / familyNutrientServings[n] * 100;
        }));
    }

    private async Task<(double weeks, IDictionary<Nutrients, double?> volume)> GetWeeklyNutrientVolumeFromRecipeIngredients(User user, int weeks, bool includeToday = false)
    {
        var weeklyFeasts = await _context.UserFeasts
            .AsNoTracking().TagWithCallSite()
            .Include(f => f.UserFeastRecipes)
                .ThenInclude(r => r.Recipe)
                    .ThenInclude(r => r.RecipeIngredients.Where(ri => ri.IngredientId.HasValue))
                        .ThenInclude(r => r.Ingredient)
                            .ThenInclude(r => r.Nutrients)
            .Where(n => n.UserId == user.Id)
            // Look at feasts only that are within the last X weeks.
            .Where(n => n.Date >= DateHelpers.Today.AddDays(-7 * weeks))
            .Where(n => includeToday || n.Date != user.StartOfWeekOffset)
            .GroupBy(n => n.Date)
            .Select(g => new
            {
                g.Key,
                // For the demo/test accounts. Multiple newsletters may be sent in one day, so order by the most recently created and select first.
                Recipes = g.OrderByDescending(n => n.Id).First().UserFeastRecipes
            }).ToListAsync();

        var userIngredients = await _context.UserIngredients
           .Include(i => i.SubstituteIngredient)
               .ThenInclude(i => i!.Nutrients)
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
                var monthlyMuscles = weeklyFeasts
                    .SelectMany(feast => feast.Recipes
                        .SelectMany(recipe => recipe.Recipe.RecipeIngredients
                            .SelectMany(recipeIngredient =>
                            {
                                var userIngredient = userIngredients.FirstOrDefault(ui => ui.IngredientId == recipeIngredient.IngredientId);
                                var substitutedIngredient = userIngredient?.SubstituteIngredient ?? recipeIngredient.Ingredient;
                                return substitutedIngredient?.Nutrients.Select(nutrient =>
                                {
                                    var servingsOfIngredientUsed = recipeIngredient.NumberOfServings(substitutedIngredient, recipe.Scale);
                                    var gramsOfNutrientPerServing = nutrient.Measure.ToGrams(nutrient.Value);
                                    var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing;
                                    return new
                                    {
                                        Nutrient = nutrient.Nutrients,
                                        GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe,
                                    };
                                }) ?? [];
                            })
                        )
                    ).ToList();

                return (weeks: actualWeeks, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(m => m, m =>
                {
                    return (double?)monthlyMuscles.Sum(mm => m.HasFlag(mm.Nutrient) ? mm.GramsOfNutrientPerRecipe : 0) / actualWeeks;
                }));
            }
        }

        return (weeks: 0, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(m => m, m => (double?)null));
    }

    private async Task<(double weeks, IDictionary<Nutrients, double?> volume)> GetWeeklyNutrientVolumeFromRecipeIngredientRecipes(User user, int weeks, bool includeToday = false)
    {
        var weeklyFeasts = await _context.UserFeasts
            .AsNoTracking().TagWithCallSite()
            .Include(f => f.UserFeastRecipes)
                .ThenInclude(r => r.Recipe)
                    .ThenInclude(r => r.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue))
                        .ThenInclude(r => r.IngredientRecipe)
                            .ThenInclude(r => r.RecipeIngredients.Where(ri => ri.IngredientId.HasValue))
                                .ThenInclude(r => r.Ingredient)
                                    .ThenInclude(r => r.Nutrients)
            .Where(n => n.UserId == user.Id)
            // Look at feasts only that are within the last X weeks.
            .Where(n => n.Date >= DateHelpers.Today.AddDays(-7 * weeks))
            .Where(n => includeToday || n.Date != user.StartOfWeekOffset)
            .GroupBy(n => n.Date)
            .Select(g => new
            {
                g.Key,
                // For the demo/test accounts. Multiple newsletters may be sent in one day, so order by the most recently created and select first.
                Recipes = g.OrderByDescending(n => n.Id).First().UserFeastRecipes
            }).ToListAsync();

        var userIngredients = await _context.UserIngredients
           .Include(i => i.SubstituteIngredient)
               .ThenInclude(i => i!.Nutrients)
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
                var monthlyMuscles = weeklyFeasts
                    .SelectMany(feast => feast.Recipes
                        .SelectMany(recipe => recipe.Recipe.RecipeIngredients.SelectMany(ri => ri.IngredientRecipe.RecipeIngredients)
                            .SelectMany(recipeIngredient =>
                            {
                                var userIngredient = userIngredients.FirstOrDefault(ui => ui.IngredientId == recipeIngredient.IngredientId);
                                var substitutedIngredient = userIngredient?.SubstituteIngredient ?? recipeIngredient.Ingredient;
                                return substitutedIngredient?.Nutrients.Select(nutrient =>
                                {
                                    var servingsOfIngredientUsed = recipeIngredient.NumberOfServings(substitutedIngredient, recipe.Scale);
                                    var gramsOfNutrientPerServing = nutrient.Measure.ToGrams(nutrient.Value);
                                    var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing;
                                    return new
                                    {
                                        Nutrient = nutrient.Nutrients,
                                        GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe
                                    };
                                }) ?? [];
                            })
                        )
                    ).ToList();

                return (weeks: actualWeeks, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(m => m, m =>
                {
                    return (double?)monthlyMuscles.Sum(mm => m.HasFlag(mm.Nutrient) ? mm.GramsOfNutrientPerRecipe : 0) / actualWeeks;
                }));
            }
        }

        return (weeks: 0, volume: UserNutrient.NutrientTargets.Keys.ToDictionary(m => m, m => (double?)null));
    }
}

