using Core.Models.User;
using Data.Entities.User;
using Fractions;

namespace Core.Code.Extensions;

public static class RecipeIngredientExtensions
{
    /// <summary>
    /// Returns null if the source list does not contain any items.
    /// </summary>
    public static double NumberOfServings(this RecipeIngredient recipeIngredient, Ingredient ingredient)
    {
        var fraction = new Fraction(recipeIngredient.QuantityNumerator ?? 0, recipeIngredient.QuantityDenominator ?? 1, true);

        return recipeIngredient.Measure switch
        {
            Measure.Grams => fraction.ToDouble() / ingredient.ServingSizeGrams,
            Measure.Ounce => fraction.ToDouble() * 28.3495231 / ingredient.ServingSizeGrams,
            Measure.Pound => fraction.ToDouble() * 453.59237 / ingredient.ServingSizeGrams,
            Measure.Teaspoon => fraction.ToDouble() * ingredient.GramsInACup * 0.02083333 / ingredient.ServingSizeGrams,
            Measure.Tablespoon => fraction.ToDouble() * ingredient.GramsInACup * 0.0625 / ingredient.ServingSizeGrams,
            Measure.Handful => fraction.ToDouble() * ingredient.GramsInACup * 0.5 / ingredient.ServingSizeGrams,
            Measure.Jar => fraction.ToDouble() * ingredient.GramsInACup / ingredient.ServingSizeGrams,
            Measure.Can => fraction.ToDouble() * ingredient.GramsInACup / ingredient.ServingSizeGrams,
            Measure.Cup => fraction.ToDouble() * ingredient.GramsInACup / ingredient.ServingSizeGrams,
            _ => 1,
        };
    }
}
