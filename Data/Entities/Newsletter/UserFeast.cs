﻿using Core.Dtos.User;
using Core.Models.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Web.Code;

namespace Data.Entities.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
[Table("user_feast"), Comment("A day's workout routine")]
public class UserFeast
{
    [Obsolete("Public parameterless constructor required for EF Core .AsSplitQuery()", error: true)]
    public UserFeast() { }

    internal UserFeast(DateOnly date, FeastContext context) : this(date, context.User.AsType<User.User, UserDto>()!) { }

    public UserFeast(DateOnly date, User.User user)
    {
        Date = date;
        UserId = user.Id;
        Logs = Core.Code.Logs.WriteLogs(user);
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

    public string? Logs { get; private init; }

    //[JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFeasts))]
    //public virtual User.User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserFeastRecipe.UserFeast))]
    public virtual ICollection<UserFeastRecipe> UserFeastRecipes { get; private init; } = null!;
}
