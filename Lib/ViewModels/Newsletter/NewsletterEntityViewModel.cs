using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
public class NewsletterEntityViewModel
{
    public int Id { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    [Required]
    public DateOnly Date { get; init; }

    /// <summary>
    /// Deloads are weeks with a message to lower the intensity of the workout so muscle growth doesn't stagnate
    /// </summary>
    [Required]
    public bool IsDeloadWeek { get; init; }
}
