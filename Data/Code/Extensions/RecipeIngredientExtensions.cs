using Core.Models.User;
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

    internal static IDictionary<Nutrients, double> GetNutrients(this IRecipeIngredient recipeIngredient, IList<Nutrient>? nutrients = null)
    {
        if (recipeIngredient.GetIngredient == null)
        {
            return new Dictionary<Nutrients, double>();
        }

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
