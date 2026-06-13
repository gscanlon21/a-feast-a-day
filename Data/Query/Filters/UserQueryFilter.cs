using Core.Models.Ingredients;
using Core.Models.Nutrients;
using Core.Models.Recipe;
using Data.Code.Extensions;
using Data.Entities.Ingredients;
using Data.Entities.Nutrients;
using Data.Models;
using Data.Models.Ingredients;
using Data.Query.Options;
using Data.Query.Options.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query.Filters;

public class UserQueryFilter : BaseQueryFilter
{
    protected readonly Core.Models.Newsletter.Section section;

    public UserQueryFilter(Core.Models.Newsletter.Section sec)
    {
        section = sec;
    }

    public required UserOptions UserOptions { private get; init; }
    public required NutrientOptions NutrientOptions { protected get; init; }
    public required ExclusionOptions ExclusionOptions { protected get; init; }
    public required SelectionOptions SelectionOptions { protected get; init; }

    public override async Task<List<QueryResults>> Filter(List<QueryResults> queryResults, IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
    {
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        // Order after the query or you get cartesian explosion.
        if (SelectionOptions.Randomized)
        {
            // Randomize the order. Useful for the backfill because
            // ... those feasts don't update the last seen date.
            queryResults.ShuffleInPlace();
        }
        else if (section != Core.Models.Newsletter.Section.Prep && section != Core.Models.Newsletter.Section.None)
        {
            // Don't need to order if we are in a prep or none section. Order by recipes that are still pending refresh.
            queryResults = queryResults.OrderByDescending(a => a.UserRecipe?.RefreshAfter.HasValue, NullOrder.NullsLast)
                // Show recipes that the user has rarely seen.
                // NOTE: When the two recipe's LastSeen dates are the same:
                // ... The LagRefreshXWeeks will prevent the LastSeen date from updating
                // ... and we may see two randomly alternating recipes for the LagRefreshXWeeks duration.
                .ThenBy(a => a.UserRecipe?.LastSeen?.DayNumber, NullOrder.NullsFirst)
                // Mostly for the demo, show mostly random recipes.
                .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
                // Don't re-order the list on each read.
                .ToList();
        }

        // Grab alt ingredients that are used to calculate more accurate nutrients.
        var partIngredients = await GetPartialIngredients(context, queryResults);
        // Grab all the nutrients for ingredients on the recipe after all the ingredient swapping has taken place.
        var allNutrients = NutrientOptions.DataSource switch
        {
            DataSource.USDA => await GetRecipeNutrients(context, queryResults, partIngredients),
            DataSource.Canada => await GetRecipeNutrientsCa(context, queryResults, partIngredients),
            _ => throw new NotSupportedException()
        };

        // Add in the nutrient data for filtering.
        foreach (var recipe in queryResults)
        {
            // Set the nutrients on the recipe ingredients after all the ingredient swapping has taken place.
            foreach (var recipeIngredient in recipe.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient))
            {
                recipeIngredient.GetIngredient!.QueryNutrients = allNutrients.GetValueOrDefault(recipeIngredient.GetIngredient!.Id, []);
            }
        }

        var finalResults = new HashSet<QueryResults>();
        do
        {
            foreach (var recipe in queryResults)
            {
                // Skip recipes that are working an allergen that has already been choosen. Reduce the frequency of recipes choosen containing a user's allergens.
                var allAllergens = ExclusionOptions.Allergens | GenericBitwise<Allergens>.Or(finalResults.Select(r => r.Allergens));
                // If all allergens has one and recipe allergens has one and user allergens has one, then skip this recipe.
                if ((allAllergens & recipe.Allergens & (UserOptions.Allergens | UserOptions.SemiAllergens)) != 0)
                {
                    continue;
                }

                // Don't overwork nutrients. Include the recipe and the recipe's prerequisites in this calculation.
                // Don't select all nutrients for prior results since those will include the prerequisite recipes already.
                var overworkedNutrients = GetOverworkedNutrients([recipe, .. finalResults, .. recipe.PrepRecipes.Select(pr => pr.Key)], allNutrients, partIngredients);
                if (overworkedNutrients != null)
                {
                    // If there are no non-refreshing recipes selected, loosen the nutrients-to-overwork restriction so we prioritize least seen recipes.
                    var nutrientsToOverwork = finalResults.Any(r => r.UserRecipe?.RefreshAfter == null) ? 0
                        // Buffer weeks by one available recipe per week to reduce the frequency even more.
                        : Math.Max(0, recipe.WeeksFromLastSeen - (int)Math.Floor(finalResults.Count / 7d));

                    // This way, recipes that overwork a lot of nutrients are spaced out more than the healthier recipes.
                    if (recipe.UniqueWorkedNutrients.Count(overworkedNutrients.Contains) > nutrientsToOverwork)
                    {
                        continue;
                    }
                }

                // Choose recipes that cover at least X nutrients in the targeted nutrient set.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue)
                {
                    var unworkedNutrients = GetUnworkedNutrients(finalResults, allNutrients, partIngredients);
                    if (unworkedNutrients != null)
                    {
                        // We've already worked all unique nutrients.
                        if (unworkedNutrients.Count == 0)
                        {
                            break;
                        }

                        // The recipe does not work enough unique nutrients that we are trying to target.
                        // Allow recipes that have a refresh date since we want to show those continuously until that date.
                        // Allow the first recipe with any nutrient so the user does not get stuck from seeing certain recipes
                        // ... if, for example, a prerequisite only works one nutrient and that nutrient is otherwise worked by other recipes.
                        var nutrientsToWork = (recipe.UserRecipe?.RefreshAfter != null || !finalResults.Any(r => r.UserRecipe?.RefreshAfter == null)) ? 1
                            // Choose two recipes with no refresh padding and few nutrients worked over a recipe with lots of refresh padding and many nutrients worked.
                            // This makes it harder to see a recipe that still has refresh padding because it has to work more nutrients.
                            // Doing number of weeks out so we still prefer recipes with many nutrients worked to an extent.
                            : Math.Max(1, NutrientOptions.AtLeastXNutrientsPerRecipe.Value + recipe.WeeksTillLastSeen);

                        // Include the prerequisite recipes in this calculation.
                        if (recipe.UniqueWorkedNutrients.Count(unworkedNutrients.Contains) < nutrientsToWork)
                        {
                            continue;
                        }
                    }
                }

                // Don't include the prep recipes in the take count b/c those aren't a part of the section.
                if (!finalResults.Contains(recipe) && finalResults.Count(fr => fr.Section == section) < take)
                {
                    ScaleAndAddPrepRecipes(recipe, finalResults, SelectionOptions.PrepRecipes);
                    finalResults.Add(recipe);
                }
            }
        }
        // Slowly allow out-of-preference recipes until we meet our servings/nutritional targets.
        while (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue && --NutrientOptions.AtLeastXNutrientsPerRecipe >= 1);

        /*// Show actual nutrients selected:
        if (section != Core.Models.Newsletter.Section.Prep && NutrientOptions.NutrientTargetsTUL != null)
        {
            var allNutrientsWorked = WorkedAmountOfNutrient(finalResults, allNutrients, partIngredients);
            UserLogs.Log(UserOptions, $"Nutrient results for {section}:{Environment.NewLine}{string.Join(Environment.NewLine, allNutrientsWorked.Debug())}");

            foreach (var item in NutrientOptions.NutrientTargetsTUL.Where(nt => allNutrientsWorked.ContainsKey(nt.Key)))
            {         
                if (1 - (item.Value / NutrientOptions.NutrientTargetsTUL[item.Key]) < .05)
                {
                    UserLogs.Log(UserOptions, $"Nutrient capped for {section}:{Environment.NewLine}{item.Key}:{item.Value} has max of {NutrientOptions.NutrientTargetsTUL[item.Key]}");
                }
            }
        }//*/

        return orderBy switch
        {
            // Not in a feast context, order by name.
            OrderBy.Name => [.. finalResults.OrderBy(vm => vm.Recipe.Name)],
            // We are in a feast context, keep the result order.
            _ => finalResults.ToList()
        };
    }

