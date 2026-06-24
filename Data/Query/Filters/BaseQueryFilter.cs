using Core.Models;
using Core.Models.Recipe;
using Data.Code.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Query.Filters;

public abstract class BaseQueryFilter
{
    public abstract Task<List<QueryResults>> Filter(List<QueryResults> queryResults, IServiceScopeFactory factory, int take = int.MaxValue);

    /// <summary>
    /// Adds the recipe's prep recipes to the finalResults list or scales it if it is scaleable.
    /// </summary>
    protected static void ScaleAndAddPrepRecipes(QueryResults recipe, HashSet<QueryResults> finalResults, HashSet<QueryResults> prepRecipes)
    {
        // Append the recipe's prep recipes. Scale them if they are duplicates and are adjustable.
        foreach (var prepRecipe in recipe.PrepRecipes)
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
            if (prepRecipes.TryGetValue(prepRecipe.Key, out var scalePrepRecipe) && scalePrepRecipe.Recipe.AdjustableServings)
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
    }
}
