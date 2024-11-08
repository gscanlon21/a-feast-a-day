using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;

namespace Core.Dtos.User;

/// <summary>
/// For the newsletter.
/// </summary>
public class UserNewsletterDto
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserNewsletterDto() { }

    public UserNewsletterDto(UserDto user, string token)
    {
        Email = user.Email;
        Features = user.Features;
        Equipment = user.Equipment;
        FootnoteType = user.FootnoteType;
        LastActive = user.LastActive;
        SendDay = user.SendDay;
        Verbosity = user.Verbosity;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
        Token = token;
    }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    public Equipment Equipment { get; init; }

    public FootnoteType FootnoteType { get; init; }

    public DateOnly? LastActive { get; init; }

    public DayOfWeek SendDay { get; init; }

    public Verbosity Verbosity { get; init; }

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateHelpers.Today.AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
