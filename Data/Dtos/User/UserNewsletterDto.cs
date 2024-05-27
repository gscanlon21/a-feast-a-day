using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.User;

/// <summary>
/// For the newsletter
/// </summary>
public class UserNewsletterDto(Entities.User.User user, string token)
{
    internal UserNewsletterDto(WorkoutContext context) : this(context.User, context.Token)
    {
    }

    public int Id { get; } = user.Id;

    public string Email { get; } = user.Email;

    public string Token { get; } = token;

    public Features Features { get; } = user.Features;

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; } = user.FootnoteType;

    public DateOnly? LastActive { get; } = user.LastActive;

    [Display(Name = "Send Days")]
    public Days SendDays { get; } = user.SendDays;

    [Display(Name = "Email Verbosity")]
    public Verbosity Verbosity { get; } = user.Verbosity;

    public int FootnoteCountTop { get; init; } = user.FootnoteCountTop;

    public int FootnoteCountBottom { get; init; } = user.FootnoteCountBottom;

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