    /// <summary>
    /// Get the nutrients that the recipes work.
    /// </summary>
    private static async Task<Dictionary<int, List<QueryNutrient>>> GetRecipeNutrients(CoreContext context, IList<QueryResults> filteredResults, Dictionary<int, List<IngredientScale>> alternativeIngredientIds)
    {
        var ingredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient).Select(ri => ri.GetIngredient!.Id))
            .Union(alternativeIngredientIds.Values.SelectMany(ids => ids.Select(iss => iss.Ingredient.Id)))
            .ToList();

        return await context.USDANutrients.AsNoTracking().TagWithCallSite()
            .Where(n => NutrientHelpers.USDAToNutrients.Select(l => l.Key).Contains(n.Nutrients))
            .Where(n => ingredientIds.Contains(n.IngredientId))
            //.Where(n => n.Value > 0) // Checked on insert.
            // Select before grouping so EF Core can optimize.
            .Select(n => new USDANutrient(/* EF can't optimize */)
            {
                IngredientId = n.IngredientId,
                Nutrients = n.Nutrients,
                Measure = n.Measure,
                Value = n.Value,
            })
            .GroupBy(n => n.IngredientId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(n => new QueryNutrient
            {
                DataSource = DataSource.USDA,
                IngredientId = n.IngredientId,
                Nutrients = NutrientHelpers.USDAToNutrients[n.Nutrients],
                Measure = n.Measure,
                Value = n.Value,
            }).ToList());
    }

    /// <summary>
    /// Get the nutrients that the recipes work.
    /// </summary>
    private static async Task<Dictionary<int, List<QueryNutrient>>> GetRecipeNutrientsCa(CoreContext context, IList<QueryResults> filteredResults, Dictionary<int, List<IngredientScale>> alternativeIngredientIds)
    {
        var ingredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient).Select(ri => ri.GetIngredient!.Id))
            .Union(alternativeIngredientIds.Values.SelectMany(ids => ids.Select(iss => iss.Ingredient.Id)))
            .ToList();

        return await context.CanadaNutrients.AsNoTracking().TagWithCallSite()
            .Where(n => NutrientHelpers.CanadaToNutrients.Select(l => l.Key).Contains(n.Nutrients))
            .Where(n => ingredientIds.Contains(n.IngredientId))
            //.Where(n => n.Value > 0) // Checked on insert.
            // Select before grouping so EF Core can optimize.
            .Select(n => new HealthCanadaNutrient(/* EF can't optimize */)
            {
                IngredientId = n.IngredientId,
                Nutrients = n.Nutrients,
                Measure = n.Measure,
                Value = n.Value,
            })
            .GroupBy(n => n.IngredientId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(n => new QueryNutrient
            {
                DataSource = DataSource.Canada,
                IngredientId = n.IngredientId,
                Nutrients = NutrientHelpers.CanadaToNutrients[n.Nutrients],
                Measure = n.Measure,
                Value = n.Value,
            }).ToList());
    }

    /// <summary>
    /// Get all sub-ingredients worked by other ingredients.
    /// </summary>
    private static async Task<Dictionary<int, List<IngredientScale>>> GetPartialIngredients(CoreContext context, IList<QueryResults> filteredResults)
    {
        var ingredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
        return await context.IngredientAlternatives.AsNoTracking().TagWithCallSite()
            .Where(ia => ia.AlternativeIngredient.DisabledReason == null)
            .Where(ia => ingredientIds.Contains(ia.IngredientId))
            .Where(ia => ia.IsAggregateElement)
            // Select before grouping so EF Core can optimize.
            .Select(ia => new IngredientAlternative(/* EF can't optimize */)
            {
                Scale = ia.Scale,
                IngredientId = ia.IngredientId,
                AlternativeIngredient = ia.AlternativeIngredient,
            })
            .GroupBy(ia => ia.IngredientId)
            .ToDictionaryAsync(g => g.Key, g => g.Select(ia => new IngredientScale(ia.AlternativeIngredient, ia.Scale)).ToList());
    }

    private List<Nutrients>? GetUnworkedNutrients(ICollection<QueryResults> finalResults, Dictionary<int, List<QueryNutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients)
    {
        if (NutrientOptions.NutrientTargetsRDA == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults, nutrients, partialIngredients);
        // Not using Nutrients because NutrientTargets can contain unions.
        return NutrientOptions.NutrientTargetsRDA.Where(kv =>
        {
            // We are targeting this nutrient.
            return !NutrientOptions.Nutrients.Any(mg => kv.Key.HasFlag(mg))
                // We have not overconsumed this nutrient.
                || !allNutrientsWorked.TryGetValue(kv.Key, out double workedAmount) || workedAmount < kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrients>? GetOverworkedNutrients(ICollection<QueryResults> finalResults, Dictionary<int, List<QueryNutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients)
    {
        if (NutrientOptions.NutrientTargetsTUL == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults, nutrients, partialIngredients);
        // Not using Nutrients because NutrientTargets can contain unions.
        return NutrientOptions.NutrientTargetsTUL.Where(kv =>
        {
            // We have consumed too much of this nutrient.
            return allNutrientsWorked.TryGetValue(kv.Key, out double workedAmount) && workedAmount >= kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    /// <summary>
    /// Returns the nutrients targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    private static Dictionary<Nutrients, double> WorkedAmountOfNutrient(ICollection<QueryResults> list, Dictionary<int, List<QueryNutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients)
    {
        return list.SelectMany(ufr => ufr.RecipeIngredients
            .Where(ufri => ufri.Type == RecipeIngredientType.Ingredient)
            .SelectMany(ufri => ufri.GetNutrients(nutrients, partialIngredients.GetValueOrDefault(ufri.GetIngredient!.Id), ufr.Section == Core.Models.Newsletter.Section.Prep ? ufr.SetScale / ufr.GetScale : 1))
        ).GroupBy(a => a.Key).ToDictionary(a => a.Key, a => a.Sum(b => b.Value));
    }
}
