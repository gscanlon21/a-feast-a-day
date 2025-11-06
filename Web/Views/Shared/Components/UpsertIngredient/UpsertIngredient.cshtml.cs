using Core.Models.User;

namespace Web.Views.Shared.Components.UpsertIngredient;

public class UpsertIngredientViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.Users.User User { get; init; } = null!;
    public required Data.Entities.Ingredients.Ingredient Ingredient { get; set; } = null!;

    public required IList<Data.Entities.Users.Nutrient> Nutrients { get; set; }

    public IList<Allergens> AllergenSelect => EnumExtensions.GetSingleValues<Allergens>();
}
