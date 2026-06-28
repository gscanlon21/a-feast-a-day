using Core.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_food_preference")]
[DebuggerDisplay("{ToString(),nq}")]
public class UserFoodPreference
{
    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; init; }

    public Allergens Allergen { get; init; }

    public FoodPreference FoodPreference { get; init; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Users.User.UserFoodPreferences))]
    public virtual User User { get; private init; } = null!;

    #endregion


    public override string ToString()
    {
        return $"{Allergen}: {FoodPreference}";
    }
}
