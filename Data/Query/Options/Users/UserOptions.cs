using Core.Models.Ingredients;
using Core.Models.User;
using Data.Entities.Users;

namespace Data.Query.Options.Users;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;
    public bool IgnoreIgnored { get; set; } = false;

    public int Id { get; }
    public Allergens Allergens { get; }
    public DateOnly CreatedDate { get; }
    public IngredientOrder IngredientOrder { get; }
    public int? MaxIngredients { get; set; }

    public UserOptions() { }

    public UserOptions(User user)
    {
        Id = user.Id;
        NoUser = false;
        Allergens = user.Allergens;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
        IngredientOrder = user.IngredientOrder;
    }
}
