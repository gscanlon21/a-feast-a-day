using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User;

/// <summary>
/// For the newsletter.
/// </summary>
public class UserNewsletterDto
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserNewsletterDto() { }

    public UserNewsletterDto(FeastContext context) : this(context.User, context.Token) { }
    public UserNewsletterDto(UserDto user, string token)
    {
        Id = user.Id;
        Email = user.Email;
        Features = user.Features;
        FootnoteType = user.FootnoteType;
        LastActive = user.LastActive;
        SendDay = user.SendDay;
        Verbosity = user.Verbosity;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
        Token = token;
    }

    public int Id { get; init; }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; init; }

    public DateOnly? LastActive { get; init; }

    [Display(Name = "Send Day")]
    public DayOfWeek SendDay { get; init; }

    [Display(Name = "Email Verbosity")]
    public Verbosity Verbosity { get; init; }

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateHelpers.Today.AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
