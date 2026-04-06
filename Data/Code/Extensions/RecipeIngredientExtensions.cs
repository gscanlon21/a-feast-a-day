using Core.Models.Nutrients;
using Data.Entities.Ingredients;
using Data.Interfaces.Recipe;
using Data.Models;
using Data.Models.Ingredients;

namespace Data.Code.Extensions;

public static class RecipeIngredientExtensions
{
    /// <summary>
    /// How many servings does a recipe ingredient use of an ingredient?
    /// </summary>
    internal static double ServingsUsed(this IRecipeIngredient recipeIngredient, Ingredient ofIngredient)
    {
        return recipeIngredient.GramsUsed(ofIngredient) / ofIngredient.GramsPerServing;
    }

    /// <summary>
    /// How many grams does a recipe ingredient use of an ingredient?
    /// </summary>
    internal static double GramsUsed(this IRecipeIngredient recipeIngredient, Ingredient ofIngredient)
    {
        return recipeIngredient.GetQuantity * recipeIngredient.GetMeasure.ToGramsWithContext(ofIngredient, recipeIngredient.IsCoarseCut);
    }

    /// <summary>
    /// TODO: Rewrite this at some point please.
    /// </summary>
    internal static IDictionary<Nutrients, double> GetNutrients(this IRecipeIngredient recipeIngredient, Dictionary<int, List<QueryNutrient>>? nutrients = null, IList<IngredientScale>? partialIngredients = null)
    {
        if (recipeIngredient.GetIngredient == null)
        {
            return new Dictionary<Nutrients, double>();
        }

        // If there are partial ingredients.
        if (partialIngredients?.Count > 0)
        {
            return partialIngredients?.SelectMany(partialIngredient =>
            {
                var servingsOfIngredientUsed = recipeIngredient.ServingsUsed(partialIngredient.Ingredient);
                var partialIngredientNutrients = nutrients?.GetValueOrDefault(partialIngredient.Ingredient.Id);
                return partialIngredientNutrients?.Select(nutrient =>
                {
                    // This isn't necessary because our nutrient sources already do the conversions for us.
                    //var nutrientEquivalency = nutrient.Nutrients.GetEquivalentConversion(nutrient.Measure);
                    var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(partialIngredient.Ingredient, recipeIngredient.IsCoarseCut);
                    var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value * recipeIngredient.GetCookedScale * partialIngredient.Scale;
                    return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
                }).GroupBy(kv => kv.Nutrient).ToDictionary(g => g.Key, g => g.Sum(kv => kv.GramsOfNutrientPerRecipe)) ?? [];
            })?.GroupBy(kv => kv.Key).ToDictionary(g => g.Key, g => g.Average(x => x.Value)) ?? [];
        }
        else
        {
            var servingsOfIngredientUsed = recipeIngredient.ServingsUsed(recipeIngredient.GetIngredient);
            var recipeIngredientNutrients = nutrients?.GetValueOrDefault(recipeIngredient.GetIngredient.Id);
            return (recipeIngredientNutrients ?? recipeIngredient.GetIngredient.QueryNutrients).Select(nutrient =>
            {
                // This isn't necessary because our nutrient sources already do the conversions for us.
                //var nutrientEquivalency = nutrient.Nutrients.GetEquivalentConversion(nutrient.Measure);
                var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(recipeIngredient.GetIngredient, recipeIngredient.IsCoarseCut);
                var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value * recipeIngredient.GetCookedScale;
                return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
            })?.GroupBy(kv => kv.Nutrient).ToDictionary(g => g.Key, g => g.Sum(kv => kv.GramsOfNutrientPerRecipe)) ?? [];
        }
    }
}
