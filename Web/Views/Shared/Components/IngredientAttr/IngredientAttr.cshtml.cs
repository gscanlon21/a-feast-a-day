using Data.Entities.Ingredients;

namespace Web.Views.Shared.Components.UpsertIngredient;

public class IngredientAttrViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public required Ingredient Ingredient { get; set; } = null!;
    public required Data.Entities.Ingredients.IngredientAttr IngredientAttr { get; set; } = null!;

    public string GetUSDAFoodSearchUrl() => IngredientAttr.FDC_ID.HasValue
        ? $"https://fdc.nal.usda.gov/food-details/{IngredientAttr.FDC_ID}/nutrients"
        : "https://fdc.nal.usda.gov/food-search/";

    public string GetHealthCanadaUrl() => IngredientAttr.HC_Id.HasValue
        ? $"https://food-nutrition.canada.ca/cnf-fce/serving-portion?id={IngredientAttr.HC_Id}"
        : "https://food-nutrition.canada.ca/cnf-fce/";
}
