using Core.Code.Extensions;
using Core.Models.User;
using Data.Query;

namespace Data.Code.Extensions;

public static class RecipeExtensions
{
    /// <summary>
    /// Returns the muscles targeted by any of the items in the list as a dictionary with their count of how often they occur.
    /// </summary>
    internal static double WorkedAnyNutrientCount<T>(this IEnumerable<T> list, Nutrients nutrients, int weightDivisor = 1) where T : IRecipeCombo
    {
        return list.Sum(r =>
        {
            var nutrient = r.Nutrients.FirstOrDefault(n => n.Nutrients == nutrients);
            return nutrient?.Measure.ToGrams(nutrient.Value) ?? 0;
        }) / weightDivisor;
    }
}
