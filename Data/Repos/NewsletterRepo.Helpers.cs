using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Entities.Newsletter;
using Data.Models.Newsletter;
using Data.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public partial class NewsletterRepo
{
    /// <summary>
    /// Creates a new instance of the newsletter and saves it.
    /// </summary>
    internal async Task<UserFeast> CreateAndAddNewsletterToContext(FeastContext newsletterContext, IList<QueryResults>? recipes = null)
    {
        var newsletter = new UserFeast(newsletterContext.Date, newsletterContext);
        _context.UserFeasts.Add(newsletter); // Sets the newsletter.Id after changes are saved.
        await _context.SaveChangesAsync();

        if (recipes != null)
        {
            // Ignoring base preps here because those may be scaled with other preps.
            var mainRecipes = recipes.Where(r => r.Section != Section.Prep).ToList();
            for (var i = 0; i < mainRecipes.Count; i++)
            {
                var recipe = mainRecipes[i];
                _context.UserFeastRecipes.Add(new UserFeastRecipe(newsletter, recipe, i)
                {
                    UserFeastRecipeIngredients = recipe.RecipeIngredients
                        .Where(ri => ri.Type == RecipeIngredientType.Ingredient)
                        .Select(ri => new UserFeastRecipeIngredient(ri)).ToList(),
                });

                // Using the prerequisite recipes instead of prep section recipes so that we can
                // ... swap recipes with their preps even if they were scaled with other preps.
                var prepRecipes = recipe.PrerequisiteRecipes.Select(pr => pr.Key).ToList();
                for (var i2 = 0; i2 < prepRecipes.Count; i2++)
                {
                    var prepRecipe = prepRecipes[i2];
                    _context.UserFeastRecipes.Add(new UserFeastRecipe(newsletter, prepRecipe, i2)
                    {
                        ParentRecipeId = recipe.Recipe.Id,
                        UserFeastRecipeIngredients = prepRecipe.RecipeIngredients
                            .Where(ri => ri.Type == RecipeIngredientType.Ingredient)
                            .Select(ri => new UserFeastRecipeIngredient(ri)).ToList(),
                    });
                }
            }
        }

        await _context.SaveChangesAsync();
        return newsletter;
    }

    /// <summary>
    ///     Updates the last seen date of the exercise by the user.
    /// </summary>
    /// <param name="refreshAfter">
    ///     When set and the date is > Today, hold off on refreshing the LastSeen date so that we see the same recipes in each feast.
    /// </param>
    internal async Task UpdateLastSeenDate(IEnumerable<QueryResults> recipes)
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
}
