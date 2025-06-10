using Core.Dtos.Ingredient;
using Core.Dtos.Newsletter;
using Core.Dtos.ShoppingList;
using Core.Dtos.User;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Data.Repos;

public partial class NewsletterRepo
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly ILogger<NewsletterRepo> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NewsletterRepo(ILogger<NewsletterRepo> logger, CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IList<Footnote>> GetFootnotes(string? email, string? token, int count = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        var footnotes = await _context.Footnotes
            // Apply the user's footnote type preferences. Has any flag.
            .Where(f => user == null || (f.Type & user.FootnoteType) != 0)
            .OrderBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        return footnotes;
    }

    public async Task<IList<UserFootnote>> GetUserFootnotes(string? email, string? token, int count = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        ArgumentNullException.ThrowIfNull(user);
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return [];
        }

        var footnotes = await _context.UserFootnotes
            .Where(f => f.Type == FootnoteType.Custom)
            .Where(f => f.UserId == user.Id)
            // Keep the same footnotes over the course of a day.
            .OrderByDescending(f => f.LastSeen == DateHelpers.Today)
            .ThenBy(f => f.LastSeen.GetValueOrDefault())
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        footnotes.ForEach(f => f.LastSeen = DateHelpers.Today);
        await _context.SaveChangesAsync();
        return footnotes;
    }

    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await _userRepo.GetUserStrict(email, token, includeServings: true, includeFamilies: true, allowDemoUser: true);
        if (!user.LastActive.HasValue) { return null; }
        return await Newsletter(user, token, date);
    }

    /// <summary>
    /// Root route for building out the weekly feast newsletter.
    /// </summary>
    /// <param name="date">The utc date to send the newsletter for.</param>
    public async Task<NewsletterDto?> Newsletter(User user, string token, DateOnly? date = null)
    {
        // Newsletters are weekly so shimmy the date over to the start of the week.
        date ??= user.StartOfWeekOffset;

        _logger.Log(LogLevel.Information, "User {Id}: Building feast for {date}", user.Id, date);
        Logs.AppendLog(user, $"{date}: Building feast with options Allergens={user.Allergens}");

        // Is the user requesting an old newsletter?
        var oldNewsletter = await _context.UserFeasts.AsNoTracking()
            .Include(n => n.UserFeastRecipes)
            .Where(n => n.UserId == user.Id)
            .Where(n => n.Date == date)
            // Always send a new newsletter for the demo and test users.
            .Where(n => !user.Features.HasFlag(Features.Demo) && !user.Features.HasFlag(Features.Test))
            .OrderByDescending(n => n.Id)
            .FirstOrDefaultAsync();

        // Always send a new newsletter for today only for the demo and test users.
        var isDemoAndDateIsToday = date == user.StartOfWeekOffset && (user.Features.HasFlag(Features.Demo) || user.Features.HasFlag(Features.Test));
        if (oldNewsletter != null && !isDemoAndDateIsToday)
        {
            // An old newsletter was found.
            _logger.Log(LogLevel.Information, "Returning old feast for user {Id}", user.Id);
            Logs.AppendLog(user, $"{date}: Returning old feast");
            return await NewsletterOld(user, token, date.Value, oldNewsletter);
        }
        // Don't allow backfilling feasts over 1 year ago or in the future.
        else if (date.Value.AddYears(1) < user.StartOfWeekOffset || date > user.StartOfWeekOffset)
        {
            // A newsletter was not found and the date is not one we want to render a new newsletter for.
            _logger.Log(LogLevel.Information, "Returning no feast for user {Id}", user.Id);
            Logs.AppendLog(user, $"{date}: Returning no feast");
            return null;
        }

        var newsletterContext = await BuildFeastContext(user, token, date.Value);
        if (user.Features.HasFlag(Features.Debug))
        {
            // User is a debug user. They should see the DebugNewsletter instead.
            _logger.Log(LogLevel.Information, "Returning debug feast for user {Id}", user.Id);
            Logs.AppendLog(user, $"{date}: Returning debug feast");
            return await Debug(newsletterContext);
        }

        _logger.Log(LogLevel.Information, "Returning on day feast for user {Id}", user.Id);
        Logs.AppendLog(user, $"{date}: Returning on day feast");
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
        var userViewModel = new UserNewsletterDto(newsletterContext.User.AsType<UserDto>()!, newsletterContext.Token);

        await UpdateLastSeenDate(debugRecipes);
        return new NewsletterDto
        {
            User = userViewModel,
            Verbosity = newsletterContext.User.Verbosity,
            UserFeast = newsletter.AsType<UserFeastDto>()!,
            ShoppingList = await GetShoppingList(newsletter, debugRecipes),
            Recipes = debugRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            DebugIngredients = (await GetDebugIngredients()).Select(i => i.AsType<IngredientDto>()!).ToList(),
        };
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
        var drinkRecipes = await GetDrinkRecipes(newsletterContext, exclude: breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes).Concat(snackRecipes).Concat(dessertRecipes));
        var allRecipes = breakfastRecipes.Concat(lunchRecipes).Concat(dinnerRecipes).Concat(sideRecipes).Concat(snackRecipes).Concat(dessertRecipes).Concat(drinkRecipes).ToList();

        var newsletter = await CreateAndAddNewsletterToContext(newsletterContext, allRecipes);
        var shoppingList = await GetShoppingList(newsletter, allRecipes);
        await UpdateLastSeenDate(recipes: allRecipes);

        return new NewsletterDto
        {
            ShoppingList = shoppingList,
            Verbosity = newsletterContext.User.Verbosity,
            UserFeast = newsletter.AsType<UserFeastDto>()!,
            Recipes = allRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            User = new UserNewsletterDto(newsletterContext.User.AsType<UserDto>()!, newsletterContext.Token),
        };
    }

    /// <summary>
    /// Re-builds the newsletter for a specific date.
    /// </summary>
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, DateOnly date, UserFeast newsletter)
    {
        List<QueryResults> recipes = [];
        // Exclude fetching prep recipes, querying for a section will also return the prep recipes used.
        foreach (var section in EnumExtensions.GetSingleValues(excludingAny: Section.Prep))
        {
            recipes.AddRange((await new QueryBuilder(section)
                .WithUser(user)
                .WithRecipes(options =>
                {
                    options.AddPastRecipes(newsletter.UserFeastRecipes);
                })
                .Build()
                .Query(_serviceScopeFactory))
                // Re-order the recipes to match their original order.
                // May be null when the user substitutes in a recipe for an ingredient after the first feast was sent.
                .OrderBy(e => newsletter.UserFeastRecipes.FirstOrDefault(nv => nv.RecipeId == e.Recipe.Id)?.Order ?? -1));
        }

        var shoppingList = await GetShoppingList(newsletter, recipes);
        var userViewModel = new UserNewsletterDto(user.AsType<UserDto>()!, token);
        var newsletterViewModel = new NewsletterDto
        {
            Date = date,
            User = userViewModel,
            Verbosity = user.Verbosity,
            ShoppingList = shoppingList,
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
            UserFeast = newsletter.AsType<UserFeastDto>()!,
        };

        if (user.Features.HasFlag(Features.Debug))
        {
            var ingredients = await _context.Ingredients.Include(i => i.Nutrients).Where(i => i.LastUpdated == date).ToListAsync();
            newsletterViewModel.DebugIngredients = ingredients.Select(r => r.AsType<IngredientDto>()!).ToList();
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
                Id = group.Key.Id,
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
