using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Dtos.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_feast")]
public class UserFeastDto
{
    [Obsolete("Public parameterless constructor required for EF Core .AsSplitQuery()", error: true)]
    public UserFeastDto() { }

    public UserFeastDto(DateOnly date, User.UserDto user)
    {
        Date = date;
        User = user;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// The date the workout is for, using the user's UTC offset date.
    /// </summary>
    [Required]
    public DateOnly Date { get; init; }

    [JsonIgnore]
    public virtual User.UserDto User { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserFeastRecipeDto> UserFeastRecipes { get; init; } = null!;
}
