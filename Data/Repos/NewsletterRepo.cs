using Core.Dtos.Ingredient;
using Core.Dtos.Newsletter;
using Core.Dtos.ShoppingList;
using Core.Dtos.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Footnote;
using Data.Entities.Ingredient;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models;
using Data.Models.Newsletter;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Code;

namespace Data.Repos;

public partial class NewsletterRepo(ILogger<NewsletterRepo> logger, CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
{
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
            .OrderByDescending(f => f.UserLastSeen == DateHelpers.Today)
            // Then choose the least seen.
            .ThenBy(f => f.UserLastSeen)
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        foreach (var footnote in footnotes)
        {
            footnote.UserLastSeen = DateHelpers.Today;
        }

        await context.SaveChangesAsync();
        return footnotes;
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter.
    /// </summary>
    /// <param name="date">The utc date to send the newsletter for.</param>
    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true, includeServings: true, includeFamilies: true);
        if (user == null)
        {
            return null;
        }

        logger.Log(LogLevel.Information, "Building newsletter for user {Id}", user.Id);

        // Is the user requesting an old newsletter? Newsletters are weekly so shimmy the date over to the start of the week.
        date ??= user.StartOfWeekOffset;
        var oldNewsletter = await context.UserFeasts.AsNoTracking()
            .Include(n => n.UserFeastRecipes)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date == date)
            // Always send a new newsletter for the demo and test users.
            .Where(n => !user.Features.HasFlag(Features.Demo) && !user.Features.HasFlag(Features.Test))
            .OrderByDescending(n => n.Id)
            .FirstOrDefaultAsync();

        // A newsletter was found.
        if (oldNewsletter != null)
        {
            logger.Log(LogLevel.Information, "Returning old newsletter for user {Id}", user.Id);
            return await NewsletterOld(user, token, date.Value, oldNewsletter);
        }
        // A newsletter was not found and the date is not one we want to render a new newsletter for.
        else if (date != user.StartOfWeekOffset)
        {
            logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
            return null;
        }

        // Context may be null on rest days.
        var newsletterContext = await BuildFeastContext(user, token, date.Value);
        if (newsletterContext == null)
        {
            // See if a previous feast exists, we send that back down so the app doesn't render nothing on rest days.
            var currentFeast = await userRepo.GetCurrentFeast(user);
            if (currentFeast == null)
            {
                logger.Log(LogLevel.Information, "Returning no newsletter for user {Id}", user.Id);
                return null;
            }

            logger.Log(LogLevel.Information, "Returning current newsletter for user {Id}", user.Id);
            return await NewsletterOld(user, token, currentFeast.Date, currentFeast);
        }

        // User is a debug user. They should see the DebugNewsletter instead.
        if (user.Features.HasFlag(Features.Debug))
        {
            logger.Log(LogLevel.Information, "Returning debug newsletter for user {Id}", user.Id);
            return await Debug(newsletterContext);
        }

        // Current day should be a strengthening workout.
        logger.Log(LogLevel.Information, "Returning on day newsletter for user {Id}", user.Id);
        return await OnDayNewsletter(newsletterContext);
    }

    /// <summary>
    /// A newsletter with loads of debug information used for checking data validity.
    /// </summary>
    internal async Task<NewsletterDto?> Debug(FeastContext newsletterContext)
    {
        newsletterContext.User.Verbosity = Verbosity.Debug;
        var debugRecipes = await GetDebugRecipes(newsletterContext.User);
        var newsletter = await CreateAndAddNewsletterToContext(newsletterContext, recipes: debugRecipes);
        var userViewModel = new UserNewsletterDto(newsletterContext.User.AsType<UserDto, User>()!, newsletterContext.Token);

        var shoppingList = await GetShoppingList(newsletter, debugRecipes);
        var viewModel = new NewsletterDto
        {
            User = userViewModel,
            ShoppingList = shoppingList,
            Verbosity = newsletterContext.User.Verbosity,
            UserFeast = newsletter.AsType<UserFeastDto, UserFeast>()!,
            Recipes = debugRecipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
            DebugIngredients = (await GetDebugIngredients()).Select(i => i.AsType<IngredientDto, Ingredient>()!).ToList(),
        };

        await UpdateLastSeenDate(debugRecipes);
        return viewModel;
    }

    /// <summary>
    /// The meal plan newsletter.
    /// </summary>
    private async Task<NewsletterDto?> OnDayNewsletter(FeastContext newsletterContext)
    {
        var breakfastRecipes = await GetBreakfastRecipes(newsletterContext);
        var lunchRecipes = await GetLunchRecipes(newsletterContext, exclude: breakfastRecipes);
        var dinnerRecipes = await GetDinnerRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes));
        var sideRecipes = await GetSideRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes));
        var snackRecipes = await GetSnackRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes));
        var dessertRecipes = await GetDessertRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes).Concat(snackRecipes));
        var allRecipes = breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes).Concat(snackRecipes).Concat(dessertRecipes).ToList();

        var newsletter = await CreateAndAddNewsletterToContext(newsletterContext, allRecipes);
        var shoppingList = await GetShoppingList(newsletter, allRecipes);
        await UpdateLastSeenDate(recipes: allRecipes);

        return new NewsletterDto
        {
            ShoppingList = shoppingList,
            Verbosity = newsletterContext.User.Verbosity,
            UserFeast = newsletter.AsType<UserFeastDto, UserFeast>()!,
            Recipes = allRecipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
            User = new UserNewsletterDto(newsletterContext.User.AsType<UserDto, User>()!, newsletterContext.Token),
        };
    }

    /// <summary>
    /// Root route for building out the the workout routine newsletter based on a date.
    /// </summary>
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, DateOnly date, UserFeast newsletter)
    {
        List<QueryResults> recipes = [];
        // Exclude fetching prep recipes, querying for a section will also return the prep recipes used.
        foreach (var section in EnumExtensions.GetSingleValues64(excludingAny: Section.Prep))
        {
            recipes.AddRange((await new QueryBuilder(section)
                .WithUser(user)
                .WithRecipes(options =>
                {
                    options.AddPastRecipes(newsletter.UserFeastRecipes);
                })
                .Build()
                .Query(serviceScopeFactory))
                // Re-order the recipes to match their original order.
                // May be null when the user substitutes in a recipe for an ingredient after the first feast was sent.
                .OrderBy(e => newsletter.UserFeastRecipes.FirstOrDefault(nv => nv.RecipeId == e.Recipe.Id)?.Order ?? -1));
        }

        var shoppingList = await GetShoppingList(newsletter, recipes);
        var userViewModel = new UserNewsletterDto(user.AsType<UserDto, User>()!, token);
        var newsletterViewModel = new NewsletterDto
        {
            Today = date,
            User = userViewModel,
            Verbosity = user.Verbosity,
            ShoppingList = shoppingList,
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto, QueryResults>()!).ToList(),
            UserFeast = newsletter.AsType<UserFeastDto, UserFeast>()!,
        };

        if (user.Features.HasFlag(Features.Debug))
        {
            var ingredients = await context.Ingredients.Include(i => i.Nutrients).Where(i => i.LastUpdated == date).ToListAsync();
            newsletterViewModel.DebugIngredients = ingredients.Select(r => r.AsType<IngredientDto, Ingredient>()!).ToList();
        }

        return newsletterViewModel;
    }

    /// <summary>
    /// Get the current shopping list for the user.
    /// </summary>
    public static async Task<ShoppingListDto> GetShoppingList(UserFeast newsletter, IList<QueryResults> recipes)
    {
        var shoppingList = new List<ShoppingListItemDto>();
        // Order before grouping so the .Key is the same across requests.
        foreach (var group in recipes.SelectMany(r => r.RecipeIngredients).Where(ri => ri.Ingredient != null)
            .OrderBy(ri => ri.Id).GroupBy(l => l, new ShoppingListComparer()).OrderBy(l => l.Key.SkipShoppingList)
            .ThenBy(g => g.Key.Ingredient!.Category.GetSingleDisplayName(DisplayType.Order).Length)
            .ThenBy(g => g.Key.Ingredient!.Category.GetSingleDisplayName(DisplayType.Order))
            .ThenBy(g => g.Key.Name))
        {
            var totalQuantity = group.Sum(g => g.Quantity.ToDouble() * g.Measure.ToDefaultMeasure(g.Ingredient!));
            shoppingList.Add(new ShoppingListItemDto()
            {
                Name = group.Key.Name,
                Category = group.Key.Ingredient!.Category,
                Measure = group.Key.Ingredient.DefaultMeasure,
                SkipShoppingList = group.Key.SkipShoppingList,
                // Rounds up after the first fifth: round 4.19 down to 4, round 4.20 up to 5. 
                Quantity = Math.Max(1, (int)Math.Ceiling(Math.Floor(totalQuantity * 5) / 5)),
            });
        }

        return new ShoppingListDto()
        {
            NewsletterId = newsletter.Id,
            ShoppingList = shoppingList
        };
    }

    private class ShoppingListComparer : IEqualityComparer<RecipeIngredientQueryResults>
    {
        public int GetHashCode(RecipeIngredientQueryResults e) => HashCode.Combine(e.Name.TrimEnd('s'));
        public bool Equals(RecipeIngredientQueryResults? a, RecipeIngredientQueryResults? b)
            => a?.Name.TrimEnd('s', ' ') == b?.Name.TrimEnd('s', ' ');
    }
}
