using Core.Code.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Dtos.Newsletter;


/// <summary>
/// A day's workout routine.
/// </summary>
public class UserEmailDto
{
    [Obsolete("Public parameterless constructor required for EF Core .AsSplitQuery()", error: true)]
    public UserEmailDto() { }

    public UserEmailDto(User.UserDto user)
    {
        User = user;
    }

    /// <summary>
    /// UTC date the email was created.
    /// </summary>
    [Required]
    public DateOnly Date { get; set; } = DateHelpers.Today;

    /// <summary>
    /// UTC datetime the email should send after.
    /// </summary>
    [Required]
    public DateTime SendAfter { get; set; } = DateTime.UtcNow;

    public int Id { get; init; }

    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// Third-party ID for email checking delivery of emails.
    /// </summary>
    public string? SenderId { get; set; }

    [Required]
    public string Subject { get; set; } = null!;

    [Required]
    public string Body { get; set; } = null!;

    public EmailStatus Status { get; set; }

    public int SendAttempts { get; set; }

    /// <summary>
    /// The last error encountered.
    /// </summary>
    public string? LastError { get; set; }

    [JsonIgnore]
    public virtual User.UserDto User { get; init; } = null!;

    public enum EmailStatus
    {
        Pending = 0,
        Sending = 1,
        Sent = 2,
        Failed = 3,
        Delivered = 4
    }
}
