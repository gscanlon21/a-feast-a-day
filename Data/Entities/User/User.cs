using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// User who signed up for the newsletter.
/// </summary>
[Table("user"), Comment("User who signed up for the newsletter")]
[Index(nameof(Email), IsUnique = true)]
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class User
{
    public class Consts
    {
        public const int FootnoteCountMin = 1;
        public const int FootnoteCountTopDefault = 2;
        public const int FootnoteCountBottomDefault = 2;
        public const int FootnoteCountMax = 4;

        public const int AtLeastXUniqueMusclesPerExercise_FlexibilityMin = 1;
        public const int AtLeastXUniqueMusclesPerExercise_FlexibilityDefault = 3;
        public const int AtLeastXUniqueMusclesPerExercise_FlexibilityMax = 4;

        public const int AtLeastXUniqueMusclesPerExercise_MobilityMin = 1;
        public const int AtLeastXUniqueMusclesPerExercise_MobilityDefault = 3;
        public const int AtLeastXUniqueMusclesPerExercise_MobilityMax = 4;

        public const int AtLeastXUniqueMusclesPerExercise_AccessoryMin = 1;
        public const int AtLeastXUniqueMusclesPerExercise_AccessoryDefault = 3;
        public const int AtLeastXUniqueMusclesPerExercise_AccessoryMax = 4;

        public const double WeightIsolationXTimesMoreMin = 1;
        public const double WeightIsolationXTimesMoreDefault = 1.5;
        public const double WeightIsolationXTimesMoreMax = 2;

        public const double WeightSecondaryMusclesXTimesLessMin = 2;
        public const double WeightSecondaryMusclesXTimesLessDefault = 3;
        public const double WeightSecondaryMusclesXTimesLessMax = 4;
    }

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public User() { }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    public User(string email, bool acceptedTerms)
    {
        if (!acceptedTerms)
        {
            throw new ArgumentException("User must accept the Terms of Use.", nameof(acceptedTerms));
        }

        Email = email.Trim();
        AcceptedTerms = acceptedTerms;

        SendDays = UserConsts.DaysDefault;
        SendHour = UserConsts.SendHourDefault;
        Verbosity = UserConsts.VerbosityDefault;
        FootnoteType = UserConsts.FootnotesDefault;

        CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [Required]
    public string Email { get; private init; } = null!;

    /// <summary>
    /// User has accepted the current Terms of Use when they signed up.
    /// </summary>
    [Required]
    public bool AcceptedTerms { get; private init; }

    /// <summary>
    /// User prefers static instead of dynamic images?
    /// </summary>
    [Required]
    public bool ShareMyRecipes { get; set; }

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
    public DateOnly CreatedDate { get; private init; }

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

    /// <summary>
    /// How many days of the week is the user working out?
    /// 
    /// Don't use in queries, is not mapped currently.
    /// </summary>
    [NotMapped]
    public int WorkoutsDays => BitOperations.PopCount((ulong)SendDays);

    #endregion
    #region Advanced Preferences

    public int FootnoteCountTop { get; set; } = Consts.FootnoteCountTopDefault;
    public int FootnoteCountBottom { get; set; } = Consts.FootnoteCountBottomDefault;

    #endregion
    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(UserIngredientGroup.User))]
    public virtual ICollection<UserIngredientGroup> UserIngredientGroups { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserToken.User))]
    public virtual ICollection<UserToken> UserTokens { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserServing.User))]
    public virtual ICollection<UserServing> UserServings { get; private init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFeast.User))]
    public virtual ICollection<UserFeast> UserWorkouts { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Recipe.User))]
    public virtual ICollection<Recipe> UserRecipes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserRecipe.User))]
    public virtual ICollection<UserRecipe> UserUserRecipes { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserIngredient.User))]
    public virtual ICollection<UserIngredient> UserIngredients { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserEmail.User))]
    public virtual ICollection<UserEmail> UserEmails { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Footnote.UserFootnote.User))]
    public virtual ICollection<Footnote.UserFootnote> UserFootnotes { get; private init; } = null!;

    #endregion
}
