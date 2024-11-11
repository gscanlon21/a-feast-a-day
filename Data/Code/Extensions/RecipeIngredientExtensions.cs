using Core.Models.User;
using Data.Interfaces.Recipe;

namespace Data.Code.Extensions;

public static class UserFeastRecipeIngredientExtensions
{
    internal static double NumberOfServings(this IRecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.GetIngredient);
        return recipeIngredient.ToGrams(scale) / recipeIngredient.GetIngredient.GramsPerServing;
    }

    internal static double ToGrams(this IRecipeIngredient recipeIngredient, int scale = 1)
    {
        ArgumentNullException.ThrowIfNull(recipeIngredient?.GetIngredient);
        return scale * recipeIngredient.GetQuantity * recipeIngredient.GetMeasure.ToGramsWithContext(recipeIngredient.GetIngredient);
    }

    internal static IDictionary<Nutrients, double> GetNutrients(this IRecipeIngredient recipeIngredient, int scale = 1)
    {
        if (recipeIngredient.GetIngredient == null)
        {
            return new Dictionary<Nutrients, double>();
        }

        return recipeIngredient.GetIngredient!.Nutrients.Select(nutrient =>
        {
            var servingsOfIngredientUsed = recipeIngredient.NumberOfServings(scale);
            var gramsOfNutrientPerServing = nutrient.Measure.ToGramsWithContext(recipeIngredient.GetIngredient);
            var gramsOfNutrientPerRecipe = servingsOfIngredientUsed * gramsOfNutrientPerServing * nutrient.Value;
            return new
            {
                Nutrient = nutrient.Nutrients,
                GramsOfNutrientPerRecipe = gramsOfNutrientPerRecipe,
            };
        })?.ToDictionary(kv => kv.Nutrient, kv => kv.GramsOfNutrientPerRecipe) ?? [];
    }
}
