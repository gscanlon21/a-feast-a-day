using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_nutrient")]
public class UserNutrient
{
    public const int NutrientTargetMin = 0;

    public Nutrients Nutrient { get; init; }

    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Users.User.UserNutrients))]
    public virtual User User { get; private init; } = null!;

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);
}
