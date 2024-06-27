using Core.Code.Helpers;
using Core.Consts;
using Core.Dtos.User;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models;
using Data.Models.Newsletter;
using Microsoft.Extensions.DependencyInjection;
using Web.Code;

namespace Data.Repos;

public partial class NewsletterRepo
{
    /// <summary>
    /// Common properties surrounding today's workout.
    /// </summary>
    internal async Task<FeastContext?> BuildFeastContext(User user, string token, DateOnly date)
    {
        var (_, timeUntilNextSend) = await userRepo.GetNextSendDate(user);
        var (weeks, volume) = await userRepo.GetWeeklyNutrientVolume(user, UserConsts.TrainingVolumeWeeks, rawValues: true);
        return new FeastContext()
        {
            Date = date,
            User = user.AsType<UserDto, User>()!,
            Token = token,
            WeeklyNutrientsWeeks = weeks,
            WeeklyNutrients = volume,
            DaysUntilNextNewsletter = ((int?)timeUntilNextSend?.TotalDays + 1) ?? 1
        };
    }

    /// <summary>
    /// Creates a new instance of the newsletter and saves it.
    /// </summary>
    internal async Task<UserFeast> CreateAndAddNewsletterToContext(FeastContext newsletterContext, IList<QueryResults>? recipes = null)
    {
        var newsletter = new UserFeast(newsletterContext.Date, newsletterContext);
        context.UserFeasts.Add(newsletter); // Sets the newsletter.Id after changes are saved.
        await context.SaveChangesAsync();

        if (recipes != null)
        {
            for (var i = 0; i < recipes.Count; i++)
            {
                var recipe = recipes[i];
                context.UserFeastRecipes.Add(new UserFeastRecipe(newsletter, recipe.Recipe, recipe.Scale)
                {
                    Section = recipe.Section,
                    Order = i,
                });
            }
        }

        await context.SaveChangesAsync();
        return newsletter;
    }

    /// <summary>
    ///     Updates the last seen date of the exercise by the user.
    /// </summary>
    /// <param name="refreshAfter">
    ///     When set and the date is > Today, hold off on refreshing the LastSeen date so that we see the same exercises in each workout.
    /// </param>
    internal async Task UpdateLastSeenDate(IEnumerable<QueryResults> recipes)
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var scopedCoreContext = scope.ServiceProvider.GetRequiredService<CoreContext>();

        foreach (var recipe in recipes.DistinctBy(e => e.UserRecipe))
        {
            // >= so that today is the last day seeing the same exercises and tomorrow the exercises will refresh.
            if (recipe.UserRecipe != null && (recipe.UserRecipe.RefreshAfter == null || DateHelpers.Today >= recipe.UserRecipe.RefreshAfter))
            {
                var refreshAfter = recipe.UserRecipe.LagRefreshXWeeks == 0 ? (DateOnly?)null : DateHelpers.StartOfWeek.AddDays(7 * recipe.UserRecipe.LagRefreshXWeeks);
                // If refresh after is today, we want to see a different exercises tomorrow so update the last seen date.
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
}
