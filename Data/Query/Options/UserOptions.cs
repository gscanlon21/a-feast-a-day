using Core.Dtos.User;
using Core.Models.Recipe;
using Core.Models.User;

namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;

    public int Id { get; }
    public Equipment Equipment { get; }
    public Allergy Allergens { get; }
    public int? MaxIngredients { get; }
    public DateOnly CreatedDate { get; }

    public bool IgnoreMissingEquipment { get; set; } = false;
    public bool IgnoreIgnored { get; set; } = false;

    public UserOptions() { }

    public UserOptions(UserDto user)
    {
        NoUser = false;
        Id = user.Id;
        Equipment = user.Equipment;
        Allergens = user.ExcludeAllergens;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
    }

    public UserOptions(Entities.User.User user)
    {
        NoUser = false;
        Id = user.Id;
        Equipment = user.Equipment;
        Allergens = user.ExcludeAllergens;
        CreatedDate = user.CreatedDate;
        MaxIngredients = user.MaxIngredients;
    }
}
