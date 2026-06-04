namespace Terminal.Programs.HealthCanada.Models;

internal static class NutrientAmountHeaders
{
    public const string FOOD_ID = "Food_Code";
    public const string NUTRIENT_ID = "Nutrient_Code";

    /// <summary>
    /// Amount per 100 grams.
    /// Unit goes off nutrient.csv.
    /// </summary>
    public const string NUTRIENT_VALUE = "Nutrient_Amount";
}
