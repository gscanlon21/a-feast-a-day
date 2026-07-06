using Core.Models;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.Users;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Data.Query.Builders;
using Data.Query.Filters;
using Data.Query.Options;
using Data.Query.Options.Users;
using Fractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Query.Runners;

/// <summary>
/// Builds and runs an EF Core query for selecting recipes.
/// </summary>
public class UserQueryRunner : BaseQueryRunner
{
    public UserQueryRunner(Section section) : base(section) { }

    [DebuggerDisplay("{Ingredient}: {Scale}")]
    private class IngredientUserIngredient
    {
        public double Scale { get; init; } = 1;
        public Measure? Measure { get; init; }
        public int? QuantityNumerator { get; init; }
        public int? QuantityDenominator { get; init; }
        public required Ingredient Ingredient { get; init; } = null!;
    }

    public required UserOptions UserOptions { private get; init; }

    public required BaseQueryFilter QueryFilter { protected get; init; }

    protected override IQueryable<Recipe> CreateRecipesQuery(CoreContext context)
    {
        return base.CreateRecipesQuery(context)
            // Make sure the user owns or is able to see the recipes.
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            // Don't grab recipes that have too many non-optional ingredients.
            .Where(r => UserOptions.MaxIngredients == null || r.RecipeIngredients.Count(i => !i.Ingredient.SkipShoppingList) <= UserOptions.MaxIngredients);
    }

    protected override IQueryable<RecipesQueryResults> Map(IQueryable<Recipe> recipes)
    {
        var query = recipes.Select(r => new RecipesQueryResults()
        {
            Recipe = r,
            UserRecipe = r.UserRecipes.First(ur => ur.UserId == UserOptions.Id),
            // Pull these out of the constructor so that EF Core can optimize the query.
            RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientQueryResults()
            {
                Id = ri.Id,
                Order = ri.Order,
                Group = ri.Group,
                Measure = ri.Measure,
                Optional = ri.Optional,
                CoarseCut = ri.CoarseCut,
                Adjustable = ri.Adjustable,
                Attributes = ri.Attributes,
                CookedScale = ri.CookedScale,
                QuantityNumerator = ri.QuantityNumerator,
                QuantityDenominator = ri.QuantityDenominator,
                RawIngredientRecipeId = ri.IngredientRecipeId,
                UserRecipeIngredient = ri.UserRecipeIngredients.First(ui => ui.UserId == UserOptions.Id && ui.RecipeIngredientId == ri.Id),
                Ingredient = ri.Ingredient == null ? null : new Ingredient(/* No constructor so EF Core can optimize the query */)
                {
                    Id = ri.Ingredient.Id,
                    Name = ri.Ingredient.Name,
                    Group = ri.Ingredient.Group,
                    Section = ri.Ingredient.Section,
                    Category = ri.Ingredient.Category,
                    FoodName = ri.Ingredient.FoodName,
                    Allergens = ri.Ingredient.Allergens,
                    DefaultMeasure = ri.Ingredient.DefaultMeasure,
                    GramsPerMeasure = ri.Ingredient.GramsPerMeasure,
                    GramsPerServing = ri.Ingredient.GramsPerServing,
                    GramsPerFineCup = ri.Ingredient.GramsPerFineCup,
                    GramsPerCoarseCup = ri.Ingredient.GramsPerCoarseCup,
                    SkipShoppingList = ri.Ingredient.SkipShoppingList,
                },
            }).ToList(),
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
    public override async Task<List<QueryResults>> Query(IServiceScopeFactory factory, int take = int.MaxValue)
    {
        // Short-circut when this is set without any data. No results are returned.
        if (RecipeOptions.RecipeIds?.Any() == false)
        {
            return [];
        }

        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var queryResults = await QueryPartial(context);

        // Do this before querying for prep recipes.
        await AddMissingUserRecords(context, queryResults);

        // Swap in user ingredients before querying for prep recipes.
        var prepRecipes = await GetPrepRecipes(factory, queryResults);
        var recipeIngredientAlt = await GetAltIngredientForRecipeIngredients(context, queryResults);

        // When you perform comparisons with nullable types, if the value of one of the nullable types
        // ... is null and the other is not, all comparisons evaluate to false except for != (not equal).
        var filteredResults = new List<QueryResults>();
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
                    if (recipeIngredient.ShouldSubstituteIngredient(UserOptions.Allergens))
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
                // Order the recipe ingredients based on user preferences. Always order recipes before ingredients w/ groups last.
                var orderedIngredients = finalRecipeIngredients.OrderBy(ri => ri.Group != null).ThenByDescending(ri => ri.Type);
                queryResult.RecipeIngredients = ((queryResult.Recipe.KeepIngredientOrder, UserOptions.IngredientOrder) switch
                {
                    (false, IngredientOrder.OptionalLast) => orderedIngredients.ThenBy(ri => ri.Optional).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                    (false, IngredientOrder.LargeToSmall) => orderedIngredients.ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Measure.ToGramsOrMilliliters()).ThenByDescending(ri => ri.Quantity).ThenByDescending(ri => ri.Weight),
                    _ => orderedIngredients.ThenBy(ri => ri.Order),
                }).ToList();

                filteredResults.Add(new QueryResults(_section, queryResult.Recipe, queryResult.RecipeIngredients, queryResult.UserRecipe)
                {
                    // Scaling the recipe will also scale the recipe ingredient quantities which then affects ingredient recipe scales.
                    SetScale = (RecipeOptions.RecipeIds?.TryGetValue(queryResult.Recipe.Id, out int? scale) == true && scale.HasValue) ? scale.Value
                        : (queryResult.UserRecipe != null && queryResult.Recipe.AdjustableServings) ? queryResult.UserRecipe.Servings / (double)queryResult.Recipe.Servings : 1,
                });
            }
        }

