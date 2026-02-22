using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Models.Ingredients;
using Data.Query.Builders;
using Data.Query.Options;
using Data.Query.Options.Users;
using Fractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Security.Cryptography;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query;

/// <summary>
/// Builds and runs an EF Core query for selecting recipes.
/// </summary>
public class QueryRunner(Section section)
{
    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    public class RecipesQueryResults : IRecipeCombo
    {
        /// <summary>EF Core can't optimize constructors.</summary>
        public RecipesQueryResults() { /* no-op */}

        public Recipe Recipe { get; init; } = null!;
        public UserRecipe UserRecipe { get; init; } = null!;
        public IList<Nutrient> Nutrients { get; init; } = null!;
        public List<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = null!;
    }

    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    private class InProgressQueryResults(RecipesQueryResults queryResult) : IRecipeCombo
    {
        public Recipe Recipe { get; } = queryResult.Recipe;
        public UserRecipe? UserRecipe { get; set; } = queryResult.UserRecipe;
        public IList<Nutrient> Nutrients { get; set; } = queryResult.Nutrients;
        public List<RecipeIngredientQueryResults> RecipeIngredients { get; set; } = queryResult.RecipeIngredients;

        public override int GetHashCode() => HashCode.Combine(Recipe.Id);
        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Recipe.Id == Recipe.Id;
    }

    [DebuggerDisplay("{Ingredient}: {Scale}")]
    private class IngredientUserIngredient
    {
        public double Scale { get; init; } = 1;
        public Measure? Measure { get; init; }
        public int? QuantityNumerator { get; init; }
        public int? QuantityDenominator { get; init; }
        public required Ingredient Ingredient { get; init; } = null!;
    }

    public required UserOptions UserOptions { get; init; }
    public required RecipeOptions RecipeOptions { get; init; }
    public required ServingOptions ServingOptions { get; init; }
    public required DurationOptions DurationOptions { get; init; }
    public required NutrientOptions NutrientOptions { get; init; }
    public required EquipmentOptions EquipmentOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required SelectionOptions SelectionOptions { get; init; }
    public required IngredientOptions IngredientOptions { get; init; }

    private IQueryable<RecipesQueryResults> CreateFilteredRecipesQuery(CoreContext context)
    {
        var query = context.Recipes.TagWith(nameof(CreateFilteredRecipesQuery))
            .IgnoreQueryFilters().AsSplitQuery()
            .Include(r => r.Instructions)
            .Where(r => r.DisabledReason == null)
            // Don't grab recipes that we want to ignore.
            .Where(r => !ExclusionOptions.RecipeIds.Contains(r.Id))
            // Make sure the user owns or is able to see the recipes.
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            // Don't grab recipes that have too many non-optional ingredients.
            .Where(r => UserOptions.MaxIngredients == null || r.RecipeIngredients.Count(i => !i.Ingredient.SkipShoppingList) <= UserOptions.MaxIngredients)
            .Select(r => new RecipesQueryResults()
            {
                Recipe = r,
                UserRecipe = r.UserRecipes.First(ur => ur.UserId == UserOptions.Id),
                // Pull these out of the constructor so that Entity Framework Core can optimize the query.
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientQueryResults()
                {
                    Id = ri.Id,
                    Order = ri.Order,
                    Measure = ri.Measure,
                    Optional = ri.Optional,
                    CoarseCut = ri.CoarseCut,
                    Adjustable = ri.Adjustable,
                    Attributes = ri.Attributes,
                    Ingredient = ri.Ingredient,
                    CookedScale = ri.CookedScale,
                    QuantityNumerator = ri.QuantityNumerator,
                    CookedIngredientId = ri.CookedIngredientId,
                    QuantityDenominator = ri.QuantityDenominator,
                    RawIngredientRecipeId = ri.IngredientRecipeId,
                    UserRecipe = ri.IngredientRecipe.UserRecipes.First(ur => ur.UserId == UserOptions.Id),
                    UserRecipeIngredient = ri.UserRecipeIngredients.First(ui => ui.UserId == UserOptions.Id && ui.RecipeIngredientId == ri.Id),
                }).ToList()
            });

