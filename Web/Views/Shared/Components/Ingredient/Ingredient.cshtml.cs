using Core.Models.User;

namespace Web.Views.Shared.Components.Ingredient;

public class IngredientViewModel
{
    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;
    public required Data.Entities.Ingredient.Ingredient Ingredient { get; set; } = null!;

    public required IList<Data.Entities.User.Nutrient> Nutrients { get; set; }

    public IList<Allergens> AllergenSelect => EnumExtensions.GetSingleValues64<Allergens>();
}
