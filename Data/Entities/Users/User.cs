using Core.Interfaces.User;
using Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Newsletter;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

/// <summary>
/// User who signed up for the newsletter.
/// </summary>
[Table("user")]
[Index(nameof(Email), IsUnique = true)]
[DebuggerDisplay("Email = {Email}, LastActive = {LastActive}")]
public class User : IUser
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
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
        CreatedDate = DateHelpers.Today;
        SendDay = UserConsts.SendDayDefault;
        SendHour = UserConsts.SendHourDefault;
        Equipment = UserConsts.EquipmentDefault;
        Verbosity = UserConsts.VerbosityDefault;
        FootnoteType = UserConsts.FootnoteTypeDefault;
    }

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
    public int SendHour { get; set; } = UserConsts.SendHourDefault;

    [Required, Range(UserConsts.FontSizeAdjustMin, UserConsts.FontSizeAdjustMax)]
    public int FontSizeAdjust { get; set; } = UserConsts.FontSizeAdjustDefault;

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
    /// Offset of today taking into account the user's SendHour and SendDay.
    /// </summary>
    public DateOnly StartOfWeekOffset => Features.HasFlag(Features.Debug) ? TodayOffset
        : TodayOffset.AddDays(-1 * WeekdayDifference);

    private int WeekdayDifference => SendDay > TodayOffset.DayOfWeek
        ? 7 - Math.Abs((int)SendDay - (int)TodayOffset.DayOfWeek)
        : Math.Abs((int)TodayOffset.DayOfWeek - (int)SendDay);

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

    /// <summary>
    /// What allergens does the user want in their newsletter?
    /// </summary>
    public Allergens Allergens => UserFoodPreferences
        .Where(f => f.FoodPreference == FoodPreference.Exclude)
        .Aggregate(Allergens.None, (c, n) => c | n.Allergen);

    #region Advanced Preferences

    /// <summary>
    /// Order of how ingredients are listed in a recipe.
    /// </summary>
    public IngredientOrder IngredientOrder { get; set; } = UserConsts.IngredientOrderDefault;

    /// <summary>
    /// User footnotes.
    /// </summary>
    [Range(UserConsts.FootnoteCountMin, UserConsts.FootnoteCountMax)]
    public int FootnoteCountTop { get; set; } = UserConsts.FootnoteCountTopDefault;

    /// <summary>
    /// System footnotes.
    /// </summary>
    [Range(UserConsts.FootnoteCountMin, UserConsts.FootnoteCountMax)]
    public int FootnoteCountBottom { get; set; } = UserConsts.FootnoteCountBottomDefault;

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

    [JsonIgnore, InverseProperty(nameof(UserFamily.User))]
    public virtual ICollection<UserFamily> UserFamilies { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserNutrient.User))]
    public virtual ICollection<UserNutrient> UserNutrients { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserIngredient.User))]
    public virtual ICollection<UserIngredient> UserIngredients { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFoodPreference.User))]
    public virtual List<UserFoodPreference> UserFoodPreferences { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserRecipeIngredient.User))]
    public virtual ICollection<UserRecipeIngredient> UserRecipeIngredients { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserToken.User))]
    public virtual ICollection<UserToken> UserTokens { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserSection.User))]
    public virtual ICollection<UserSection> UserSections { get; init; } = [];

    [JsonIgnore, InverseProperty(nameof(UserFeast.User))]
    public virtual ICollection<UserFeast> UserFeasts { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Recipes.Recipe.User))]
    public virtual ICollection<Recipes.Recipe> Recipes { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserRecipe.User))]
    public virtual ICollection<UserRecipe> UserRecipes { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Entities.Ingredients.Ingredient.User))]
    public virtual ICollection<Ingredients.Ingredient> Ingredients { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(UserEmail.User))]
    public virtual ICollection<UserEmail> UserEmails { get; init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Footnote.UserFootnote.User))]
    public virtual ICollection<Footnote.UserFootnote> UserFootnotes { get; init; } = null!;

    #endregion

    public enum Includes
    {
        None = 0,

        Servings = 1 << 0, // 1
        Families = 1 << 1, // 2,
        Nutrients = 1 << 2, // 4,
        Ingredients = 1 << 3, // 8,
        FoodPreferences = 1 << 4, // 16,

        Newsletter = Servings | Families | FoodPreferences,
        All = Servings | Families | Nutrients | Ingredients | FoodPreferences,
    }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is User other
        && other.Id == Id;
}
