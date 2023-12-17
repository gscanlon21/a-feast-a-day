using Core.Models.Exercise;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_workout"), Comment("A day's workout routine")]
public class UserWorkout
{
    [Obsolete("Public parameterless constructor required for EF Core .AsSplitQuery()", error: true)]
    public UserWorkout() { }

    internal UserWorkout(DateOnly date, WorkoutContext context) : this(date, context.User) { }

    public UserWorkout(DateOnly date, User.User user)
    {
        Date = date;
        User = user;
        Intensity = user.Intensity;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; private init; }

    /// <summary>
    /// The date the workout is for, using the user's UTC offset date.
    /// </summary>
    [Required]
    public DateOnly Date { get; private init; }

    /// <summary>
    /// What was the workout split used when this newsletter was sent?
    /// </summary>
    [Required]
    public Intensity Intensity { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserWorkouts))]
    public virtual User.User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserWorkoutVariation.UserWorkout))]
    public virtual ICollection<UserWorkoutVariation> UserWorkoutVariations { get; private init; } = null!;
}
