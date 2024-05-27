﻿using Core.Code.Extensions;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Dtos.Newsletter;
using Data.Dtos.User;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Data.Repos;

public partial class NewsletterRepo(ILogger<NewsletterRepo> logger, CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    /// <summary>
    /// This week's Sunday date in UTC.
    /// </summary>
    protected static DateOnly StartOfWeek => Today.AddDays(-1 * (int)Today.DayOfWeek);

    public async Task<IList<Footnote>> GetFootnotes(string? email, string? token, int count = 1)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        var footnotes = await context.Footnotes
            // Apply the user's footnote type preferences. Has any flag.
            .Where(f => user == null || (f.Type & user.FootnoteType) != 0)
            .OrderBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        return footnotes;
    }

    public async Task<IList<UserFootnote>> GetUserFootnotes(string? email, string? token, int count = 1)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        ArgumentNullException.ThrowIfNull(user);
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return [];
        }

        var footnotes = await context.UserFootnotes
            .Where(f => f.Type == FootnoteType.Custom)
            .Where(f => f.UserId == user.Id)
            // Keep the same footnotes over the course of a day.
            .OrderByDescending(f => f.UserLastSeen == Today)
            // Then choose the least seen.
            .ThenBy(f => f.UserLastSeen)
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        foreach (var footnote in footnotes)
        {
            footnote.UserLastSeen = Today;
        }

        await context.SaveChangesAsync();
        return footnotes;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return null;
        }

        logger.Log(LogLevel.Information, "Building newsletter for user {Id}", user.Id);

        // Is the user requesting an old newsletter? Newsletters are weekly so shimmy the date over to the start of the week.
        date = date?.AddDays(-1 * (int)Today.DayOfWeek) ?? user.TodayOffset.AddDays(-1 * (int)Today.DayOfWeek);
        if (date.HasValue)
        {
            var oldNewsletter = await context.UserFeasts.AsNoTracking()
                .Include(n => n.UserFeastRecipes)
                .Where(n => n.User.Id == user.Id)
                // Always send a new workout for today for the demo and test users.
                .Where(n => !((user.Features.HasFlag(Features.Demo) || user.Features.HasFlag(Features.Test)) && n.Date == user.TodayOffset))
                // Checking the newsletter variations because we create a dummy newsletter to advance the workout split.
                .Where(n => n.UserFeastRecipes.Any())
                .Where(n => n.Date == date)
                // For the demo/test accounts. Multiple newsletters may be sent in one day, so order by the most recently created.
                .OrderByDescending(n => n.Id)
                .FirstOrDefaultAsync();

            // A newsletter was found.
            if (oldNewsletter != null)
            {
                logger.Log(LogLevel.Information, "Returning old newsletter for user {Id}", user.Id);
                return await NewsletterOld(user, token, date.Value, oldNewsletter);
            }
            // A newsletter was not found and the date is not one we want to render a new newsletter for.
            else if (date != user.TodayOffset)
            {
                logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }
            // Else continue on to render a new newsletter for today.
        }

        // Context may be null on rest days.
        var newsletterContext = await BuildWorkoutContext(user, token);
        if (newsletterContext == null)
        {
            // See if a previous workout exists, we send that back down so the app doesn't render nothing on rest days.
            var currentWorkout = await userRepo.GetCurrentWorkout(user);
            if (currentWorkout == null)
            {
                logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }

            logger.Log(LogLevel.Information, "Returning current newsletter for user {Id}", user.Id);
            return await NewsletterOld(user, token, currentWorkout.Date, currentWorkout);
        }

        // Current day should be a strengthening workout.
        logger.Log(LogLevel.Information, "Returning on day newsletter for user {Id}", user.Id);
        return await OnDayNewsletter(newsletterContext);
    }

    /// <summary>
    /// The meal plan newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(WorkoutContext newsletterContext)
    {
        var breakfastRecipes = await GetBreakfastRecipes(newsletterContext);
        var lunchRecipes = await GetLunchRecipes(newsletterContext, exclude: breakfastRecipes);
        var dinnerRecipes = await GetDinnerRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes));
        var sideRecipes = await GetSideRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes));
        var dessertRecipes = await GetDessertRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes));
        var recipesOfTheDay = context.UserRecipes
            .Include(r => r.Instructions)
            .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
            .Where(r => r.User.ShareMyRecipes)
            .Where(r => r.User.MaxIngredients == null || r.User.MaxIngredients >= r.Ingredients.Count(i => !i.Ingredient.SkipShoppingList))
            .OrderBy(r => EF.Functions.Random())
            .Take(1)
            .ToList();

        var newsletter = await CreateAndAddNewsletterToContext(newsletterContext,
            recipes: dinnerRecipes.Concat(sideRecipes).Concat(lunchRecipes).Concat(dessertRecipes).Concat(breakfastRecipes).ToList()
        );

        var userViewModel = new UserNewsletterDto(newsletterContext);
        var viewModel = new NewsletterDto(userViewModel, newsletter)
        {
            DinnerRecipes = dinnerRecipes,
            SideRecipes = sideRecipes,
            LunchRecipes = lunchRecipes,
            DessertRecipes = dessertRecipes,
            BreakfastRecipes = breakfastRecipes,
            //RecipesOfTheDay = recipesOfTheDay,
        };

        // Other exercises. Refresh every day.
        await UpdateLastSeenDate(exercises: dinnerRecipes.Concat(sideRecipes).Concat(lunchRecipes).Concat(dessertRecipes).Concat(breakfastRecipes));

        return viewModel;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter based on a date.
    /// </summary>
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, DateOnly date, UserFeast newsletter)
    {
        var userViewModel = new UserNewsletterDto(user, token);
        var newsletterViewModel = new NewsletterDto(userViewModel, newsletter)
        {
            Today = date,
        };

        foreach (var section in EnumExtensions.GetSingleValues32<Section>())
        {
            var exercises = (await new QueryBuilder(section)
                .WithUser(user, uniqueExercises: false)
                .WithExercises(options =>
                {
                    options.AddPastRecipes(newsletter.UserFeastRecipes);
                })
                .Build()
                .Query(serviceScopeFactory))
                .Select(r => new RecipeDto(r))
                .OrderBy(e => newsletter.UserFeastRecipes.First(nv => nv.RecipeId == e.Recipe.Id).Order)
                .ToList();

            switch (section)
            {
                case Section.Dinner:
                    newsletterViewModel.DinnerRecipes = exercises;
                    break;
                case Section.Lunch:
                    newsletterViewModel.LunchRecipes = exercises;
                    break;
                case Section.Breakfast:
                    newsletterViewModel.BreakfastRecipes = exercises;
                    break;
                case Section.Sides:
                    newsletterViewModel.SideRecipes = exercises;
                    break;
                case Section.Dessert:
                    newsletterViewModel.DessertRecipes = exercises;
                    break;
            }
        }

        return newsletterViewModel;
    }
}
