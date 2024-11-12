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

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    public FootnoteType FootnoteType { get; set; }

    /// <summary>
    /// Days the user want to send the newsletter.
    /// </summary>
    public DayOfWeek SendDay { get; set; }

    /// <summary>
    /// What equipment does the user have access to?
    /// </summary>
    public Equipment Equipment { get; set; }

    /// <summary>
    /// What's the maximum number of ingredients you'd like in recipes?
    /// </summary>
    public int? MaxIngredients { get; set; }

    /// <summary>
    /// What level of detail the user wants in their newsletter?
    /// </summary>
    public Verbosity Verbosity { get; set; }

    /// <summary>
    /// What allergens does the user want in their newsletter?
    /// </summary>
    public Allergens Allergens { get; set; }

    /// <summary>
    /// When was the user last active?
    /// 
    /// Is `null` when the user has not confirmed their account.
    /// </summary>
    public DateOnly? LastActive { get; set; } = null;

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    public Features Features { get; set; } = Features.None;


    #region Advanced Preferences

    /// <summary>
    /// Order of how ingredients are listed in a recipe.
    /// </summary>
    public IngredientOrder IngredientOrder { get; set; }

    public int FootnoteCountTop { get; set; }

    public int FootnoteCountBottom { get; set; }

    #endregion


    public bool IsDemoUser => Features.HasFlag(Features.Demo);

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserDto other
        && other.Id == Id;
}
