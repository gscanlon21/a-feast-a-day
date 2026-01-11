using Core.Models.User;
using Data.Entities.Ingredients;
using Data.Entities.Users;
using Data.Interfaces.Recipe;
using Data.Models.Ingredients;

namespace Data.Code.Extensions;

public static class RecipeIngredientExtensions
{
    internal static double ServingsUsed(this IRecipeIngredient recipeIngredient, Ingredient ofIngredient)
    {
        return recipeIngredient.GramsUsed(ofIngredient) / ofIngredient.GramsPerServing;
    }

    internal static double GramsUsed(this IRecipeIngredient recipeIngredient, Ingredient ofIngredient)
    {
        return recipeIngredient.GetQuantity * recipeIngredient.GetMeasure.ToGramsWithContext(ofIngredient, recipeIngredient.IsCoarseCut);
    }

    internal static IDictionary<Nutrients, double> GetNutrients(this IRecipeIngredient recipeIngredient, Dictionary<int, List<Nutrient>>? nutrients = null, IList<IngredientScale>? partialIngredients = null, Dictionary<int, Ingredient>? cookedIngredients = null)
    {
        if (recipeIngredient.GetIngredient == null)
        {
            return new Dictionary<Nutrients, double>();
        }

        // If there are aggregate ingredients.
        if (partialIngredients?.Any() == true)
        {
            return partialIngredients?.SelectMany(partialIngredient =>
            {
                var partialIngredientNutrients = nutrients?.GetValueOrDefault(partialIngredient.Ingredient.Id);
                return partialIngredientNutrients?.Select(nutrient =>
                {
                    var servingsOfIngredientUsed = recipeIngredient.ServingsUsed(partialIngredient.Ingredient);
                    var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(partialIngredient.Ingredient, recipeIngredient.IsCoarseCut);
                    var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value * recipeIngredient.GetCookedScale * partialIngredient.Scale;
                    return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
                }) ?? [];
            })?.GroupBy(kv => kv.Nutrient).ToDictionary(kv => kv.Key, kv => kv.Average(x => x.GramsOfNutrientPerRecipe)) ?? [];
        }
        // Reduce the scale of nutrients if an ingredient is cooked off so it's not overweighted. Note that cooking methods are saved when feasts are generated and changes before the recipe ingredient was updated aren't reflected.
        else if (cookedIngredients != null && cookedIngredients.TryGetValue(recipeIngredient.GetRecipeIngredientId, out Ingredient? cookedIngredient) && cookedIngredient != null)
        {
            var recipeIngredientNutrients = nutrients?.GetValueOrDefault(cookedIngredient.Id);
            return (recipeIngredientNutrients ?? recipeIngredient.GetIngredient!.Nutrients).Select(nutrient =>
            {
                var servingsOfIngredientUsed = recipeIngredient.ServingsUsed(cookedIngredient);
                var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(cookedIngredient, recipeIngredient.IsCoarseCut);
                var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value * recipeIngredient.GetCookedScale;
                return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
            })?.ToDictionary(kv => kv.Nutrient, kv => kv.GramsOfNutrientPerRecipe) ?? [];
        }
        else
        {
            var recipeIngredientNutrients = nutrients?.GetValueOrDefault(recipeIngredient.GetIngredient!.Id);
            return (recipeIngredientNutrients ?? recipeIngredient.GetIngredient!.Nutrients).Select(nutrient =>
            {
                var servingsOfIngredientUsed = recipeIngredient.ServingsUsed(recipeIngredient.GetIngredient);
                var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(recipeIngredient.GetIngredient, recipeIngredient.IsCoarseCut);
                var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value * recipeIngredient.GetCookedScale;
                return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
            })?.ToDictionary(kv => kv.Nutrient, kv => kv.GramsOfNutrientPerRecipe) ?? [];
        }
    }
}
