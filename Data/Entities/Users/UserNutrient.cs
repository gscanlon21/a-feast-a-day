using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_nutrient")]
[DebuggerDisplay("{Nutrient}: {Start}-{End}")]
public class UserNutrient
{
    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; init; }

    public Core.Models.Nutrients.Nutrients Nutrient { get; init; }

    public double RDAScale { get; set; }

    public double TULScale { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Users.User.UserNutrients))]
    public virtual User User { get; private init; } = null!;

    #endregion
}
