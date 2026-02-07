using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_food_preference")]
public class UserFoodPreference
{
    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Users.User.UserFoodPreferences))]
    public virtual User User { get; private init; } = null!;

    public FoodPreference FoodPreference { get; set; }

    public Allergens Allergen { get; init; }

    public override string ToString()
    {
        return $"{Allergen}: {FoodPreference}";
    }
}
