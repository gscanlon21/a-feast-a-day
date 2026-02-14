using ADay.Core.Models.Footnote;
using ADay.Data;
using ADay.Data.Entities.Footnote;
using Core.Dtos.Ingredient;
using Core.Dtos.Newsletter;
using Core.Dtos.ShoppingList;
using Core.Dtos.User;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.Users;
using Data.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly SharedContext _sharedContext;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NewsletterRepo(CoreContext context, SharedContext sharedContext, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _sharedContext = sharedContext;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IList<Footnote>> GetFootnotes(string? email, string? token, int count = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        return await _sharedContext.Footnotes
            // Apply the user's footnote type preferences. Has any flag.
            .Where(f => user == null || (f.Type & user.FootnoteType) != 0)
            .Where(f => NewsletterConsts.FootnoteTypes.Contains(f.Type))
            .OrderBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();
    }

    public async Task<IList<UserFootnote>> GetUserFootnotes(string? email, string? token, int count = 1)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        ArgumentNullException.ThrowIfNull(user);
        if (!user.FootnoteType.HasFlag(FootnoteType.Custom))
        {
            return [];
        }

        // GetValueOrDefault can't be translated by EF Core.
        var footnotes = await _context.UserFootnotes
            .Where(f => f.Type == FootnoteType.Custom)
            .Where(f => f.UserId == user.Id)
            // Keep the same footnotes over the course of a day.
            .OrderByDescending(f => f.LastSeen == DateHelpers.Today)
            .ThenBy(f => f.LastSeen.HasValue ? f.LastSeen : DateOnly.MinValue)
            .ThenBy(_ => EF.Functions.Random())
            .Take(count)
            .ToListAsync();

        footnotes.ForEach(f => f.LastSeen = DateHelpers.Today);
        await _context.SaveChangesAsync();
        return footnotes;
    }

    public async Task<NewsletterDto?> Newsletter(string email, string token, DateOnly? date = null)
    {
        var user = await _userRepo.GetUserStrict(email, token, includes: User.Includes.Newsletter, allowDemoUser: true);
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

        // Is the user requesting an old newsletter?
        var oldNewsletter = await _userRepo.GetFeastOn(user, date.Value);
        UserLogs.Log(user, $"{date}: Building feast using {oldNewsletter?.Id}.");

        // Always send a new newsletter for today only for the demo and test users.
        var isDemoAndDateIsToday = date == user.StartOfWeekOffset && (user.Features.HasFlag(Features.Demo) || user.Features.HasFlag(Features.Test));
        if (oldNewsletter != null && !isDemoAndDateIsToday)
        {
            // An old newsletter was found.
            UserLogs.Log(user, $"{date}: Returning old feast");
            return await NewsletterOld(user, token, oldNewsletter);
        }
        // Don't allow backfilling feasts over 1 year ago or in the future.
        else if (date.Value.AddYears(1) < user.StartOfWeekOffset || date > user.StartOfWeekOffset)
        {
            // A newsletter was not found and the date is not one we want to render a new newsletter for.
            UserLogs.Log(user, $"{date}: Returning no feast");
            return null;
        }

        var newsletterContext = await _userRepo.BuildFeastContext(user, token, date.Value);
        if (user.Features.HasFlag(Features.Debug))
        {
            // User is a debug user. They should see the DebugNewsletter instead.
            UserLogs.Log(user, $"{date}: Returning debug feast");
            return await Debug(newsletterContext);
        }

        UserLogs.Log(user, $"{date}: Returning on day feast");
        return await OnDayNewsletter(newsletterContext);
    }

    /// <summary>
    /// A newsletter with loads of debug information used for checking data validity.
    /// </summary>
    internal async Task<NewsletterDto?> Debug(FeastContext newsletterContext)
    {
        var debugRecipes = await GetDebugRecipes(newsletterContext.User);
        var debugIngredients = await GetDebugIngredients(newsletterContext.User).ToListAsync();

        // Is there an issue scaling the recipes?
        foreach (var debugRecipe in debugRecipes)
        {
            UserLogs.Log(newsletterContext.User, $"Scale: {debugRecipe.GetScale}");
            UserLogs.Log(newsletterContext.User, $"Recipe.Servings: {debugRecipe.Recipe.Servings}");
            UserLogs.Log(newsletterContext.User, $"UserRecipe.Servings: {debugRecipe.UserRecipe?.Servings}");
        }

        // Query for ingredients before saving the newsletter, so debug logs can be saved to it.
        var newsletter = await CreateAndAddNewsletterToContext(newsletterContext, debugRecipes);
        var userViewModel = new UserNewsletterDto(newsletterContext.User.AsType<UserDto>()!, newsletterContext.Token);

        await _userRepo.UpdateLastSeenDate(debugRecipes);
        return new NewsletterDto
        {
            User = userViewModel,
            DebugIngredients = debugIngredients,
            Verbosity = newsletterContext.User.Verbosity,
            UserFeast = newsletter.AsType<UserFeastDto>()!,
            ShoppingList = await GetShoppingList(newsletter, debugRecipes),
            Recipes = debugRecipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
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

        if (!newsletterContext.IsBackfill)
        {
            // Don't update the last seen dates when backfilling feast data
            // ... so that the user's current feasts are unaffected.
            await _userRepo.UpdateLastSeenDate(recipes: allRecipes);
        }

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
    private async Task<NewsletterDto?> NewsletterOld(User user, string token, UserFeast newsletter)
    {
        List<QueryResults> recipes = [];
        // Exclude fetching prep recipes; section queries will return their prep recipes.
        foreach (var section in EnumExtensions.GetSingleValues(excludingAny: Section.Prep))
        {
            // Need to include allergens for IsUnwantedAndHasAlternatives.
            recipes.AddRange((await new UserQueryBuilder(user, section)
                .WithEquipment(user.Equipment)
                .WithRecipes(options =>
                {
                    // This filters to only past recipes of the section.
                    options.AddPastRecipes(newsletter.UserFeastRecipes);
                })
                .WithSelectionOptions(options =>
                {
                    // Include skipped recipes in the old feasts. Enable skipping for the current week.
                    options.IncludeSkippedRecipes = newsletter.Date != user.StartOfWeekOffset;
                    // Scale serving-adjustable prep recipes.
                    options.AddScaleRecipes(recipes);
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
            User = userViewModel,
            Verbosity = user.Verbosity,
            ShoppingList = shoppingList,
            UserFeast = newsletter.AsType<UserFeastDto>()!,
            Recipes = recipes.Select(r => r.AsType<NewsletterRecipeDto>()!).ToList(),
        };

        if (user.Features.HasFlag(Features.Debug))
        {
            var ingredients = await _context.Ingredients.Include(i => i.Nutrients).Where(i => i.LastUpdated == newsletter.Date).ToListAsync();
            newsletterViewModel.DebugIngredients = ingredients.Select(r => r.AsType<IngredientDto>()!).ToList();
        }

        return newsletterViewModel;
    }

    /// <summary>
    /// Get the current shopping list for the user.
    /// </summary>
    public async Task<ShoppingListDto> GetShoppingList(UserFeast newsletter, IList<QueryResults> recipes)
    {
        var shoppingList = new List<ShoppingListItemDto>();
        var allIngredients = recipes.SelectMany(r => r.RecipeIngredients).Where(ri => ri.Ingredient != null).ToList();
        var userIngredients = await _context.UserIngredients.AsNoTracking().TagWithCallSite()
            .Where(ui => allIngredients.Select(i => i.Ingredient!.Id).Contains(ui.IngredientId))
            .Where(ui => ui.UserId == newsletter.UserId)
            .ToDictionaryAsync(ui => ui.IngredientId, ui => ui);

        // Order by RecipeIngredient.Id before grouping so the .Key is the same across requests.
        foreach (var group in allIngredients.OrderBy(ri => ri.Id).GroupBy(l => l, new ShoppingListComparer())
            .OrderBy(g => g.Key.Ingredient!.Category.GetOrder())
            .ThenBy(g => g.Key.Ingredient!.Group)
            .ThenBy(g => g.Key.Name))
        {
            var totalQuantity = group.Sum(g => g.Quantity.ToDouble() * g.Measure.ToDefaultMeasure(g.Ingredient!, g.CoarseCut));
            shoppingList.Add(new ShoppingListItemDto()
            {
                Name = group.Key.Name,
                Group = group.Key.Ingredient!.Group,
                Category = group.Key.Ingredient!.Category,
                Measure = group.Key.Ingredient.DefaultMeasure,
                SkipShoppingList = group.Key.SkipShoppingList,
                // Rounds up after the first fifth: round 4.19 down to 4, round 4.20 up to 5. 
                Quantity = Math.Max(1, (int)Math.Ceiling(Math.Floor(totalQuantity * 5) / 5)),
                Notes = userIngredients.TryGetValue(group.Key.Ingredient!.Id, out var ui) ? ui.Notes : null,
            });
        }

        return new ShoppingListDto()
        {
            ShoppingList = shoppingList,
            NewsletterId = newsletter.Id,
        };
    }

    /// <summary>
    /// Compares ingredients by their normalized Name.
    /// </summary>
    private class ShoppingListComparer : IEqualityComparer<RecipeIngredientQueryResults>
    {
        public int GetHashCode(RecipeIngredientQueryResults e) => HashCode.Combine(e.Name.TrimEnd('s'));
        public bool Equals(RecipeIngredientQueryResults? a, RecipeIngredientQueryResults? b)
            => a?.Name.TrimEnd('s', ' ') == b?.Name.TrimEnd('s', ' ');
    }
}
