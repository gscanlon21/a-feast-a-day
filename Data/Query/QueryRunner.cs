﻿using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Code.Extensions;
using Data.Entities.Ingredient;
using Data.Entities.Recipe;
using Data.Entities.User;
using Data.Models;
using Data.Query.Builders;
using Data.Query.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Data.Query;

/// <summary>
/// Builds and runs an EF Core query for selecting exercises.
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

    [DebuggerDisplay("{Ingredient}: {UserIngredient}")]
    private class IngredientUserIngredient
    {
        public Ingredient Ingredient { get; init; } = null!;
        public UserIngredient? UserIngredient { get; init; }
    }

    public required UserOptions UserOptions { get; init; }
    public required ServingsOptions ServingsOptions { get; init; }
    public required ExclusionOptions ExclusionOptions { get; init; }
    public required RecipeOptions RecipeOptions { get; init; }
    public required NutrientOptions NutrientOptions { get; init; }
    public required EquipmentOptions EquipmentOptions { get; init; }

    private IQueryable<RecipesQueryResults> CreateFilteredRecipesQuery(CoreContext context)
    {
        return context.Recipes.IgnoreQueryFilters().TagWith(nameof(CreateFilteredRecipesQuery))
            .Include(r => r.Instructions)
            .Include(r => r.RecipeIngredients.Where(ri => ri.IngredientId.HasValue))
                .ThenInclude(ri => ri.Ingredient)
                    .ThenInclude(i => i.UserIngredients.Where(ui => ui.UserId == UserOptions.Id))
            .Where(ev => ev.DisabledReason == null)
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            // Don't grab recipes over our max ingredient count.
            .Where(r => UserOptions.MaxIngredients == null || r.RecipeIngredients.Count(i => !i.Ingredient.SkipShoppingList) <= UserOptions.MaxIngredients)
            // Don't grab recipes that we want to ignore.
            .Where(vm => !ExclusionOptions.RecipeIds.Contains(vm.Id))
            .Select(r => new RecipesQueryResults()
            {
                Recipe = r,
                UserRecipe = r.UserRecipes.First(ue => ue.UserId == UserOptions.Id),
                RecipeIngredients = r.RecipeIngredients.Select(ri => new RecipeIngredientQueryResults(ri)
                {
                    Optional = ri.Optional,
                    UserIngredient = ri.Ingredient.UserIngredients.First(ei => ei.UserId == UserOptions.Id),
                    UserIngredientRecipe = ri.IngredientRecipe.UserRecipes.First(ei => ei.UserId == UserOptions.Id),
                }).ToList()
            })
            // Don't grab recipes that the user wants to ignore.
            .Where(vm => UserOptions.IgnoreIgnored || vm.UserRecipe.Ignore != true);
        // Don't filter out ignored or allergen provoking ingredients here because we want to try to swap substitutes in first.
        // ... The user should ignore the recipe if they don't want a recipe with a specific ingredient that has alternatives.
        //-Don't grab recipes that use ingredients that the user wants to ignore.
        //-Where(vm => UserOptions.IgnoreIgnored || vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredient!.Ignore != true))
        //-Don't grab recipes that use ingredient recipes that the user wants to ignore.
        //-Where(vm => UserOptions.IgnoreIgnored || vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredientRecipe!.Ignore != true));
    }

    /// <summary>
    /// Queries the db for the data.
    /// </summary>
    public async Task<IList<QueryResults>> Query(IServiceScopeFactory factory, int take = int.MaxValue)
    {
        using var scope = factory.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        var filteredQuery = CreateFilteredRecipesQuery(context);

        filteredQuery = Filters.FilterSection(filteredQuery, section);
        filteredQuery = Filters.FilterEquipment(filteredQuery, EquipmentOptions.Equipment);
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds?.Select(r => r.Key).ToList());
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients.Aggregate(Nutrients.None, (curr2, n2) => curr2 | n2), include: true);

        var queryResults = (await filteredQuery.Select(a => new InProgressQueryResults(a)).AsNoTracking().TagWithCallSite().ToListAsync()).ToList();

        var filteredResults = new List<InProgressQueryResults>();
        if (UserOptions.NoUser)
        {
            filteredResults = queryResults;
        }
        else
        {
            // Do this before querying alternatives so that the user records also exist for the alternatives.
            await AddMissingUserRecords(context, queryResults);

            // Swap in user ingredients before querying for prerequisite recipes.
            var prerequisiteRecipes = await GetPrerequisiteRecipes(factory, queryResults);
            var ingredientAlternatives = await GetAlternativeIngredientsForIngredients(context, queryResults);
            foreach (var queryResult in queryResults)
            {
                var ignoreRecipe = false;
                var finalRecipeIngredients = new List<RecipeIngredientQueryResults>();

                // Swap or filter out optional ingredients that have allergens or are ignored
                // ... and filter out recipes containing non-optional ingredients that have allergens or are ignored.
                foreach (var recipeIngredient in queryResult.RecipeIngredients)
                {
                    // Check this first so we can fallback to an ingredient if the recipe fails.
                    if (recipeIngredient.Type == RecipeIngredientType.IngredientRecipe)
                    {
                        // Set the prerequisite recipe. PrerequisiteRecipes has ignored recipe/ingredients and allergic ingredients filtered out already.
                        recipeIngredient.IngredientRecipe = prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.IngredientRecipeId!.Value)
                            // Fallback to the base recipe's ingredient recipe if it exists. In case the substitution conflicts with allergens.
                            ?? prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.RawIngredientRecipeId!.Value);

                        // Ignore the recipe if the recipe ingredient recipe is missing or ignored and the recipe ingredient is non-optional.
                        if (recipeIngredient.IngredientRecipe != null)
                        {
                            finalRecipeIngredients.Add(recipeIngredient);
                            continue;
                        }
                        // If the recipe ingredient was a substitute for a regular ingredient, fallback to that ingredient.
                        else if (recipeIngredient.UserIngredient?.SubstituteRecipeId.HasValue == true
                            // Make sure we fallback to an ingredient and not another recipe.
                            && !recipeIngredient.RawIngredientRecipeId.HasValue)
                        {
                            recipeIngredient.UserIngredient.SubstituteRecipeId = null;
                        }
                    }

                    if (recipeIngredient.Type == RecipeIngredientType.Ingredient)
                    {
                        // Swap the ingredient if the user ignored it.
                        if (recipeIngredient.UserIngredient?.Ignore == true
                            // Or if the user is substituting in a different ingredient.
                            || recipeIngredient.UserIngredient?.SubstituteIngredientId.HasValue == true
                            // Or if the ingredient conflicts with the user's allergens.
                            || recipeIngredient.Ingredient!.Allergens.HasAnyFlag32(UserOptions.Allergens))
                        {
                            var substitution = ingredientAlternatives.TryGetValue(recipeIngredient.Ingredient!.Id, out var subs) ? subs.FirstOrDefault() : null;
                            recipeIngredient.UserIngredient = substitution?.UserIngredient;
                            recipeIngredient.Ingredient = substitution?.Ingredient;
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

        // Set nutrients on the recipe after all the ingredient swapping has taken place.
        var allNutrients = await GetNutrients(context, filteredResults);
        // OrderBy must come after the query or you get cartesian explosion.
        var orderedResults = new List<QueryResults>();
        foreach (var recipe in filteredResults
            // Order by recipes that are still pending refresh.
            .OrderByDescending(a => a.UserRecipe?.RefreshAfter.HasValue)
            // Show recipes that the user has rarely seen.
            // NOTE: When the two recipe's LastSeen dates are the same:
            // ... The LagRefreshXWeeks will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating recipes for the LagRefreshXWeeks duration.
            .ThenBy(a => a.UserRecipe?.LastSeen.DayNumber)
            // Mostly for the demo, show mostly random exercises.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read.
            .ToList())
        {
            // Set nutrients on the recipe after all the ingredient swapping has taken place.
            recipe.Nutrients = allNutrients.Where(n => recipe.RecipeIngredients.Select(ri => ri.Ingredient?.Id).Contains(n.IngredientId)).ToList();

            // Order the recipe ingredients based on user preferences.
            var recipeIngredients = UserOptions.IngredientOrder switch
            {
                IngredientOrder.LargeToSmall => recipe.RecipeIngredients.OrderBy(ri => ri.Type).ThenBy(ri => ri.Measure != Measure.None).ThenByDescending(ri => ri.Size).ToList(),
                IngredientOrder.OrderUsed or _ => recipe.RecipeIngredients.OrderBy(ri => ri.Type).ThenBy(ri => ri.Order).ToList(),
            };

            orderedResults.Add(new QueryResults(section, recipe.Recipe, recipe.Nutrients, recipeIngredients, recipe.UserRecipe)
            {
                SetScale = RecipeOptions.RecipeIds?.TryGetValue(recipe.Recipe.Id, out int scaleTemp) == true ? scaleTemp : 1,
            });
        }

        var finalResults = new HashSet<QueryResults>();
        do
        {
            foreach (var recipe in orderedResults)
            {
                var servingsSoFar = finalResults.Aggregate(0, (curr, next) => curr + next.Recipe.Servings);
                if (ServingsOptions.AtLeastXServingsPerRecipe.HasValue
                    // Don't choose recipes under our desired number of servings.
                    && recipe.Recipe.Servings < ServingsOptions.AtLeastXServingsPerRecipe.Value)
                {
                    // If the recipe and all prerequisite recipes are adjustable.
                    if (recipe.Recipe.AdjustableServings && recipe.RecipeIngredients.All(r => r.IngredientRecipe?.Recipe.AdjustableServings != false))
                    {
                        // Scaling the recipe will also scale the recipe ingredient quantities with then effects ingredient recipe scales.
                        recipe.SetScale = ServingsOptions.AtLeastXServingsPerRecipe.Value / (double)recipe.Recipe.Servings;
                    }
                    // The recipe does not work enough servings that we are trying to target.
                    // Allow recipes that have a refresh date since we want to show those continuously until that date.
                    // Allow the first recipe with any serving so the user does not get stuck from seeing certain recipes
                    // ... if, for example, a prerequisite only works one serving and that serving is otherwise worked by other recipes.
                    else if (recipe.UserRecipe?.RefreshAfter == null && finalResults.Any(r => r.UserRecipe?.RefreshAfter == null))
                    {
                        continue;
                    }
                }

                // Don't overwork nutrients. Include the recipe and the recipe's prerequisites in this calculation.
                // Don't select all nutrients for prior results since those will include the prerequisite recipes already.
                var overworkedNutrients = GetOverworkedNutrients([recipe, .. finalResults, .. recipe.PrerequisiteRecipes.Select(pr => pr.Key)]);
                if (recipe.AllNutrients.Where(n => n.Value > 0).Any(n => overworkedNutrients.Contains(n.Nutrients)))
                {
                    continue;
                }

                // Choose recipes that cover at least X nutrients in the targeted nutrient set.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue)
                {
                    var unworkedNutrients = GetUnworkedNutrients(finalResults);

                    // We've already worked all unique nutrients.
                    if (unworkedNutrients.Count == 0)
                    {
                        break;
                    }

                    // Find the number of weeks of padding that this recipe still has left. If the padded refresh date is earlier than today, then use the number 0.
                    var weeksTillLastSeen = Math.Max(0, (recipe.UserRecipe?.LastSeen.DayNumber ?? DateHelpers.Today.DayNumber) - DateHelpers.Today.DayNumber) / 7;
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

                if (!finalResults.Contains(recipe))
                {
                    // Prepend the recipe's prerequisite recipes.
                    foreach (var prerequisiteRecipe in recipe.PrerequisiteRecipes)
                    {
                        // Reduce the scale of the prerequisite recipe when the prerequisite's serving size is greater than 1.
                        prerequisiteRecipe.Key.SetScale = prerequisiteRecipe.Value / prerequisiteRecipe.Key.Recipe.Measure.ToGramsOrMilliliters(prerequisiteRecipe.Key.Recipe.Servings);

                        // Prerequisite recipe already exists and is scalable, scale it.
                        if (finalResults.TryGetValue(prerequisiteRecipe.Key, out var existingIngredientRecipe) && existingIngredientRecipe.Recipe.AdjustableServings)
                        {
                            // FIXME: Scale is stored as int and rounds up, so if two recipe ingredients from distinct recipes
                            // ... only use a fraction of the recipe, the scale will end up being more than doubled.
                            existingIngredientRecipe.SetScale += prerequisiteRecipe.Key.SetScale;
                        }
                        else
                        {
                            finalResults.Add(prerequisiteRecipe.Key);
                        }
                    }

                    finalResults.Add(recipe);
                }
            }
        }
        // Slowly allow out-of-preference recipes until we meet our servings/nutritional targets.
        while ((ServingsOptions.AtLeastXServingsPerRecipe.HasValue && --ServingsOptions.AtLeastXServingsPerRecipe >= 1)
            || (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue && --NutrientOptions.AtLeastXNutrientsPerRecipe >= 1)
        );

        // REFACTORME
        return section switch
        {
            // Not in a feast context, order by name.
            Section.None => [.. finalResults.Take(take).OrderBy(vm => vm.Recipe.Name)],
            // We are in a feast context, keep the result order.
            _ => finalResults.Take(take).ToList()
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
        // Query for prerequisites ingredient recipes here so we can check check their ignored status before finalizing recipes.
        var prerequisiteRecipeIds = filteredResults.SelectMany(ar => ar.RecipeIngredients.Where(ri => ri.Type == RecipeIngredientType.IngredientRecipe))
            // Search for both the substituted recipe ingredient and the raw recipe ingredient, so we can fallback if one conflicts with allergens.
            .SelectMany(ri => new List<int?>(2) { ri.IngredientRecipeId, ri.RawIngredientRecipeId }).Where(rid => rid.HasValue).Distinct()
            // Don't scale prerequisite recipes yet since the prerequisite recipe scale is based on the quantity of the ingredient recipe.    
            .GroupBy(ri => ri!.Value).ToDictionary(g => g.Key, ri => 1/*(int)Math.Ceiling(ri.Quantity.ToDouble())*/);

        // No infinite recursion please.
        if (!prerequisiteRecipeIds.Any() || RecipeOptions.IgnorePrerequisites)
        {
            return [];
        }

        // This will filter out ignored prerequisite recipes.
        return (await new QueryBuilder(Section.Prep)
            .WithUser(UserOptions)
            .WithEquipment(EquipmentOptions.Equipment)
            .WithRecipes(options => options.AddRecipes(prerequisiteRecipeIds))
            .Build()
            .Query(factory))
            .ToList();
    }

    /// <summary>
    /// Get the alternative ingredients for all of the ingredients, ignoring ignored alternative ingredients.
    /// </summary>
    private async Task<IDictionary<int, List<IngredientUserIngredient>>> GetAlternativeIngredientsForIngredients(CoreContext context, IList<InProgressQueryResults> queryResults)
    {
        bool noIgnoredOrAllergicIngredients(IngredientUserIngredient? ingredient)
        {
            // Don't select ignored alternative ingredients or alternative ingredients containing allergens.
            return ingredient != null && !ingredient.Ingredient.Allergens.HasAnyFlag32(UserOptions.Allergens) && ingredient.UserIngredient?.Ignore != true;
        }

        var allQueryResultIngredientIds = queryResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
        return (await context.Ingredients.Where(i => allQueryResultIngredientIds.Contains(i.Id)).Select(i => new
        {
            IngredientId = i.Id,
            i.UserIngredients.First(a => a.UserId == UserOptions.Id).SubstituteIngredient,
            AlternativeIngredients = i.Alternatives.Select(a => new IngredientUserIngredient()
            {
                Ingredient = a.AlternativeIngredient,
                UserIngredient = a.AlternativeIngredient.UserIngredients.First(ei => ei.UserId == UserOptions.Id)
            })
        }).Select(i => new
        {
            i.IngredientId,
            i.AlternativeIngredients,
            // If the user has a substitute ingredient, prepend that to the list of substitutions.
            SubstitureIngredient = i.SubstituteIngredient == null ? null : new IngredientUserIngredient()
            {
                Ingredient = i.SubstituteIngredient,
                UserIngredient = context.UserIngredients.First(ui => ui.IngredientId == i.SubstituteIngredient.Id && ui.UserId == UserOptions.Id)
            },
        }).ToListAsync()).ToDictionary(i => i.IngredientId, i => i.AlternativeIngredients.Prepend(i.SubstitureIngredient).Where(noIgnoredOrAllergicIngredients).Select(a => a!).ToList());
    }

    /// <summary>
    /// Reference updates to QueryResult.UserRecipe and QueryResult.UserIngredient to set them to default and save to db if they are null.
    /// </summary>
    private async Task AddMissingUserRecords(CoreContext context, IList<InProgressQueryResults> queryResults)
    {
        // User is not viewing a newsletter, don't log.
        if (section == Section.None) { return; }

        var recipesCreated = new HashSet<UserRecipe>();
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

        foreach (var ingredient in queryResults.SelectMany(qr => qr.RecipeIngredients)
            .Where(i => i.UserIngredientRecipe == null && i.RawIngredientRecipeId.HasValue))
        {
            ingredient.UserIngredientRecipe = new UserRecipe()
            {
                UserId = UserOptions.Id,
                RecipeId = ingredient.IngredientRecipeId!.Value
            };

            if (recipesCreated.Add(ingredient.UserIngredientRecipe))
            {
                context.UserRecipes.Add(ingredient.UserIngredientRecipe);
            }
        }

        var ingredientsCreated = new HashSet<UserIngredient>();
        foreach (var ingredient in queryResults.SelectMany(qr => qr.RecipeIngredients)
            .Where(i => i.UserIngredient == null && i.Ingredient != null))
        {
            ingredient.UserIngredient = new UserIngredient()
            {
                UserId = UserOptions.Id,
                IngredientId = ingredient.Ingredient!.Id,
                SubstituteIngredientId = ingredient.Ingredient!.Id,
            };

            if (ingredientsCreated.Add(ingredient.UserIngredient))
            {
                context.UserIngredients.Add(ingredient.UserIngredient);
            }
        }

        await context.SaveChangesAsync();
    }

    private List<Nutrients> GetUnworkedNutrients(ICollection<QueryResults> finalResults)
    {
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

    private List<Nutrients> GetOverworkedNutrients(ICollection<QueryResults> finalResults)
    {
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
    private static IDictionary<Nutrients, double> WorkedAmountOfNutrient(ICollection<QueryResults> list)
    {
        return list.SelectMany(ufr => ufr.RecipeIngredients
            .Where(ufri => ufri.Type == RecipeIngredientType.Ingredient)
            .SelectMany(ufri => ufri.GetNutrients(ufr.Nutrients))
        ).GroupBy(a => a.Key).ToDictionary(a => a.Key, a => a.Sum(b => b.Value));
    }
}
