using Core.Code.Extensions;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
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
        public IList<Nutrient> Nutrients { get; init; } = null!;
        public Recipe Recipe { get; init; } = null!;
        public IList<RecipeIngredientQueryResults> RecipeIngredients { get; init; } = null!;
        public UserRecipe UserRecipe { get; init; } = null!;
        public bool UserOwnsEquipment { get; init; }
    }

    [DebuggerDisplay("{Recipe}: {UserRecipe}")]
    private class InProgressQueryResults(RecipesQueryResults queryResult) :
        IRecipeCombo
    {
        public IList<Nutrient> Nutrients { get; set; } = queryResult.Nutrients;
        public Recipe Recipe { get; } = queryResult.Recipe;
        public IList<RecipeIngredientQueryResults> RecipeIngredients { get; set; } = queryResult.RecipeIngredients;
        public UserRecipe? UserRecipe { get; set; } = queryResult.UserRecipe;
        public bool UserOwnsEquipment { get; } = queryResult.UserOwnsEquipment;

        public override int GetHashCode() => HashCode.Combine(Recipe.Id);

        public override bool Equals(object? obj) => obj is InProgressQueryResults other
            && other.Recipe.Id == Recipe.Id;
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
                        .ThenInclude(ui => ui.SubstituteIngredient)
            .Where(ev => ev.DisabledReason == null)
            .Where(r => r.UserId == null || r.UserId == UserOptions.Id)
            // Don't grab recipes over our max ingredient count.
            .Where(r => r.User.MaxIngredients == null || r.RecipeIngredients.Count(i => !i.Ingredient.SkipShoppingList) <= r.User.MaxIngredients)
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
                }).ToList(),
                UserOwnsEquipment = UserOptions.NoUser
                    // The recipe does not require any equipment.
                    || r.Equipment == Equipment.None
                    // The user owns all of the equipment for the recipe.
                    || UserOptions.Equipment.HasFlag(r.Equipment)
            })
            // Filter down to recipes the user owns equipment for.
            .Where(vm => UserOptions.IgnoreMissingEquipment || vm.UserOwnsEquipment)
            // Don't grab recipes that the user wants to ignore.
            .Where(vm => UserOptions.IgnoreIgnored || vm.UserRecipe.Ignore != true)
            // Don't grab recipes that use ingredients that the user wants to ignore.
            // Checking the base ingredient for ignored and not the substitute ingredient,
            // because we don't want the user to ignore a substitute ingredient
            // and cause a cascade effect for recipes that use that substitute.
            .Where(vm => UserOptions.IgnoreIgnored || vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredient!.Ignore != true))
            // Don't grab recipes that use ingredient recipes that the user wants to ignore.
            .Where(vm => UserOptions.IgnoreIgnored || vm.RecipeIngredients.All(ri => ri.Optional || ri.UserIngredientRecipe!.Ignore != true));
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
        filteredQuery = Filters.FilterRecipes(filteredQuery, RecipeOptions.RecipeIds?.Select(r => r.Key).ToList());
        filteredQuery = Filters.FilterNutrients(filteredQuery, NutrientOptions.Nutrients.Aggregate(Nutrients.None, (curr2, n2) => curr2 | n2), include: true);
        filteredQuery = Filters.FilterEquipmentIds(filteredQuery, EquipmentOptions.Equipment);

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

            var allQueryResultIngredientIds = queryResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
            var ingredientAlternatives = (await context.Ingredients.Where(i => allQueryResultIngredientIds.Contains(i.Id))
                .Select(i => new { i.Id, AlternativeIngredients = i.Alternatives.Select(a => a.AlternativeIngredient) })
                .ToListAsync()).ToDictionary(i => i.Id, i => i.AlternativeIngredients);

            foreach (var queryResult in queryResults)
            {
                var ignoreRecipe = false;
                var finalRecipeIngredients = new List<RecipeIngredientQueryResults>();
                foreach (var recipeIngredient in queryResult.RecipeIngredients
                    // Filter out ignored ingredients and ingredient recipes.
                    .Where(ri => UserOptions.IgnoreIgnored || (ri.UserIngredient?.Ignore != true && ri.UserIngredientRecipe?.Ignore != true)))
                {
                    if (recipeIngredient.Ingredient != null)
                    {
                        // Swap the user's substituted ingredient or recipe.
                        if (recipeIngredient.UserIngredient?.SubstituteRecipeId.HasValue == true)
                        {
                            recipeIngredient.Ingredient = null;
                            recipeIngredient.IngredientRecipeId = recipeIngredient.UserIngredient!.SubstituteRecipeId;
                        }
                        else
                        {
                            // Fall back to use the ingredient for when a new UserIngredient is created, the substitute ingredient doesn't yet exist.
                            recipeIngredient.Ingredient = recipeIngredient.UserIngredient?.SubstituteIngredient ?? recipeIngredient.Ingredient;

                            // Switch the ingredient with another if it conflicts with allergens.
                            if (recipeIngredient.Ingredient.Allergens.HasAnyFlag32(UserOptions.Allergens))
                            {
                                recipeIngredient.Ingredient = ingredientAlternatives.TryGetValue(recipeIngredient.Ingredient.Id, out var alternatives)
                                    ? alternatives.FirstOrDefault(ai => !ai.Allergens.HasAnyFlag32(UserOptions.Allergens)) : null;

                                // Filter out optional ingredients that the user has allergens for.
                                if (recipeIngredient.Ingredient == null && !recipeIngredient.Optional)
                                {
                                    ignoreRecipe = true;
                                    break;
                                }
                            }
                        }
                    }

                    finalRecipeIngredients.Add(recipeIngredient);
                }

                if (!ignoreRecipe)
                {
                    queryResult.RecipeIngredients = finalRecipeIngredients;
                    filteredResults.Add(queryResult);
                }
            }
        }

        // Query for prerequisites ingredient recipes here so we can check check their ignored status before finalizing recipes.
        var prerequisiteRecipeIds = filteredResults.SelectMany(ar => ar.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue))
            // Don't scale prerequisite recipes yet since the prerequisite recipe scale is based on the quantity of the ingredient recipe.    
            .GroupBy(ri => ri.IngredientRecipeId!.Value).ToDictionary(g => g.Key, ri => 1/*(int)Math.Ceiling(ri.Quantity.ToDouble())*/);
        var prerequisiteRecipes = new List<QueryResults>();
        if (prerequisiteRecipeIds.Any())
        {
            prerequisiteRecipes = (await new QueryBuilder(Section.None)
                .WithUser(UserOptions)
                .WithRecipes(options =>
                {
                    options.AddRecipes(prerequisiteRecipeIds);
                })
                .Build()
                .Query(factory))
                .ToList();
        }

        // OrderBy must come after the query or you get cartesian explosion.
        var orderedResults = new List<QueryResults>();
        var allFilteredResultIngredientIds = filteredResults.SelectMany(qr => qr.RecipeIngredients.Select(ri => ri.Ingredient?.Id)).ToList();
        var allNutrients = await context.Nutrients.Where(n => allFilteredResultIngredientIds.Contains(n.IngredientId)).ToListAsync();
        foreach (var recipe in filteredResults
            // Order by recipes that are still pending refresh.
            .OrderByDescending(a => a.UserRecipe?.RefreshAfter.HasValue)
            // Show recipes that the user has rarely seen.
            .ThenBy(a => a.UserRecipe?.LastSeen.DayNumber)
            // Mostly for the demo, show mostly random exercises.
            // NOTE: When the two variation's LastSeen dates are the same:
            // ... The LagRefreshXWeeks will prevent the LastSeen date from updating
            // ... and we may see two randomly alternating exercises for the LagRefreshXWeeks duration.
            .ThenBy(_ => RandomNumberGenerator.GetInt32(Int32.MaxValue))
            // Don't re-order the list on each read.
            .ToList())
        {
            var queryResultPrerequisiteRecipeIds = recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).Select(ri => ri.IngredientRecipeId!.Value).ToList();
            var queryResultPrerequisiteRecipes = prerequisiteRecipes.Where(pr => queryResultPrerequisiteRecipeIds.Contains(pr.Recipe.Id)).ToList();

            foreach (var recipeIngredient in recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue))
            {
                recipeIngredient.IngredientRecipe = prerequisiteRecipes.FirstOrDefault(pr => pr.Recipe.Id == recipeIngredient.IngredientRecipeId!.Value);
            }

            // Ignore the recipe if any of the prerequisite ingredient recipes are null.
            if (recipe.RecipeIngredients.Where(ri => ri.IngredientRecipeId.HasValue).All(ri => ri.IngredientRecipe != null))
            {
                var scale = RecipeOptions.RecipeIds?.TryGetValue(recipe.Recipe.Id, out int scaleTemp) == true ? scaleTemp : 1;
                recipe.Nutrients = allNutrients.Where(n => recipe.RecipeIngredients.Select(ri => ri.Ingredient?.Id).Contains(n.IngredientId)).ToList();
                orderedResults.Add(new QueryResults(section, recipe.Recipe, recipe.Nutrients, recipe.RecipeIngredients, recipe.UserRecipe)
                {
                    Scale = scale,
                });
            }
        }

        var nutrientTarget = NutrientOptions.NutrientTarget.Compile();
        var finalResults = new List<QueryResults>();
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
                        recipe.Scale = (int)Math.Ceiling(ServingsOptions.AtLeastXServingsPerRecipe.Value / (double)recipe.Recipe.Servings);
                        foreach (var queryResultPrerequisiteRecipe in recipe.RecipeIngredients.Where(ri => ri.IngredientRecipe != null))
                        {
                            queryResultPrerequisiteRecipe.IngredientRecipe!.Scale = recipe.Scale;
                        }
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

                // Don't overwork nutrients.
                var overworkedNutrients = GetOverworkedNutrients(finalResults);
                if (overworkedNutrients.Any(mg => nutrientTarget(recipe).ContainsKey(mg)))
                {
                    continue;
                }

                // Choose exercises that cover at least X nutrients in the targeted nutrient set.
                if (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue)
                {
                    var unworkedNutrients = GetUnworkedNutrients(finalResults);

                    // We've already worked all unique nutrients.
                    if (unworkedNutrients.Count == 0)
                    {
                        break;
                    }

                    // The recipe does not work enough unique nutrients that we are trying to target.
                    // Allow recipes that have a refresh date since we want to show those continuously until that date.
                    // Allow the first recipe with any nutrient so the user does not get stuck from seeing certain recipes
                    // ... if, for example, a prerequisite only works one nutrient and that nutrient is otherwise worked by other recipes.
                    var nutrientsToWork = (recipe.UserRecipe?.RefreshAfter != null || !finalResults.Any(r => r.UserRecipe?.RefreshAfter == null)) ? 1 : NutrientOptions.AtLeastXNutrientsPerRecipe.Value;
                    if (unworkedNutrients.Count(mg => nutrientTarget(recipe).ContainsKey(mg)) < Math.Max(1, nutrientsToWork))
                    {
                        continue;
                    }
                }

                if (!finalResults.Contains(recipe))
                {
                    finalResults.AddRange(recipe.RecipeIngredients.Where(ri => ri.IngredientRecipe != null).Select(ri => ri.IngredientRecipe!));
                    finalResults.Add(recipe);
                }
            }
        }
        // Slowly allow out of preference recipes until we meet our nutritional targets.
        while ((ServingsOptions.AtLeastXServingsPerRecipe.HasValue && --ServingsOptions.AtLeastXServingsPerRecipe >= 1)
            || (NutrientOptions.AtLeastXNutrientsPerRecipe.HasValue && --NutrientOptions.AtLeastXNutrientsPerRecipe >= 1)
        );

        // REFACTORME
        return section switch
        {
            // Not in a workout context, order by name.
            Section.None => [.. finalResults.Take(take).OrderBy(vm => vm.Recipe.Name)],
            // We are in a workout context, keep the result order.
            _ => finalResults.Take(take).ToList()
        };
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
            .Where(i => i.UserIngredientRecipe == null && i.IngredientRecipeId.HasValue))
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

    private List<Nutrients> GetUnworkedNutrients(IList<QueryResults> finalResults)
    {
        // Not using Nutrients because NutrientTargets can contain unions 
        return NutrientOptions.NutrientTargetsRDA.Where(kv =>
        {
            // We are targeting this nutrient.
            return NutrientOptions.Nutrients.Any(mg => kv.Key.HasFlag(mg))
                // We have not overconsumed this nutrient.
                && WorkedAnyNutrientCount(finalResults, kv.Key) < kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    private List<Nutrients> GetOverworkedNutrients(IList<QueryResults> finalResults)
    {
        // Not using Nutrients because NutrientTargets can contain unions.
        return NutrientOptions.NutrientTargetsTUL.Where(kv =>
        {
            // We have consumed too much of this nutrient.
            return WorkedAnyNutrientCount(finalResults, kv.Key) >= kv.Value;
        }).Select(kv => kv.Key).ToList();
    }

    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    private static double WorkedAnyNutrientCount(IList<QueryResults> list, Nutrients nutrients, int weightDivisor = 1)
    {
        return list.Sum(r =>
        {
            var nutrient = r.Nutrients.FirstOrDefault(n => n.Nutrients == nutrients);
            return r.Scale * nutrient?.Measure.ToGrams(nutrient.Value) ?? 0;
        }) / weightDivisor;
    }
}
