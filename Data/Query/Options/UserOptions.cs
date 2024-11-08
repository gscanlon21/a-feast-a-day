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

    public bool IgnoreIgnored { get; set; } = false;

    public UserOptions() { }

    public UserOptions(Entities.User.User user, bool ignoreAllergens = false)
    {
        NoUser = false;
        Id = user.Id;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
        IngredientOrder = user.IngredientOrder;
        Allergens = ignoreAllergens ? Allergens.None : user.ExcludeAllergens;
    }
}