        if (!UserOptions.IgnoreIgnored)
        {
            // Including skipped recipes for past feasts.
            if (!SelectionOptions.IncludeSkippedRecipes)
            {
                // Don't grab recipes that the user wants to ignore.
                query = query.Where(vm => vm.UserRecipe.IgnoreUntil.HasValue != true);
            }
            else
            {
                // Don't grab recipes that the user wants to ignore.
                query = query.Where(vm => vm.UserRecipe.IgnoreUntil != DateOnly.MaxValue);
            }

            // It's faster to check for ignored recipe ingredients where we check for allergens.
            //-Don't grab recipes that use ingredients that the user wants to ignore. 
            //.Where(vm => vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredient!.Ignore != true))
            //-Don't grab recipes that use ingredient recipes that the user wants to ignore.
            //.Where(vm => vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredientRecipe!.IgnoreUntil.HasValue != true));
        }

        return query;
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public async Task<List<QueryResults>> Query(IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
    {
        // Short-circut when this is set without any data. No results are returned.
        if (RecipeOptions.RecipeIds?.Any() == false)
        {
            return [];
        }

        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var filteredQuery = CreateFilteredRecipesQuery(context);

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterEquipment(filteredQuery, EquipmentOptions.Equipment);
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds?.Keys);
        filteredQuery = Filters.FilterServings(filteredQuery, ServingOptions.MinimumServings);
        filteredQuery = Filters.FilterIngredient(filteredQuery, IngredientOptions.IngredientName);
        filteredQuery = Filters.FilterPrepTime(filteredQuery, DurationOptions.MaxPrepTimeMinutes);
        filteredQuery = Filters.FilterCookTime(filteredQuery, DurationOptions.MaxCookTimeMinutes);
        filteredQuery = Filters.FilterTotalTime(filteredQuery, DurationOptions.MaxTotalTimeMinutes);
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients.Aggregate(Nutrients.None, (c, n) => c | n), include: true);

        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

        // When you perform comparisons with nullable types, if the value of one of the nullable types
        // ... is null and the other is not, all comparisons evaluate to false except for != (not equal).
        var filteredResults = new List<InProgressQueryResults>();
        if (UserOptions.NoUser)
        {
            // Add in the prep recipe ingredients.
            var prepRecipes = await GetPrepRecipes(factory, queryResults);
            foreach (var queryResult in queryResults)
            {
                foreach (var recipeIngredientRecipe in queryResult.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe))
                {
                    // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                    recipeIngredientRecipe.IngredientRecipe = prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredientRecipe.IngredientRecipeId)
                        // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                        ?? prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredientRecipe.RawIngredientRecipeId);
                }
            }

