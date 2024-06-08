namespace Lib.ViewModels.Newsletter;

public class UserWorkoutViewModel
{
    public int Id { get; init; }

    public string Title()
    {
        return Date.ToLongDateString();
    }

    public string Description()
    {
        return $"{Date}";
    }

    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    public DateOnly Date { get; init; }
}
