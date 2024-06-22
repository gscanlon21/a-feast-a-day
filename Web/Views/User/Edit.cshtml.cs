﻿using Core.Consts;
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
/// For CRUD actions
/// </summary>
public class UserEditViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    public DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public UserEditViewModel() { }

    public UserEditViewModel(Data.Entities.User.User user, string token)
    {
        User = user;
        Email = user.Email;
        SendDays = user.SendDays;
        NewsletterEnabled = user.NewsletterEnabled;
        NewsletterDisabledReason = user.NewsletterDisabledReason;
        Verbosity = user.Verbosity;
        FootnoteType = user.FootnoteType;
        SendHour = user.SendHour;
        Equipment = user.Equipment;
        MaxIngredients = user.MaxIngredients;
        ExcludeAllergens = user.ExcludeAllergens;
        AtLeastXServingsPerRecipe = user.AtLeastXServingsPerRecipe;
        Token = token;
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

    [Display(Name = "Substitute Ingredients", Description = "Customize substitute ingredients.")]
    public IList<UserIngredientViewModel> UserIngredients { get; set; } = [];

    [Display(Name = "Exclude Ingredients", Description = "Customize ingredient exclusions.")]
    public IList<int>? IngredientExclusionIds { get; private init; } = [];

    public IList<Data.Entities.User.Ingredient> Ingredients { get; set; } = [];

    [Range(1, 9)]
    [Display(Name = "At Least X Servings Per Recipe", Description = "Customize recipe servings.")]
    public int AtLeastXServingsPerRecipe { get; set; } = 3;

    [Required]
    [Display(Name = "Exclude Allergens", Description = "What allergens to exclude?")]
    public Allergy ExcludeAllergens { get; set; }

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
    [Display(Name = "Send Days", Description = "What days do you want to receive new recipes?")]
    public Days SendDays { get; set; }

    public Days[]? SendDaysBinder
    {
        get => Enum.GetValues<Days>().Where(e => SendDays.HasFlag(e)).ToArray();
        set => SendDays = value?.Aggregate(Days.None, (a, e) => a | e) ?? Days.None;
    }

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

    public Allergy[]? AllergyBinder
    {
        get => Enum.GetValues<Allergy>().Where(e => ExcludeAllergens.HasFlag(e)).ToArray();
        set => ExcludeAllergens = value?.Aggregate(Allergy.None, (a, e) => a | e) ?? Allergy.None;
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

    public class UserIngredientViewModel
    {
        public int UserId { get; set; }

        [Display(ShortName = "Ingredient", Name = "Base Ingredient")]
        public int IngredientId { get; init; }

        [Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
        public int SubstituteIngredientId { get; init; }
    }

    public class UserServingViewModel
    {
        public UserServingViewModel() { }

        public UserServingViewModel(UserServing userMuscleMobility)
        {
            UserId = userMuscleMobility.UserId;
            Section = userMuscleMobility.Section;
            Count = userMuscleMobility.Count;
        }

        public Section Section { get; init; }

        public int UserId { get; init; }

        [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
        public int Count { get; set; }
    }
}