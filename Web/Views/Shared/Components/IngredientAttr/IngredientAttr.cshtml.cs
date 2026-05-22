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
        ? $"https://open.canada.ca/data/en/dataset/1b6139bd-ed7e-4043-bc28-ff00e10f3109/resource/e1ffee62-58cb-4e3e-b359-115c658388ad?id={IngredientAttr.HC_Id}"
        : "https://open.canada.ca/data/en/dataset/1b6139bd-ed7e-4043-bc28-ff00e10f3109/resource/e1ffee62-58cb-4e3e-b359-115c658388ad/";
}
