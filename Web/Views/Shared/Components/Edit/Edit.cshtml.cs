using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.Index;

namespace Web.Views.Shared.Components.Edit;


/// <summary>
/// For CRUD actions.
/// </summary>
public class EditComponentViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public EditComponentViewModel() { }

    public EditComponentViewModel(Data.Entities.Users.User user, string token)
    {
        User = user;
        Token = token;
        Email = user.Email;
        SendDay = user.SendDay;
        SendHour = user.SendHour;
        Verbosity = user.Verbosity;
        Allergens = user.Allergens;
        FootnoteType = user.FootnoteType;
        MaxIngredients = user.MaxIngredients;
        FontSizeAdjust = user.FontSizeAdjust;
        NewsletterEnabled = user.NewsletterEnabled;
        NewsletterDisabledReason = user.NewsletterDisabledReason;
        // In case a single equipment becomes a double, keep it checked.
        Equipment = EnumExtensions.GetSingleOrDoubleValues<Equipment>()
            .Where(e => user.Equipment.HasAnyFlag(e))
            .Aggregate(user.Equipment, (c, n) => c | n);
    }

    [ValidateNever]
    public Data.Entities.Users.User User { get; set; } = null!;

    public string Token { get; set; } = null!;

    /// <summary>
    /// If null, user has not yet tried to update.
    /// If true, user has successfully updated.
    /// If false, user failed to update.
    /// </summary>
    public bool? WasUpdated { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required, RegularExpression(UserCreateViewModel.EmailRegex, ErrorMessage = UserCreateViewModel.EmailRegexError)]
    [Display(Name = "Email", Description = "")]
    public string Email { get; init; } = null!;

    /// <summary>
    /// Types of footnotes to show to the user.
    /// </summary>
    [Display(Name = "Footnotes", Description = "What types of footnotes do you want to see?")]
    public FootnoteType FootnoteType { get; set; }

    [Display(Name = "Disabled Reason")]
    public string? NewsletterDisabledReason { get; init; }

    [Display(Name = "Subscribe to Recipe Emails", Description = "Receive your recipes via email.")]
    public bool NewsletterEnabled { get; init; }

    [Required]
    [Display(Name = "Email Verbosity", Description = "What level of detail do you want to receive with each recipe?")]
    public Verbosity Verbosity { get; set; }

    [Display(Name = "Recipe Sections")]
    public IList<UserSectionViewModel> UserSections { get; set; } = [];

    [Display(Name = "Family Members")]
    public IList<UserFamilyViewModel> UserFamilies { get; set; } = [];

    [Required]
    [Display(Name = "Allergens", Description = "What allergens to exclude?")]
    public Allergens Allergens { get; set; }

    [Required]
    [Display(Name = "Cooking Equipment", Description = "What cooking equipment do you have access to?")]
    public Equipment Equipment { get; set; }

    [Required, Range(UserConsts.SendHourMin, UserConsts.SendHourMax)]
    [Display(Name = "Send Time (UTC)", Description = "What hour of the day (UTC) do you want to receive new recipes?")]
    public int SendHour { get; init; }

    [Required, Range(UserConsts.FontSizeAdjustMin, UserConsts.FontSizeAdjustMax)]
    [Display(Name = "Font Size Adjust", Description = "Font size adjustment.")]
    public int FontSizeAdjust { get; init; }

    [Range(UserConsts.IngredientsMin, UserConsts.IngredientsMax)]
    [Display(Name = "Maximum Ingredients", Description = "What's the maximum number of ingredients you'd like in your recipes?")]
    public int? MaxIngredients { get; init; }

    [Required]
    [Display(Name = "Send Day", Description = "What days do you want to receive new recipes?")]
    public DayOfWeek SendDay { get; set; }

    public Verbosity[]? VerbosityBinder
    {
        get => Enum.GetValues<Verbosity>().Where(e => Verbosity.HasFlag(e)).ToArray();
        set => Verbosity = value?.Aggregate(Verbosity.None, (a, e) => a | e) ?? Verbosity.None;
    }

    public Equipment[]? EquipmentBinder
    {
        get => Enum.GetValues<Equipment>().Where(e => Equipment.HasFlag(e)).ToArray();
        set => Equipment = value?.Aggregate(Equipment.None, (a, e) => a | e) ?? Equipment.None;
    }

    public Allergens[]? AllergenBinder
    {
        get => Enum.GetValues<Allergens>().Where(e => Allergens.HasFlag(e)).ToArray();
        set => Allergens = value?.Aggregate(Allergens.None, (a, e) => a | e) ?? Allergens.None;
    }

    public FootnoteType[]? FootnoteTypeBinder
    {
        get => Enum.GetValues<FootnoteType>().Where(e => FootnoteType.HasFlag(e)).ToArray();
        set => FootnoteType = value?.Aggregate(FootnoteType.None, (a, e) => a | e) ?? FootnoteType.None;
    }

    public class UserFamilyViewModel
    {
        public int UserId { get; set; }

        [Range(UserFamily.Consts.WeightMin, UserFamily.Consts.WeightMax)]
        [Display(Name = "Weight (kg)")]
        public int Weight { get; init; } = UserFamily.Consts.WeightDefault;

        [Range(UserFamily.Consts.CaloriesPerDayMin, UserFamily.Consts.CaloriesPerDayMax)]
        [Display(Name = "Calories Per Day")]
        public int CaloriesPerDay { get; init; } = UserFamily.Consts.CaloriesPerDayDefault;

        [Required]
        [Display(Name = "Person")]
        public Person Person { get; init; }

        public bool Hide { get; set; }
    }

    public class UserSectionViewModel
    {
        public UserSectionViewModel() { }

        public UserSectionViewModel(UserSection userSection)
        {
            Weight = userSection.Weight;
            UserId = userSection.UserId;
            Section = userSection.Section;
            AtLeastXNutrientsPerRecipe = userSection.AtLeastXNutrientsPerRecipe;
        }

        public int UserId { get; init; }

        public Section Section { get; init; }

        [Display(Name = "Weight", Description = "A relative weight of servings.")]
        [Range(UserConsts.SectionWeightMin, UserConsts.SectionWeightMax)]
        public int Weight { get; set; }

        [Display(Name = "At Least X Nutrients Per Recipe", Description = "A higher value will result in fewer recipes and decreased recipe variety.")]
        [Range(UserConsts.AtLeastXNutrientsPerRecipeMin, UserConsts.AtLeastXNutrientsPerRecipeMax)]
        public int AtLeastXNutrientsPerRecipe { get; set; } = UserConsts.AtLeastXNutrientsPerRecipeDefault;
    }
}
