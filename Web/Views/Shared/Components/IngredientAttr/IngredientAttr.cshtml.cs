using Core.Models.User;
using Data.Entities.Ingredients;

namespace Web.Views.Shared.Components.UpsertIngredient;

public class IngredientAttrViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;

    public required Ingredient Ingredient { get; set; } = null!;
    public required Data.Entities.Ingredients.IngredientAttr IngredientAttr { get; set; } = null!;
}