        // Order after the query or you get cartesian explosion.
        if (SelectionOptions.Randomized)
        {
            // Randomize the order. Useful for the backfill because
            // ... those feasts don't update the last seen date.
            filteredResults.ShuffleInPlace();
        }
        else if (_section != Section.Prep && _section != Section.None)
        {
            // Don't need to order if we are in a prep or none section. Order by recipes that are still pending refresh.
            filteredResults = filteredResults.OrderByDescending(a => a.UserRecipe?.RefreshAfter.HasValue, NullOrder.NullsLast)
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

        return await QueryFilter.Filter(filteredResults, factory, take);
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
        return prepRecipeIds.Any() ? await new UserOptionsQueryBuilder<RecipeQueryFilter>(UserOptions, Section.Prep)
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
        // Only need to look for substitutions where an ingredient's allergens conflict with the user's allergens or where the user is substituting in an alternative ingredient.
        var recipeIngredients = queryResults.SelectMany(qr => qr.RecipeIngredients.Where(ri => ri.ShouldSubstituteIngredient(UserOptions.Allergens))).ToList();
        if (recipeIngredients == null || recipeIngredients.Count == 0)
        {
            return ReadOnlyDictionary<int, IngredientUserIngredient?>.Empty;
        }

        var substituteIngredients = await GetSubstituteIngredientForRecipeIngredients(context, recipeIngredients);
        var doesIngredientHaveAlternatives = await DoesIngredientHaveAlternatives(context, recipeIngredients);
        return recipeIngredients.ToDictionary(ri => ri.Id, ri =>
        {
            // Don't check for allergens when substituting: only show a warning when the user swaps in a substitute ingredient that conflicts with their allergens; user should always see their swapped ingredient.
            if (ri.UserRecipeIngredient?.SubstituteIngredientId.HasValue == true && substituteIngredients.TryGetValue(ri.UserRecipeIngredient.SubstituteIngredientId.Value, out var subIngredient) && subIngredient != null)
            {
                return new IngredientUserIngredient()
                {
                    Ingredient = subIngredient,
                    Measure = ri.UserRecipeIngredient.Measure,
                    QuantityNumerator = ri.UserRecipeIngredient.QuantityNumerator,
                    QuantityDenominator = ri.UserRecipeIngredient.QuantityDenominator,
                };
            }

            doesIngredientHaveAlternatives.TryGetValue(ri.GetIngredient!.Id, out var hasAlternative);
            // If there are alternatives available or the ingredient is ignorable, return the ingredient so the user can swap.
            return (hasAlternative || ri.Optional) ? new IngredientUserIngredient() { Ingredient = ri.GetIngredient! } : null;
        });
    }

