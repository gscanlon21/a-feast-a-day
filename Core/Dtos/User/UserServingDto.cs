using Core.Consts;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

[Table("user_serving")]
public class UserServingDto
{
    public Section Section { get; init; }

    public int UserId { get; init; }

    [JsonIgnore]
    public virtual UserDto User { get; init; } = null!;

    [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
    public int Count { get; set; }
}
