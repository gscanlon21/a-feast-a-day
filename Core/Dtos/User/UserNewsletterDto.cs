using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User;

/// <summary>
/// For the newsletter
/// </summary>
public class UserNewsletterDto
{
    public UserNewsletterDto() { }

    public UserNewsletterDto(UserDto user, string token)
    {
        Id = user.Id;
        Email = user.Email;
        Features = user.Features;
        FootnoteType = user.FootnoteType;
        LastActive = user.LastActive;
        SendDays = user.SendDays;
        Verbosity = user.Verbosity;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
        Token = token;
    }

    public UserNewsletterDto(FeastContext context) : this(context.User, context.Token)
    {
    }

    public int Id { get; init; }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; init; }

    public DateOnly? LastActive { get; init; }

    [Display(Name = "Send Days")]
    public Days SendDays { get; init; }

    [Display(Name = "Email Verbosity")]
    public Verbosity Verbosity { get; init; }

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
