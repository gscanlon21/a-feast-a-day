using Core.Consts;
using Core.Dtos.Footnote;
using Core.Dtos.Newsletter;
using Core.Dtos.Recipe;
using Core.Models.Footnote;
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
[Table("user")]
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class UserDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    /// Days the user want to skip the newsletter.
    /// </summary>
    [NotMapped]
    public Days RestDays => Days.All & ~SendDays;

    /// <summary>
    /// Days the user want to send the newsletter.
    /// </summary>
    [Required]
    public Days SendDays { get; set; }

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
    /// Offset of today taking into account the user's SendHour.
    /// </summary>
    public DateOnly TodayOffset => DateOnly.FromDateTime(DateTime.UtcNow.AddHours(-1 * SendHour));

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
    public Allergy ExcludeAllergens { get; set; }

    /// <summary>
    /// When was the user last active?
    /// 
    /// Is `null` when the user has not confirmed their account.
    /// </summary>
    public DateOnly? LastActive { get; set; } = null;

    /// <summary>
    /// User would like to receive the workouts in emails?
    /// </summary>
    public string? NewsletterDisabledReason { get; set; } = null;

    /// <summary>
    /// What features should the user have access to?
    /// </summary>
    public Features Features { get; set; } = Features.None;

    public int AtLeastXServingsPerRecipe { get; set; }

    #region Advanced Preferences

    public int FootnoteCountTop { get; set; }

    public int FootnoteCountBottom { get; set; }

    public int AtLeastXUniqueNutrientsPerRecipe { get; set; }

    #endregion
    #region NotMapped

    /// <summary>
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public bool IsDemoUser => Features.HasFlag(Features.Demo);

    /// <summary>
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public bool NewsletterEnabled => NewsletterDisabledReason == null;

    #endregion
    #region Navigation Properties

    [JsonIgnore]
    public virtual ICollection<UserFamilyDto> UserFamilies { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserNutrientDto> UserNutreints { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserIngredientDto> UserIngredients { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserTokenDto> UserTokens { get; init; } = [];

    [JsonInclude]
    public virtual ICollection<UserServingDto> UserServings { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserFeastDto> UserFeasts { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<RecipeDto> Recipes { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserRecipeDto> UserRecipes { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<IngredientDto> Ingredients { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<UserEmailDto> UserEmails { get; init; } = null!;

    [JsonIgnore]
    public virtual ICollection<FootnoteDto> UserFootnotes { get; init; } = null!;

    #endregion
}
