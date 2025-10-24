using Core.Models.User;
using Data.Entities.Ingredient;
using Data.Entities.User;
using Data.Interfaces.Recipe;

namespace Data.Code.Extensions;

public static class UserFeastRecipeIngredientExtensions
{
    internal static double NumberOfServings(this IRecipeIngredient recipeIngredient)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.GetIngredient);
        return recipeIngredient.ToGrams() / recipeIngredient.GetIngredient.GramsPerServing;
    }

    internal static double ToGrams(this IRecipeIngredient recipeIngredient)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.GetIngredient);
        return recipeIngredient.GetQuantity * recipeIngredient.GetMeasure.ToGramsWithContext(recipeIngredient.GetIngredient);
    }

    internal static IDictionary<Nutrients, double> GetNutrients(this IRecipeIngredient recipeIngredient, IList<Nutrient>? nutrients = null, IList<Ingredient>? altIngredients = null)
    {
        if (recipeIngredient.GetIngredient == null)
        {
            return new Dictionary<Nutrients, double>();
        }

        if (altIngredients?.Any() == true)
        {
            var altIngredientNutrients = nutrients?.NullIfEmpty()?.Where(n => true == altIngredients?.Select(ai => ai.Id).Contains(n.IngredientId));
            return (altIngredientNutrients ?? altIngredients.SelectMany(ai => ai.Nutrients)).Select(nutrient =>
            {
                var servingsOfIngredientUsed = recipeIngredient.NumberOfServings();
                var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(recipeIngredient.GetIngredient);
                var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value;
                return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
            })?.GroupBy(kv => kv.Nutrient).ToDictionary(kv => kv.Key, kv => kv.Average(x => x.GramsOfNutrientPerRecipe)) ?? [];
        }
        else
        {
            var recipeIngredientNutrients = nutrients?.NullIfEmpty()?.Where(n => n.IngredientId == recipeIngredient.GetIngredient!.Id);
            return (recipeIngredientNutrients ?? recipeIngredient.GetIngredient!.Nutrients).Select(nutrient =>
            {
                var servingsOfIngredientUsed = recipeIngredient.NumberOfServings();
                var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(recipeIngredient.GetIngredient);
                var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value;
                return new { Nutrient = nutrient.Nutrients, GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe };
            })?.ToDictionary(kv => kv.Nutrient, kv => kv.GramsOfNutrientPerRecipe) ?? [];
        }
    }
}
