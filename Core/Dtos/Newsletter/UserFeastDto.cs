
namespace Core.Dtos.Newsletter;

/// <summary>
/// A day's workout routine.
/// </summary>
public class UserFeastDto
{
    public int Id { get; init; }

    public int UserId { get; init; }

    /// <summary>
    /// The date the workout is for, using the user's UTC offset date.
    /// </summary>
    public DateOnly Date { get; init; }

    public string? Logs { get; init; }

    /// <summary>
    /// Title to display for the list item in the app.
    /// </summary>
    public string Title() => Date.ToLongDateString();

    /// <summary>
    /// Description to display for the list item in the app.
    /// </summary>
    public string Description() => $"{Date}";
}
