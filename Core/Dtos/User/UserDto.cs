using Core.Interfaces.User;
using Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.Diagnostics;

namespace Core.Dtos.User;

/// <summary>
/// User who signed up for the newsletter.
/// </summary>
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class UserDto : IUser
{
    public int Id { get; init; }

    public string Email { get; init; } = null!;

    public DayOfWeek SendDay { get; set; }

    public Equipment Equipment { get; set; }

    public int? MaxIngredients { get; set; }

    public Verbosity Verbosity { get; set; }

    public Allergens Allergens { get; set; }

    public DateOnly? LastActive { get; set; }

    public DateOnly CreatedDate { get; init; }

    public int FontSizeAdjust { get; init; }

    public int FootnoteCountTop { get; set; }

    public int FootnoteCountBottom { get; set; }

    public FootnoteType FootnoteType { get; set; }

    public IngredientOrder IngredientOrder { get; set; }

    public Features Features { get; set; } = Features.None;

    public bool IsDemoUser => Features.HasFlag(Features.Demo);

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserDto other
        && other.Id == Id;
}
