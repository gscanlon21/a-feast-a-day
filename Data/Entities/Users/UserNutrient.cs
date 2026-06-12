using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_nutrient")]
[DebuggerDisplay("{Nutrient}: {Start}-{End}")]
public class UserNutrient
{
    public Core.Models.Nutrients.Nutrients Nutrient { get; init; }

    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; init; }

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Users.User.UserNutrients))]
    public virtual User User { get; private init; } = null!;

    #endregion
}