    /// <summary>
    /// Get the alternative ingredients for all of the ingredients, ignoring ignored alternative ingredients.
    /// Includes the base recipe ingredient's ingredient if it has substitutions available or if it is ignorable.
    /// </summary>
    private static async Task<IDictionary<int, Ingredient>> GetSubstituteIngredientForRecipeIngredients(CoreContext context, IList<RecipeIngredientQueryResults> queryResults)
    {
        // Only need to look for substitutions where an ingredient's allergens conflict with the user's allergens or where the user is substituting in an alternative ingredient.
        var substituteIngredientIds = queryResults.Select(ri => ri.UserRecipeIngredient?.SubstituteIngredientId).RemoveNullEntries().ToList();
        if (substituteIngredientIds.Count == 0)
        {
            return ReadOnlyDictionary<int, Ingredient>.Empty;
        }

        // Don't check for disabled recipe/recipeingredients b/c no queryresults are disabled.
        return await context.Ingredients.TagWithCallSite().AsNoTracking().IgnoreQueryFilters()
            .Where(i => substituteIngredientIds.Contains(i.Id))
            .Select(i => new
            {
                i.Id,
                Ingredient = i,
            }).ToDictionaryAsync(i => i.Id, i => i.Ingredient);
    }

    /// <summary>
    /// Get the alternative ingredients for all of the ingredients, ignoring ignored alternative ingredients.
    /// Includes the base recipe ingredient's ingredient if it has substitutions available or if it is ignorable.
    /// </summary>
    private async Task<IDictionary<int, bool>> DoesIngredientHaveAlternatives(CoreContext context, IList<RecipeIngredientQueryResults> queryResults)
    {
        if (UserOptions.Allergens == Allergens.None)
        {
            return ReadOnlyDictionary<int, bool>.Empty;
        }

        // Only need to look for substitutions where an ingredient's allergens conflict with the user's allergens or where the user is substituting in an alternative ingredient.
        var allergenIngredientIds = queryResults.Where(ri => !ri.HasSubstituteIngredient).Where(ri => ri.ConflictsWithAllergens(UserOptions.Allergens)).Select(ri => ri.Ingredient?.Id).RemoveNullEntries().ToList();
        if (allergenIngredientIds.Count == 0)
        {
            return ReadOnlyDictionary<int, bool>.Empty;
        }

        // Don't check for disabled recipe/recipeingredients b/c no queryresults are disabled.
        return await context.Ingredients.TagWithCallSite().AsNoTracking().IgnoreQueryFilters()
            .Where(i => allergenIngredientIds.Contains(i.Id))
            .Select(i => new
            {
                i.Id,
                // Keep this in the Select projection for data accessibility.
                HasAlternatives = (i.Allergens & UserOptions.Allergens) == 0 || i.Alternatives.Any(a => (a.AlternativeIngredient.Allergens & UserOptions.Allergens) == 0),
            }).ToDictionaryAsync(i => i.Id, i => i.HasAlternatives);
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
        // User recipes for prep recipes get added when querying for the subsection.
        foreach (var queryResult in queryResults.Where(qr => qr.UserRecipe == null))
        {
            queryResult.UserRecipe = new UserRecipe()
            {
                UserId = UserOptions.Id,
                RecipeId = queryResult.Recipe.Id,
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
        }

        await context.SaveChangesAsync();
    }
}
