using Core.Models.Ingredients;
using Core.Models.User;

namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;

    public int Id { get; }
    public Allergens Allergens { get; }
    public int? MaxIngredients { get; }
    public IngredientOrder IngredientOrder { get; }
    public DateOnly CreatedDate { get; }

    public bool IgnoreIgnored { get; set; } = false;

    public UserOptions() { }

    public UserOptions(Entities.User.User user)
    {
        NoUser = false;
        Id = user.Id;
        CreatedDate = user.CreatedDate;
        Allergens = user.ExcludeAllergens;
        MaxIngredients = user.MaxIngredients;
        IngredientOrder = user.IngredientOrder;
    }
}
