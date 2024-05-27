using Core.Consts;
using Core.Models.Footnote;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.User;

/// <summary>
/// For the newsletter
/// </summary>
public class UserNewsletterViewModel
{
    public int Id { get; init; }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; init; }

    public bool ShareMyRecipes { get; init; }

    public bool IncludeMobilityWorkouts { get; init; }

    public DateOnly? LastActive { get; init; }

    [Display(Name = "Send Days")]
    public Days SendDays { get; init; }

    [JsonInclude]
    public ICollection<UserRecipeViewModel> UserExercises { get; init; } = null!;

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