            filteredResults = queryResults;
        }
        else
        {
            // Do this before querying for prep recipes.
            await AddMissingUserRecords(context, queryResults);

            // Swap in user ingredients before querying for prep recipes.
            var prepRecipes = await GetPrepRecipes(factory, queryResults);
            var recipeIngredientAlt = await GetAltIngredientForRecipeIngredients(context, queryResults);
            foreach (var queryResult in queryResults)
            {
                var ignoreRecipe = false;
                var finalRecipeIngredients = new List<RecipeIngredientQueryResults>();

                // Swap or filter out optional ingredients that have allergens or are ignored
                // ... and filter out recipes containing non-optional ingredients that have allergens or are ignored.
                // Allow recipes with ingredients that have been ignored and are no longer optional so the user can still manage it.
                foreach (var recipeIngredient in queryResult.RecipeIngredients.Where(ri => ri.UserRecipeIngredient?.Ignore != true))
                {
                    // Swap in the user's recipe ingredient notes, if available & not empty.
                    if (!string.IsNullOrEmpty(recipeIngredient.UserRecipeIngredient?.Notes))
                    {
                        // Allow whitespace, so the user can remove the default system attributes.
                        recipeIngredient.Attributes = recipeIngredient.UserRecipeIngredient.Notes;
                    }

                    // Check this first so we can fallback to an ingredient if the recipe fails.
                    if (recipeIngredient.Type == RecipeIngredientType.IngredientRecipe)
                    {
                        // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                        recipeIngredient.IngredientRecipe = prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.IngredientRecipeId)
                            // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                            ?? prepRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.RawIngredientRecipeId);

                        // Ignore the recipe if the recipe ingredient recipe is missing or ignored and the recipe ingredient is non-optional.
                        if (recipeIngredient.IngredientRecipe != null)
                        {
                            // Set to null in case this ingredient recipe is a substitute for an ingredient.
                            recipeIngredient.Ingredient = null;

                            // Only scale the ingredient recipe if it is not going to fallback to an ingredient.
                            if (recipeIngredient.UserRecipeIngredient?.Measure.HasValue == true)
                            {
                                recipeIngredient.Measure = recipeIngredient.UserRecipeIngredient.Measure.Value;
                                recipeIngredient.QuantityNumerator = recipeIngredient.UserRecipeIngredient.QuantityNumerator ?? recipeIngredient.QuantityNumerator;
                                recipeIngredient.QuantityDenominator = recipeIngredient.UserRecipeIngredient.QuantityDenominator ?? recipeIngredient.QuantityDenominator;
                            }

                            // Skip filtering out this recipe ingredient.
                            finalRecipeIngredients.Add(recipeIngredient);
                            continue;
                        }
                        // If the recipe ingredient was a substitute for a regular ingredient, fallback to that ingredient.
                        else if (recipeIngredient.UserRecipeIngredient?.SubstituteRecipeId.HasValue == true
                            // Make sure we fallback to an ingredient and not another recipe.
                            && !recipeIngredient.RawIngredientRecipeId.HasValue)
                        {
                            recipeIngredient.UserRecipeIngredient.SubstituteRecipeId = null;
                        }
                    }

                    // Can't combine swapped ingredients b/c some are supposed to be duplicates.
                    if (recipeIngredient.Type == RecipeIngredientType.Ingredient)
                    {
                        // Try swapping ingredients if the user is substituting in an alternative ingredient.
                        if (recipeIngredient.UserRecipeIngredient?.SubstituteIngredientId.HasValue == true
                            // Or if any of the ingredient's allergens conflict with the user's allergens.
                            || recipeIngredient.Ingredient!.Allergens.HasAnyFlag(UserOptions.Allergens))
                        {
                            // Substitution and alternative ingredients don't have user ingredient records.
                            // This includes the base ingredient if it has substitutions available or if it is ignorable.
                            var substitution = recipeIngredientAlt.TryGetValue(recipeIngredient.Id, out var alt) ? alt : null;
                            if (substitution?.Ingredient.Allergens.HasAnyFlag(UserOptions.Allergens) == true
                                || substitution?.Ingredient.Equals(recipeIngredient.Ingredient) == true)
                            {
                                // If this gets set, the user's scale won't be applied.
                                recipeIngredient.IsUnwantedAndHasAlternatives = true;
                            }

                            // Always swap in the ingredient so we know to ignore if necessary.
                            recipeIngredient.Ingredient = substitution?.Ingredient;
                            // If user is swapping an ingredient for the recipe.
                            recipeIngredient.UserRecipeIngredient = null;

                            // If we substituted in a system alternative ingredient.
                            if (substitution != null && substitution.Scale != RecipeConsts.IngredientScaleDefault)
                            {
                                // Scale the substitution using the user's preferences or the alternative ingredient's scale.
                                var scaledQuantity = recipeIngredient.Quantity.Multiply(Fraction.FromDoubleRounded(substitution.Scale));
                                recipeIngredient.QuantityDenominator = (int)scaledQuantity.Denominator;
                                recipeIngredient.QuantityNumerator = (int)scaledQuantity.Numerator;
                            }
                            // Else if we substituted in a user substitution.
                            else if (substitution != null && substitution.Measure.HasValue)
                            {
                                recipeIngredient.Measure = substitution.Measure.Value;
                                recipeIngredient.QuantityNumerator = substitution.QuantityNumerator ?? recipeIngredient.QuantityNumerator;
                                recipeIngredient.QuantityDenominator = substitution.QuantityDenominator ?? recipeIngredient.QuantityDenominator;
                            }
                        }
                        // If this ingredient isn't being swapped (which may use its own scale), then scale the ingredient according to the user's preferences.
                        else if (recipeIngredient.UserRecipeIngredient?.Measure.HasValue == true)
                        {
                            recipeIngredient.Measure = recipeIngredient.UserRecipeIngredient.Measure.Value;
                            recipeIngredient.QuantityNumerator = recipeIngredient.UserRecipeIngredient.QuantityNumerator ?? recipeIngredient.QuantityNumerator;
                            recipeIngredient.QuantityDenominator = recipeIngredient.UserRecipeIngredient.QuantityDenominator ?? recipeIngredient.QuantityDenominator;
                        }

                        // If the ingredient was was successfully processed.
                        if (recipeIngredient.Ingredient != null)
                        {
                            // Skip filtering out this recipe ingredient.
                            finalRecipeIngredients.Add(recipeIngredient);
                            continue;
                        }
                    }

                    // If the ingredient was ignored or conflicts with allergens
                    // ... and is not optional, skip the whole recipe.
                    if (!recipeIngredient.Optional)
                    {
                        ignoreRecipe = true;
                        break;
                    }
                }

                if (!ignoreRecipe)
                {
                    queryResult.RecipeIngredients = finalRecipeIngredients;
                    filteredResults.Add(queryResult);
                }
            }
        }

        // Order after the query or you get cartesian explosion. List size doesn't change.
        var orderedResults = new List<InProgressQueryResults>(filteredResults.Count);
        if (SelectionOptions.Randomized)
        {
            // Randomize the order. Useful for the backfill because those feasts don't update the last seen date.
            orderedResults = filteredResults.OrderBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue)).ToList();
        }
        else
        {
            // Order by recipes that are still pending refresh.
            orderedResults = filteredResults.OrderByDescending(a => a.UserRecipe?.RefreshAfter.HasValue, NullOrder.NullsLast)
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
        var partIngredients = await GetPartialIngredients(context, filteredResults);
        // Grab other ingredients for cooked ingredients for more accurate nutrients.
        var cookedIngredients = await GetCookedIngredients(context, filteredResults, partIngredients);
        // Grab all the nutrients for ingredinets on the recipe after all the ingredient swapping has taken place.
        var allNutrients = await GetRecipeNutrients(context, filteredResults, partIngredients, cookedIngredients);

        // List size doesn't change. Use the same capacity as the orderedResults.
        var recipeResults = new List<QueryResults>(orderedResults.Count);
        foreach (var recipe in orderedResults)
        {
            // Set the nutrients on the recipe ingredients after all the ingredient swapping has taken place.
            foreach (var recipeIngredient in recipe.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient))
            {
                recipeIngredient.GetIngredient!.Nutrients = allNutrients.GetValueOrDefault(recipeIngredient.GetIngredient!.Id, []);
            }

            // Order the recipe ingredients based on user preferences. Always order recipes before ingredients.
            recipe.RecipeIngredients = ((recipe.Recipe.KeepIngredientOrder, UserOptions.IngredientOrder) switch
            {
                (false, IngredientOrder.OptionalLast) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Optional).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                (false, IngredientOrder.LargeToSmall) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                _ => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Order),
            }).ToList();

            recipeResults.Add(new QueryResults(section, recipe.Recipe, recipe.RecipeIngredients, recipe.UserRecipe)
            {
                // Scaling the recipe will also scale the recipe ingredient quantities which then affects ingredient recipe scales.
                SetScale = (RecipeOptions.RecipeIds?.TryGetValue(recipe.Recipe.Id, out int? scale) == true && scale.HasValue) ? scale.Value
                    : (recipe.UserRecipe != null && recipe.Recipe.AdjustableServings) ? recipe.UserRecipe.Servings / (double)recipe.Recipe.Servings : 1,
            });
        }

        var finalResults = new HashSet<QueryResults>();
        do
        {
            foreach (var recipe in recipeResults)
            {
                // Don't filter out allergens if we're choosing recipes.
                if (RecipeOptions.RecipeIds?.Any() != true)
                {
                    // Skip recipes that are working an allergen that has already been choosen. Reduce the frequency of recipes choosen containing a user's allergens.
                    var allAllergens = ExclusionOptions.Allergens | GenericBitwise<Allergens>.Or(finalResults.Select(r => r.Allergens));
                    // If all allergens has one and recipe allergens has one and user allergens has one, then skip this recipe.
                    if ((allAllergens & recipe.Allergens & (UserOptions.Allergens | UserOptions.SemiAllergens)) != 0)
                    {
                        continue;
                    }
                }

                // Don't overwork nutrients. Include the recipe and the recipe's prerequisites in this calculation.
                // Don't select all nutrients for prior results since those will include the prerequisite recipes already.
                var overworkedNutrients = GetOverworkedNutrients([recipe, .. finalResults, .. recipe.PrepRecipes.Select(pr => pr.Key)], allNutrients, partIngredients, cookedIngredients);
                if (overworkedNutrients != null)
                {
                    // Find the number of weeks since this recipe has been seen. If the last seen date is in the future (has refresh padding), then use zero weeks.
                    var weeksFromLastSeen = Math.Max(0, DateHelpers.Today.DayNumber - (recipe.UserRecipe?.LastSeen?.DayNumber ?? DateHelpers.Today.DayNumber)) / 7;
                    // If there are no non-refreshing recipes selected, loosen the nutrients-to-overwork restriction so we prioritize least seen recipes.
                    var nutrientsToOverwork = finalResults.Any(r => r.UserRecipe?.RefreshAfter == null) ? 0
                        // Buffer by one available recipe per week to reduce the frequency even more.
                        : Math.Max(0, weeksFromLastSeen - (int)Math.Floor(recipeResults.Count / 7d));

                    // This way, recipes that overwork a lot of nutrients are spaced out more than the healthier recipes.
                    if (overworkedNutrients.Count(recipe.UniqueWorkedNutrients.Contains) > nutrientsToOverwork)
                    {
                        continue;
                    }
                }

                // Choose recipes that cover at least X nutrients in the targeted nutrient set.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue)
                {
                    var unworkedNutrients = GetUnworkedNutrients(finalResults, allNutrients, partIngredients, cookedIngredients);
                    if (unworkedNutrients != null)
                    {
                        // We've already worked all unique nutrients.
                        if (unworkedNutrients.Count == 0)
                        {
                            break;
                        }

                        // This makes it harder to see a recipe that still has refresh padding because it has to work more nutrients.
                        // Find the number of weeks of padding that this recipe still has left. If the padded refresh date is earlier than today, then use the number 0.
                        var weeksTillLastSeen = Math.Max(0, (recipe.UserRecipe?.LastSeen?.DayNumber ?? DateHelpers.Today.DayNumber) - DateHelpers.Today.DayNumber) / 7;
                        // The recipe does not work enough unique nutrients that we are trying to target.
                        // Allow recipes that have a refresh date since we want to show those continuously until that date.
                        // Allow the first recipe with any nutrient so the user does not get stuck from seeing certain recipes
                        // ... if, for example, a prerequisite only works one nutrient and that nutrient is otherwise worked by other recipes.
                        var nutrientsToWork = (recipe.UserRecipe?.RefreshAfter != null || !finalResults.Any(r => r.UserRecipe?.RefreshAfter == null)) ? 1
                            // Choose two recipes with no refresh padding and few nutrients worked over a recipe with lots of refresh padding and many nutrients worked.
                            // Doing weeks out so we still prefer recipes with many nutrients worked to an extent.
                            : Math.Max(1, NutrientOptions.AtLeastXNutrientsPerRecipe.Value + weeksTillLastSeen);

                        // Include the prerequisite recipes in this calculation.
                        if (recipe.UniqueWorkedNutrients.Count < nutrientsToWork)
                        {
                            continue;
                        }
                    }
                }

                // Don't include the prep recipes in the take count b/c those aren't a part of the section.
                if (!finalResults.Contains(recipe) && finalResults.Count(fr => fr.Section == section) < take)
                {
                    // Append the recipe's prep recipes. Scale them if they are duplicates and are adjustable.
                    foreach (var prepRecipe in recipe.PrepRecipes.Where(_ => !RecipeOptions.IgnorePrepRecipes))
                    {
                        // Scale the prep recipe based on the prep's serving size and the recipe-ingredient-for-the-prep's quantity.
                        var noneRecipeIngredientsGrams = prepRecipe.Value.Where(ri => ri.Measure == Measure.None).Sum(r => r.Measure.ToGramsOrMilliliters(r.Quantity.ToDouble()));
                        var someRecipeIngredientsGrams = prepRecipe.Value.Where(ri => ri.Measure != Measure.None).Sum(r => r.Measure.ToGramsOrMilliliters(r.Quantity.ToDouble()));
                        if (someRecipeIngredientsGrams > 0 && prepRecipe.Key.Recipe.Measure == Measure.None)
                        {
                            // If the measures don't align, use the sum of the recipe ingredients times the recipe's servings b/c the recipe hasn't been scaled yet.
                            var prepRecipeGrams = prepRecipe.Key.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient).Sum(ri => ri.GramsUsed(ri.Ingredient!)) * prepRecipe.Key.Recipe.Servings;
                            prepRecipe.Key.SetScale = ((noneRecipeIngredientsGrams * prepRecipeGrams) + someRecipeIngredientsGrams) / prepRecipeGrams;
                        }
                        else
                        {
                            // Normal scaling, divide the sum of the recipe ingredient's quantities by the serving size scaled prerequisite quantity.
                            prepRecipe.Key.SetScale = (noneRecipeIngredientsGrams + someRecipeIngredientsGrams) / prepRecipe.Key.Recipe.Measure.ToGramsOrMilliliters(prepRecipe.Key.Recipe.Servings);
                        }

                        // If the prep recipes already exists in our feast for any prior section and is scalable, then scale it.
                        if (SelectionOptions.PrepRecipes.TryGetValue(prepRecipe.Key, out var scalePrepRecipe) && scalePrepRecipe.Recipe.AdjustableServings)
                        {
                            scalePrepRecipe.SetScale += prepRecipe.Key.SetScale;
                        }
                        // If the prep recipe already exists in our feast for this section and is scalable, then scale it.
                        else if (finalResults.TryGetValue(prepRecipe.Key, out var existingPrepRecipe) && existingPrepRecipe.Recipe.AdjustableServings)
                        {
                            existingPrepRecipe.SetScale += prepRecipe.Key.SetScale;
                        }
                        else
                        {
                            finalResults.Add(prepRecipe.Key);
                        }
                    }

                    finalResults.Add(recipe);
                }
            }
        }
        // Slowly allow out-of-preference recipes until we meet our servings/nutritional targets.
        while (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue && --NutrientOptions.AtLeastXNutrientsPerRecipe >= 1);

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
    private static async Task<Dictionary<int, Ingredient>> GetCookedIngredients(CoreContext context, IList<InProgressQueryResults> filteredResults, Dictionary<int, List<IngredientScale>> alternativeIngredientIds)
    {
        var ingredients = filteredResults.SelectMany(qr => qr.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient).Select(ri => ri.GetIngredient!))
            .Union(alternativeIngredientIds.Values.SelectMany(ids => ids.Select(iss => iss.Ingredient)))
            .ToDictionary(i => i.Id, i => i);

        return (await context.RecipeIngredients.AsNoTracking().IgnoreQueryFilters()
            .Include(ic => ic.CookedIngredient)
            .Where(ri => ri.CookedIngredientId.HasValue)
            .Where(ri => ingredients.Keys.Contains(ri.IngredientId!.Value))
            // Pull these out of the constuctor so EF Core can optimize the query.
            .Select(ri => new
            {
                ri.Id,
                ri.IngredientId,
                ri.CookedIngredientId,
                CookedIngredient = ri.IngredientId != ri.CookedIngredientId ? ri.CookedIngredient : null,
            })
            .ToListAsync())
            .ToDictionary(ri => ri.Id, ri => ri.CookedIngredient ?? ingredients[ri.IngredientId!.Value]);
    }

    /// <summary>
    /// Get the nutrients that the recipes work.
    /// </summary>
    private static async Task<Dictionary<int, List<Nutrient>>> GetRecipeNutrients(CoreContext context, IList<InProgressQueryResults> filteredResults, Dictionary<int, List<IngredientScale>> alternativeIngredientIds, Dictionary<int, Ingredient> cookedIngredients)
    {
        var allIngredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.Ingredient).Select(ri => ri.GetIngredient!.Id))
            .Union(alternativeIngredientIds.Values.SelectMany(ids => ids.Select(iss => iss.Ingredient.Id)))
            .Union(cookedIngredients.Values.Select(ci => ci.Id))
            .ToList();

        return await context.Nutrients.AsNoTracking().TagWithCallSite()
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
    }

    /// <summary>
    /// Get the nutrients that the recipes work.
    /// </summary>
    private static async Task<Dictionary<int, List<IngredientScale>>> GetPartialIngredients(CoreContext context, IList<InProgressQueryResults> filteredResults)
    {
        var allFilteredResultIngredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
        return await context.IngredientAlternatives.AsNoTracking().TagWithCallSite()
            .Where(ia => allFilteredResultIngredientIds.Contains(ia.IngredientId))
            .Where(ia => ia.AlternativeIngredient.DisabledReason == null)
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

    /// <summary>
    /// Returns the recipes that are using in this recipe.
    /// </summary>
    private async Task<IList<QueryResults>> GetPrepRecipes(IServiceScopeFactory factory, IList<InProgressQueryResults> filteredResults)
    {
        // Don't check RecipeOptions.IgnorePrepRecipes yet so other things work.
        var prepRecipeIds = filteredResults.SelectMany(ar => ar.RecipeIngredients
            // Query for prerequisites ingredient recipes here so we can check their ignored status before finalizing recipes.
            .Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe)).Where(ri => ri.UserRecipeIngredient?.Ignore != true)
            // Search for both the substituted recipe ingredient and the raw recipe ingredient, so we can fallback if one conflicts with allergens.
            .SelectMany(ri => new List<int?>(2) { ri.IngredientRecipeId, ri.RawIngredientRecipeId }).Where(rid => rid.HasValue).Distinct()
            // Don't scale prerequisite recipes yet since the prerequisite recipe scale is based on the quantity of the ingredient recipe.    
            .GroupBy(ri => ri!.Value).ToDictionary(g => g.Key, ri => (int?)1/*(int)Math.Ceiling(ri.Quantity.ToDouble())*/);

        // This will filter out prep recipes missing equipemnt. No infinite recursion please. 
        return prepRecipeIds.Any() ? await new UserOptionsQueryBuilder(UserOptions, Section.Prep)
            .WithUser(options =>
            {
                // Keep ignored base recipes, user should ignore the recipe ingredient if they need to ignore this.
                // This allows the user to ignore "Sides" recipes that also function as base recipes.
                options.IgnoreIgnored = true;
            })
            .WithEquipment(EquipmentOptions.Equipment)
            .WithRecipes(options => options.AddRecipes(prepRecipeIds))
            .Build().Query(factory) : [];
    }

    /// <summary>
    /// Get the alternative ingredients for all of the ingredients, ignoring ignored alternative ingredients.
    /// Includes the base recipe ingredient's ingredient if it has substitutions available or if it is ignorable.
    /// </summary>
    private async Task<IDictionary<int, IngredientUserIngredient?>> GetAltIngredientForRecipeIngredients(CoreContext context, IList<InProgressQueryResults> queryResults)
    {
        var recipeIngredientIds = queryResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Id)).ToList();
        return (await context.RecipeIngredients.TagWithCallSite().AsNoTracking()
            .Where(ri => recipeIngredientIds.Contains(ri.Id))
            .Select(ri => new
            {
                ri.Id,
                ri.RecipeId,
                ri.Ingredient,
                ri.UserRecipeIngredients.Where(ui => ui.RecipeIngredientId == ri.Id).First(ui => ui.UserId == UserOptions.Id).Measure,
                ri.UserRecipeIngredients.Where(ui => ui.RecipeIngredientId == ri.Id).First(ui => ui.UserId == UserOptions.Id).QuantityNumerator,
                ri.UserRecipeIngredients.Where(ui => ui.RecipeIngredientId == ri.Id).First(ui => ui.UserId == UserOptions.Id).QuantityDenominator,
                ri.UserRecipeIngredients.Where(ui => ui.RecipeIngredientId == ri.Id).First(ui => ui.UserId == UserOptions.Id).SubstituteIngredient,
                ri.Optional,
            })
            .Select(ri => new
            {
                ri.Id,
                ri.Optional,
                Ingredient = new IngredientUserIngredient() { Scale = 1, Ingredient = ri.Ingredient },
                HasAlternatives = ri.Ingredient.Alternatives.Any(i => (i.AlternativeIngredient.Allergens & UserOptions.Allergens) == 0),
                SubIngredient = ri.SubstituteIngredient == null ? null : new IngredientUserIngredient()
                {
                    Measure = ri.Measure,
                    Ingredient = ri.SubstituteIngredient,
                    QuantityNumerator = ri.QuantityNumerator,
                    QuantityDenominator = ri.QuantityDenominator,
                },
            })
            .ToListAsync()).ToDictionary(ri => ri.Id, ri =>
            {
                // If the substitute ingredient doesn't conflict with allergens. Disabled: Now shows warning; user can always swap.
                if (ri.SubIngredient != null /*&& !ri.SubIngredient.Ingredient.Allergens.HasAnyFlag(UserOptions.Allergens)*/)
                {
                    return ri.SubIngredient;
                }

                // If there are alternatives available or the ingredient is ignorable,
                // ... return the base ingredient so the user can pick another one.
                return (ri.HasAlternatives || ri.Optional) ? ri.Ingredient : null;
            });
    }

    /// <summary>
    /// Reference updates to QueryResult.UserRecipe and QueryResult.UserIngredient to set them to default and save to db if they are null.
    /// </summary>
    private async Task AddMissingUserRecords(CoreContext context, IList<InProgressQueryResults> queryResults)
    {
        // User is not viewing a newsletter, don't log.
        if (UserOptions.NoUser) { return; }

        var recipesCreated = new HashSet<UserRecipe>();
        // Add user recipes for the main recipe query results.
        foreach (var queryResult in queryResults.Where(qr => qr.UserRecipe == null))
        {
            queryResult.UserRecipe = new UserRecipe()
            {
                UserId = UserOptions.Id,
                RecipeId = queryResult.Recipe.Id
            };

            if (recipesCreated.Add(queryResult.UserRecipe))
            {
                context.UserRecipes.Add(queryResult.UserRecipe);
            }
        }

        var userRecipeIngredientsCreated = new HashSet<UserRecipeIngredient>();
        foreach (var recipeIngredient in queryResults.SelectMany(qr => qr.RecipeIngredients))
        {
            // Add user recipe ingredients for all recipe ingredients.
            if (recipeIngredient.UserRecipeIngredient == null)
            {
                recipeIngredient.UserRecipeIngredient = new UserRecipeIngredient()
                {
                    UserId = UserOptions.Id,
                    RecipeIngredientId = recipeIngredient.Id,
                };

                if (userRecipeIngredientsCreated.Add(recipeIngredient.UserRecipeIngredient))
                {
                    context.UserRecipeIngredients.Add(recipeIngredient.UserRecipeIngredient);
                }
            }

            // Add user recipes for the prep recipes.
            if (recipeIngredient.UserRecipe == null && recipeIngredient.RawIngredientRecipeId.HasValue)
            {
                recipeIngredient.UserRecipe = new UserRecipe()
                {
                    UserId = UserOptions.Id,
                    RecipeId = recipeIngredient.IngredientRecipeId!.Value
                };

                if (recipesCreated.Add(recipeIngredient.UserRecipe))
                {
                    context.UserRecipes.Add(recipeIngredient.UserRecipe);
                }
            }
        }

        await context.SaveChangesAsync();
    }

    private List<Nutrients>? GetUnworkedNutrients(ICollection<QueryResults> finalResults, Dictionary<int, List<Nutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients, Dictionary<int, Ingredient> cookedIngredients)
    {
        if (NutrientOptions.NutrientTargetsRDA == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults, nutrients, partialIngredients, cookedIngredients);
        // Not using Nutrients because NutrientTargets can contain unions.
        return NutrientOptions.NutrientTargetsRDA.Where(kv =>
        {
            // We are targeting this nutrient.
            return !NutrientOptions.Nutrients.Any(mg => kv.Key.HasFlag(mg))
                // We have not overconsumed this nutrient.
                || !allNutrientsWorked.TryGetValue(kv.Key, out double workedAmount) || workedAmount < kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrients>? GetOverworkedNutrients(ICollection<QueryResults> finalResults, Dictionary<int, List<Nutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients, Dictionary<int, Ingredient> cookedIngredients)
    {
        if (NutrientOptions.NutrientTargetsTUL == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults, nutrients, partialIngredients, cookedIngredients);
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
    private static Dictionary<Nutrients, double> WorkedAmountOfNutrient(ICollection<QueryResults> list, Dictionary<int, List<Nutrient>> nutrients, Dictionary<int, List<IngredientScale>> partialIngredients, Dictionary<int, Ingredient> cookedIngredients)
    {
        return list.SelectMany(ufr => ufr.RecipeIngredients
            .Where(ufri => ufri.Type == RecipeIngredientType.Ingredient)
            .SelectMany(ufri => ufri.GetNutrients(nutrients, partialIngredients.GetValueOrDefault(ufri.GetIngredient!.Id), cookedIngredients))
        ).GroupBy(a => a.Key).ToDictionary(a => a.Key, a => a.Sum(b => b.Value));
    }
}
