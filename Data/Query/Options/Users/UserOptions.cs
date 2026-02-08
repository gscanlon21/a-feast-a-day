using Core.Models.Ingredients;
using Core.Models.User;
using Data.Entities.Users;

namespace Data.Query.Options.Users;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;
    public bool IgnoreIgnored { get; set; } = false;

    public int Id { get; }
    public DateOnly CreatedDate { get; }
    public int? MaxIngredients { get; set; }
    public IngredientOrder IngredientOrder { get; }
    public ICollection<UserFoodPreference> FoodPreferences { get; set; } = [];

    public Allergens SemiAllergens => FoodPreferences
        .Where(f => f.FoodPreference == FoodPreference.Seldom)
        .Aggregate(Allergens.None, (c, n) => c | n.Allergen);

    public Allergens Allergens => FoodPreferences
        .Where(f => f.FoodPreference == FoodPreference.Exclude)
        .Aggregate(Allergens.None, (c, n) => c | n.Allergen);

    public UserOptions() { }

    public UserOptions(User user)
    {
        Id = user.Id;
        NoUser = false;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
        IngredientOrder = user.IngredientOrder;
        FoodPreferences = user.UserFoodPreferences;
        if (user.UserFoodPreferences.Any() == false)
        {
            UserLogs.Log(user, "User has no food preferences!");
        }
    }
}
