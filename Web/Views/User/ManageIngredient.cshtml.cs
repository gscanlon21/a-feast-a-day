using Data.Entities.User;

namespace Web.Views.User;


public class ManageIngredientViewModel
{
    public ManageIngredientViewModel() { }

    public bool? WasUpdated { get; init; }

    public required string Token { get; init; }
    public required Data.Entities.User.User User { get; set; } = null!;
    public required Data.Entities.User.Ingredient Ingredient { get; set; } = null!;

    public required IList<Nutrient> Nutrients { get; set; }
}
