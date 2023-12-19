using Core.Models.Newsletter;
using Lib.ViewModels.User;

namespace Lib.ViewModels.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterViewModel
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; }

    public UserNewsletterViewModel User { get; init; } = null!;
    public NewsletterEntityViewModel UserWorkout { get; init; } = null!;

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; init; }

    public IList<RecipeViewModel> Recipes { get; init; } = null!;

    /// <summary>
    /// Hiding the footer in the demo iframe.
    /// </summary>
    public bool HideFooter { get; set; } = false;
}
