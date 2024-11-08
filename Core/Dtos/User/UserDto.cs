using Core.Consts;
using Core.Interfaces.User;
using Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

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
    [Required]
    public string Email { get; init; } = null!;

    /// <summary>
    /// User has accepted the current Terms of Use when they signed up.
    /// </summary>
    [Required]
    public bool AcceptedTerms { get; init; }

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    [Required]
    public FootnoteType FootnoteType { get; set; }

    /// <summary>
    /// Days the user want to send the newsletter.
    /// </summary>
    [Required]
    public DayOfWeek SendDay { get; set; }

    [Required]
    public Equipment Equipment { get; set; }

    /// <summary>
    /// What hour of the day (UTC) should we send emails to this user.
    /// </summary>
    [Required, Range(UserConsts.SendHourMin, UserConsts.SendHourMax)]
    public int SendHour { get; set; }

    /// <summary>
    /// What's the maximum number of ingredients you'd like in recipes?
    /// </summary>
    [Range(UserConsts.IngredientsMin, UserConsts.IngredientsMax)]
    public int? MaxIngredients { get; set; }

    /// <summary>
    /// When this user was created.
    /// </summary>
    [Required]
    public DateOnly CreatedDate { get; init; }

    /// <summary>
    /// What level of detail the user wants in their newsletter?
    /// </summary>
    [Required]
    public Verbosity Verbosity { get; set; }

    /// <summary>
    /// What allergens does the user want in their newsletter?
    /// </summary>
    [Required]
    public Allergens ExcludeAllergens { get; set; }

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
    #region NotMapped

    /// <summary>
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public bool IsDemoUser => Features.HasFlag(Features.Demo);

    #endregion
    #region Navigation Properties

    [JsonInclude]
    public virtual ICollection<UserServingDto> UserServings { get; init; } = [];

    #endregion

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserDto other
        && other.Id == Id;
}
