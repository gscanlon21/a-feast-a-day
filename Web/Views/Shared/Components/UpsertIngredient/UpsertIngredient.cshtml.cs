using Core.Models.Ingredients;
using Data.Entities.Nutrients;

namespace Web.Views.Shared.Components.UpsertIngredient;

public class UpsertIngredientViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;
    public required Data.Entities.Ingredients.Ingredient Ingredient { get; set; } = null!;

    public required IList<USDANutrient> Nutrients { get; set; }

    public IList<Allergens> AllergenSelect => EnumExtensions.GetSingleValues<Allergens>();
}
