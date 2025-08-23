using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Query.Builders;
using Data.Query.Options;
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
    public required NutrientOptions NutrientOptions { get; init; }
    public required EquipmentOptions EquipmentOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required SelectionOptions SelectionOptions { get; init; }

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
                    Attributes = ri.Attributes,
                    Ingredient = ri.Ingredient,
                    QuantityNumerator = ri.QuantityNumerator,
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
    public async Task<IList<QueryResults>> Query(IServiceScopeFactory factory, OrderBy orderBy = OrderBy.None, int take = int.MaxValue)
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
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients.Aggregate(Nutrients.None, (c, n) => c | n), include: true);

        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

        // When you perform comparisons with nullable types, if the value of one of the nullable types
        // ... is null and the other is not, all comparisons evaluate to false except for != (not equal).
        var filteredResults = new List<InProgressQueryResults>();
        if (UserOptions.NoUser)
        {
            // Add in the prerequisite recipe ingredients.
            var prerequisiteRecipes = await GetPrerequisiteRecipes(factory, queryResults);
            foreach (var queryResult in queryResults)
            {
                foreach (var recipeIngredient in queryResult.RecipeIngredients)
                {
                    if (recipeIngredient.Type == RecipeIngredientType.IngredientRecipe)
                    {
                        // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                        recipeIngredient.IngredientRecipe = prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.IngredientRecipeId)
                            // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                            ?? prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.RawIngredientRecipeId);
                    }
                }
            }

            filteredResults = queryResults;
        }
        else
        {
            // Do this before querying prerequisites.
            await AddMissingUserRecords(context, queryResults);

            // Swap in user ingredients before querying for prerequisite recipes.
            var prerequisiteRecipes = await GetPrerequisiteRecipes(factory, queryResults);
            var recipeIngredientAlt = await GetAltIngredientForRecipeIngredients(context, queryResults);
            foreach (var queryResult in queryResults)
            {
                var ignoreRecipe = false;
                var finalRecipeIngredients = new List<RecipeIngredientQueryResults>();

                // Swap or filter out optional ingredients that have allergens or are ignored
                // ... and filter out recipes containing non-optional ingredients that have allergens or are ignored.
                // Allow recipes with ingredients that the user has ignored and are no longer optional so the user can still manage it.
                foreach (var recipeIngredient in queryResult.RecipeIngredients.Where(ri => ri.UserRecipeIngredient?.Ignore != true))
                {
                    // Check this first so we can fallback to an ingredient if the recipe fails.
                    if (recipeIngredient.Type == RecipeIngredientType.IngredientRecipe)
                    {
                        // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                        recipeIngredient.IngredientRecipe = prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.IngredientRecipeId)
                            // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                            ?? prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.RawIngredientRecipeId);

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

                    if (recipeIngredient.Type == RecipeIngredientType.Ingredient)
                    {
                        // Don't swap if the user is substituting in a different ingredient.
                        if (recipeIngredient.UserRecipeIngredient?.SubstituteIngredientId.HasValue == true
                            // Or if any of the ingredient's allergens conflict with the user's allergens.
                            || recipeIngredient.Ingredient!.Allergens.HasAnyFlag(UserOptions.Allergens))
                        {
                            // Substitution and alternative ingredients don't have user ingredient records.
                            var substitution = recipeIngredientAlt.TryGetValue(recipeIngredient.Id, out var alt) ? alt : null;
                            recipeIngredient.Ingredient = substitution?.Ingredient;
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

                        // Filter out optional ingredients that the user ignored or has allergens for.
                        if (recipeIngredient.Ingredient != null)
                        {
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

        // OrderBy must come after the query or you get cartesian explosion.
        List<InProgressQueryResults> orderedResults;
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

        // Set nutrients on the recipe after all the ingredient swapping has taken place.
        var allNutrients = await GetNutrients(context, filteredResults);
        // OrderBy must come after the query or you get cartesian explosion.
        var recipeResults = new List<QueryResults>();
        foreach (var recipe in orderedResults)
        {
            // Set nutrients on the recipe after all the ingredient swapping has taken place.
            recipe.Nutrients = allNutrients.Where(n => recipe.RecipeIngredients.Select(ri => ri.Ingredient?.Id).Contains(n.IngredientId)).ToList();

            // Order the recipe ingredients based on user preferences. Always order recipes before ingredients.
            recipe.RecipeIngredients = ((recipe.Recipe.KeepIngredientOrder, UserOptions.IngredientOrder) switch
            {
                (false, IngredientOrder.OptionalLast) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Optional).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                (false, IngredientOrder.LargeToSmall) => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                _ => recipe.RecipeIngredients.OrderByDescending(ri => ri.Type).ThenBy(ri => ri.Order),
            }).ToList();

            recipeResults.Add(new QueryResults(section, recipe.Recipe, recipe.Nutrients, recipe.RecipeIngredients, recipe.UserRecipe)
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
                // Don't overwork nutrients. Include the recipe and the recipe's prerequisites in this calculation.
                // Don't select all nutrients for prior results since those will include the prerequisite recipes already.
                var overworkedNutrients = GetOverworkedNutrients([recipe, .. finalResults, .. recipe.PrerequisiteRecipes.Select(pr => pr.Key)]);
                if (overworkedNutrients != null && recipe.AllNutrients.Where(n => n.Value > 0).Any(n => overworkedNutrients.Contains(n.Nutrients)))
                {
                    continue;
                }

                // Choose recipes that cover at least X nutrients in the targeted nutrient set.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue)
                {
                    var unworkedNutrients = GetUnworkedNutrients(finalResults);
                    if (unworkedNutrients != null)
                    {
                        // We've already worked all unique nutrients.
                        if (unworkedNutrients.Count == 0)
                        {
                            break;
                        }

                        // Find the number of weeks of padding that this recipe still has left. If the padded refresh date is earlier than today, then use the number 0.
                        var weeksTillLastSeen = Math.Max(0, (recipe.UserRecipe?.LastSeen?.DayNumber ?? DateHelpers.Today.DayNumber) - DateHelpers.Today.DayNumber) / 7;
                        // The recipe does not work enough unique nutrients that we are trying to target.
                        // Allow recipes that have a refresh date since we want to show those continuously until that date.
                        // Allow the first recipe with any nutrient so the user does not get stuck from seeing certain recipes
                        // ... if, for example, a prerequisite only works one nutrient and that nutrient is otherwise worked by other recipes.
                        var nutrientsToWork = (recipe.UserRecipe?.RefreshAfter != null || !finalResults.Any(e => e.UserRecipe?.RefreshAfter == null)) ? 1
                            // Choose two recipes with no refresh padding and few nutrients worked over a recipe with lots of refresh padding and many nutrients worked.
                            // Doing weeks out so we still prefer recipes with many nutrients worked to an extent.
                            : (NutrientOptions.AtLeastXNutrientsPerRecipe.Value + weeksTillLastSeen);

                        // Include the prerequisite recipes in this calculation.
                        if (recipe.AllNutrients.Count(n => n.Value > 0) < Math.Max(1, nutrientsToWork))
                        {
                            continue;
                        }
                    }
                }

                // Not including the prep recipes in the take count because those aren't a part of the section.
                if (!finalResults.Contains(recipe) && finalResults.Count(fr => fr.Section == section) < take)
                {
                    // Prepend the recipe's prerequisite recipes if there are any.
                    foreach (var prerequisiteRecipe in recipe.PrerequisiteRecipes)
                    {
                        // Reduce the scale of the prerequisite recipe when the prerequisite's serving size is greater than 1.
                        prerequisiteRecipe.Key.SetScale = prerequisiteRecipe.Value / prerequisiteRecipe.Key.Recipe.Measure.ToGramsOrMilliliters(prerequisiteRecipe.Key.Recipe.Servings);

                        // Prerequisite recipe already exists and is scalable, scale it.
                        if (finalResults.TryGetValue(prerequisiteRecipe.Key, out var existingIngredientRecipe) && existingIngredientRecipe.Recipe.AdjustableServings)
                        {
                            existingIngredientRecipe.SetScale += prerequisiteRecipe.Key.SetScale;
                        }
                        // If the prerequisite recipes already exists in our feast, then scale it.
                        else if (SelectionOptions.PrepRecipes.TryGetValue(prerequisiteRecipe.Key, out var prepRecipe) && prepRecipe.Recipe.AdjustableServings)
                        {
                            prepRecipe.SetScale += prerequisiteRecipe.Key.SetScale;
                        }
                        else if (!RecipeOptions.IgnorePrerequisites)
                        {
                            finalResults.Add(prerequisiteRecipe.Key);
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
    private static async Task<List<Nutrient>> GetNutrients(CoreContext context, IList<InProgressQueryResults> filteredResults)
    {
        var allFilteredResultIngredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
        return await context.Nutrients.Where(n => allFilteredResultIngredientIds.Contains(n.IngredientId)).ToListAsync();
    }

    /// <summary>
    /// Returns the recipes that are using in this recipe.
    /// </summary>
    private async Task<IList<QueryResults>> GetPrerequisiteRecipes(IServiceScopeFactory factory, IList<InProgressQueryResults> filteredResults)
    {
        var prerequisiteRecipeIds = filteredResults.SelectMany(ar => ar.RecipeIngredients
            // Query for prerequisites ingredient recipes here so we can check their ignored status before finalizing recipes.
            .Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe)).Where(ri => ri.UserRecipeIngredient?.Ignore != true)
            // Search for both the substituted recipe ingredient and the raw recipe ingredient, so we can fallback if one conflicts with allergens.
            .SelectMany(ri => new List<int?>(2) { ri.IngredientRecipeId, ri.RawIngredientRecipeId }).Where(rid => rid.HasValue).Distinct()
            // Don't scale prerequisite recipes yet since the prerequisite recipe scale is based on the quantity of the ingredient recipe.    
            .GroupBy(ri => ri!.Value).ToDictionary(g => g.Key, ri => (int?)1/*(int)Math.Ceiling(ri.Quantity.ToDouble())*/);

        // This will filter out ignored prerequisite recipes. No infinite recursion please. 
        return prerequisiteRecipeIds.Any() ? await new QueryBuilder(Section.Prep)
            .WithUser(UserOptions)
            .WithEquipment(EquipmentOptions.Equipment)
            .WithRecipes(options => options.AddRecipes(prerequisiteRecipeIds))
            .Build().Query(factory) : [];
    }

    /// <summary>
    /// Get the alternative ingredients for all of the ingredients, ignoring ignored alternative ingredients.
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
            })
            .Select(ri => new
            {
                ri.Id,
                SubIngredient = ri.SubstituteIngredient == null ? null : new IngredientUserIngredient()
                {
                    Measure = ri.Measure,
                    Ingredient = ri.SubstituteIngredient,
                    QuantityNumerator = ri.QuantityNumerator,
                    QuantityDenominator = ri.QuantityDenominator,
                },
                AltsIngredient = ri.Ingredient.Alternatives.Select(ia => new IngredientUserIngredient()
                {
                    Scale = ia.Scale,
                    Ingredient = ia.AlternativeIngredient,
                    // Should be no overlap between ingredient allergens and user allergens.
                }).FirstOrDefault(i => (i.Ingredient.Allergens & UserOptions.Allergens) == 0)
            }).ToListAsync()).ToDictionary(ri => ri.Id, ri =>
            {
                if (ri.SubIngredient == null) { return ri.AltsIngredient; }
                // Prefer a substitute ingredient over a random alternative ingredient.
                return (!ri.SubIngredient.Ingredient.Allergens.HasAnyFlag(UserOptions.Allergens)) ? ri.SubIngredient : ri.AltsIngredient;
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

    private List<Nutrients>? GetUnworkedNutrients(ICollection<QueryResults> finalResults)
    {
        if (NutrientOptions.NutrientTargetsRDA == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults);
        // Not using Nutrients because NutrientTargets can contain unions.
        return NutrientOptions.NutrientTargetsRDA.Where(kv =>
        {
            // We are targeting this nutrient.
            return !NutrientOptions.Nutrients.Any(mg => kv.Key.HasFlag(mg))
                // We have not overconsumed this nutrient.
                || !allNutrientsWorked.TryGetValue(kv.Key, out double workedAmount) || workedAmount < kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrients>? GetOverworkedNutrients(ICollection<QueryResults> finalResults)
    {
        if (NutrientOptions.NutrientTargetsTUL == null) { return null; }

        var allNutrientsWorked = WorkedAmountOfNutrient(finalResults);
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
    private static Dictionary<Nutrients, double> WorkedAmountOfNutrient(ICollection<QueryResults> list)
    {
        return list.SelectMany(ufr => ufr.RecipeIngredients
            .Where(ufri => ufri.Type == RecipeIngredientType.Ingredient)
            .SelectMany(ufri => ufri.GetNutrients(ufr.Nutrients))
        ).GroupBy(a => a.Key).ToDictionary(a => a.Key, a => a.Sum(b => b.Value));
    }
}
