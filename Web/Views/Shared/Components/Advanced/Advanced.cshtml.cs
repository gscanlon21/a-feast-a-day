using Core.Consts;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Advanced;

public class AdvancedViewModel
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public AdvancedViewModel() { }

    public AdvancedViewModel(Data.Entities.User.User user, string token)
    {
        Token = token;
        Email = user.Email;

        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
    }

    public bool IsNotDefault => FootnoteCountTop != UserConsts.FootnoteCountTopDefault
        || FootnoteCountBottom != UserConsts.FootnoteCountBottomDefault;

    public string Token { get; init; } = null!;
    public string Email { get; init; } = null!;

    [Display(Name = "Number of Footnotes (Top)")]
    public int FootnoteCountTop { get; set; }

    [Display(Name = "Number of Footnotes (Bottom)")]
    public int FootnoteCountBottom { get; set; }
}
