using Core.Consts;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.Index;

namespace Web.Views.User;


/// <summary>
/// For CRUD actions.
/// </summary>
public class UserEditViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserEditViewModel() { }

    public UserEditViewModel(Data.Entities.User.User user, string token)
    {
        User = user;
        Token = token;
        Email = user.Email;
        SendDay = user.SendDay;
        SendHour = user.SendHour;
        Verbosity = user.Verbosity;
        FootnoteType = user.FootnoteType;
        MaxIngredients = user.MaxIngredients;
        ExcludeAllergens = user.ExcludeAllergens;
        NewsletterEnabled = user.NewsletterEnabled;
        NewsletterDisabledReason = user.NewsletterDisabledReason;
        // In case a single equipment becomes a double, keep it checked.
        Equipment = EnumExtensions.GetSingleOrDoubleValues32<Equipment>()
            .Where(e => user.Equipment.HasAnyFlag32(e))
            .Aggregate(user.Equipment, (c, n) => c | n);
    }

    [ValidateNever]
    public Data.Entities.User.User User { get; set; } = null!;

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

    [Display(Name = "Weekly Servings", Description = "Customize weekly servings.")]
    public IList<UserServingViewModel> UserServings { get; set; } = [];

    [Display(Name = "Family Members", Description = "Customize family members.")]
    public IList<UserFamilyViewModel> UserFamilies { get; set; } = [];

    [Required]
    [Display(Name = "Exclude Allergens", Description = "What allergens to exclude?")]
    public Allergens ExcludeAllergens { get; set; }

    [Required]
    [Display(Name = "Cooking Equipment", Description = "What cooking equipment do you have access to?")]
    public Equipment Equipment { get; set; }

    [Required, Range(UserConsts.SendHourMin, UserConsts.SendHourMax)]
    [Display(Name = "Send Time (UTC)", Description = "What hour of the day (UTC) do you want to receive new recipes?")]
    public int SendHour { get; init; }

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

    public Allergens[]? AllergyBinder
    {
        get => Enum.GetValues<Allergens>().Where(e => ExcludeAllergens.HasFlag(e)).ToArray();
        set => ExcludeAllergens = value?.Aggregate(Allergens.None, (a, e) => a | e) ?? Allergens.None;
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

        [Display(Name = "Person")]
        public Person Person { get; init; }

        public bool Hide { get; set; }
    }

    public class UserServingViewModel
    {
        public UserServingViewModel() { }

        public UserServingViewModel(UserServing userMuscleMobility)
        {
            UserId = userMuscleMobility.UserId;
            Section = userMuscleMobility.Section;
            Count = userMuscleMobility.Count;
            AtLeastXServingsPerRecipe = userMuscleMobility.AtLeastXServingsPerRecipe;
            AtLeastXNutrientsPerRecipe = userMuscleMobility.AtLeastXNutrientsPerRecipe;
        }

        public Section Section { get; init; }

        public int UserId { get; init; }

        [Display(Name = "Servings", Description = "A relative weight of servings.")]
        [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
        public int Count { get; set; }

        [Display(Name = "At Least X Nutrients Per Recipe", Description = "A higher value will result in fewer recipes and decreased recipe variety.")]
        [Range(UserConsts.AtLeastXNutrientsPerRecipeMin, UserConsts.AtLeastXNutrientsPerRecipeMax)]
        public int AtLeastXNutrientsPerRecipe { get; set; } = UserConsts.AtLeastXNutrientsPerRecipeDefault;

        [Display(Name = "At Least X Servings Per Recipe", Description = "A higher value will result in fewer recipes and decreased recipe variety.")]
        [Range(UserConsts.AtLeastXServingsPerRecipeMin, UserConsts.AtLeastXServingsPerRecipeMax)]
        public int AtLeastXServingsPerRecipe { get; set; } = UserConsts.AtLeastXServingsPerRecipeDefault;
    }
}
