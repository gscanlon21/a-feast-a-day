using ADay.Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Nutrients;
using Core.Models.Recipe;

namespace Core.Consts;

/// <summary>
/// Shared user consts.
/// </summary>
public static class UserConsts
{
    public const string DemoUser = "demo@afeastaday.com";
    public const string DemoToken = "00000000-0000-0000-0000-000000000000";

    public const int SendHourMin = 0;
    public const int SendHourDefault = 0;
    public const int SendHourMax = 23;

    public const double MinFontSizeMin = .7;
    public const double MinFontSizeDefault = .7;
    public const double MinFontSizeStep = .1;
    public const double MinFontSizeMax = 1.3;

    public const int IngredientsMin = 5;
    public const int IngredientsMax = 10;
    public const int IngredientsRange = IngredientsMax - IngredientsMin + 1;

    public const int SectionWeightMin = 0;
    public const int SectionWeightMax = 10;

    public const int LagRefreshXWeeksMin = 0;
    public const int LagRefreshXWeeksDefault = 0;
    public const int LagRefreshXWeeksMax = 12;

    public const int PadRefreshXWeeksMin = 0;
    public const int PadRefreshXWeeksDefault = 0;
    public const int PadRefreshXWeeksMax = 12;

    public const int FootnoteCountMin = 0;
    public const int FootnoteCountTopDefault = 2;
    public const int FootnoteCountBottomDefault = 2;
    public const int FootnoteCountMax = 4;

    public const int AtLeastXNutrientsPerRecipeMin = 1;
    public const int AtLeastXNutrientsPerRecipeDefault = 5;
    public const int AtLeastXNutrientsPerRecipeMax = 10;

    public const DayOfWeek SendDayDefault = DayOfWeek.Sunday;

    public const DataSource DataSourceDefault = DataSource.USDA;

    public const IngredientOrder IngredientOrderDefault = IngredientOrder.OrderUsed;

    public const Verbosity VerbosityDefault = Verbosity.TotalTime | Verbosity.Servings | Verbosity.Images;

    public const FootnoteType FootnoteTypeDefault = FootnoteType.CookingTips | FootnoteType.CookingFacts | FootnoteType.DigestionTips | FootnoteType.DigestionFacts
        | FootnoteType.HealthTips | FootnoteType.HealthFacts | FootnoteType.GoodVibes | FootnoteType.Mindfulness;

    public const Equipment EquipmentDefault = Equipment.Microwave | Equipment.Oven | Equipment.Stove | Equipment.Broiler
        | Equipment.Refrigerator | Equipment.Freezer | Equipment.Toaster | Equipment.SlowCooker | Equipment.PotatoMasher
        | Equipment.SpiceGrinder;

    /// <summary>
    /// How many months until the user's account is disabled for inactivity.
    /// </summary>
    public const int DisableAfterXMonths = 3;

    /// <summary>
    /// How many months until the user's account is deleted for inactivity.
    /// </summary>
    public const int DeleteAfterXMonths = 6;

    /// <summary>
    /// How many months until the user's newsletter logs are deleted.
    /// </summary>
    public const int DeleteFeastsAfterXMonths = 12;
}
