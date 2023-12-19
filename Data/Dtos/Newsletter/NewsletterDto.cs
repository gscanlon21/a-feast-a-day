using Core.Models.Newsletter;
using Data.Dtos.User;
using Data.Entities.User;

namespace Data.Dtos.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterDto(UserNewsletterDto user, Entities.Newsletter.UserFeast newsletter)
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public UserNewsletterDto User { get; } = user;
    public Entities.Newsletter.UserFeast UserWorkout { get; } = newsletter;

    public IList<UserRecipe> Recipes { get; set; }

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; } = user.Verbosity;
}
