using Core.Models.Ingredients;
using Core.Models.User;

namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;

    public int Id { get; }
    public int? MaxIngredients { get; }
    public Allergens Allergens { get; }
    public DateOnly CreatedDate { get; }
    public IngredientOrder IngredientOrder { get; }

    public UserOptions() { }

    public UserOptions(Entities.User.User user)
    {
        Id = user.Id;
        NoUser = false;
        Allergens = user.Allergens;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
        IngredientOrder = user.IngredientOrder;
    }
}
