using Data.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A user's weekly feast.
/// </summary>
[Table("user_feast")]
//[Index(nameof(UserId), nameof(Date))]
public class UserFeast
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserFeast() { }

    internal UserFeast(DateOnly date, FeastContext context) : this(date, context.User) { }

    public UserFeast(DateOnly date, User.User user)
    {
        Date = date;
        UserId = user.Id;
        Logs = UserLogs.WriteLogs(user);
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; private init; }

    /// <summary>
    /// The date the feast is for, using the user's UTC offset date.
    /// </summary>
    [Required]
    public DateOnly Date { get; private init; }

    public string? Logs { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFeasts))]
    public virtual User.User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipe.UserFeast))]
    public virtual ICollection<UserFeastRecipe> UserFeastRecipes { get; private init; } = null!;
}
