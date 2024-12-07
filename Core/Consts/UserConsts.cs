using Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;

namespace Core.Consts;

/// <summary>
/// Shared user consts.
/// </summary>
public class UserConsts
{
    public const string DemoUser = "demo@afeastaday.com";
    public const string DemoToken = "00000000-0000-0000-0000-000000000000";

    public const int SendHourMin = 0;
    public const int SendHourDefault = 0;
    public const int SendHourMax = 23;

    public const int IngredientsMin = 4;
    public const int IngredientsMax = 10;

    public const int SectionWeightMin = 0;
    public const int SectionWeightMax = 35;

    public const int LagRefreshXWeeksMin = 0;
    public const int LagRefreshXWeeksDefault = 0;
    public const int LagRefreshXWeeksMax = 12;

    public const int PadRefreshXWeeksMin = 0;
    public const int PadRefreshXWeeksDefault = 0;
    public const int PadRefreshXWeeksMax = 12;

    public const int FootnoteCountMin = 1;
    public const int FootnoteCountTopDefault = 2;
    public const int FootnoteCountBottomDefault = 2;
    public const int FootnoteCountMax = 4;

    public const int AtLeastXNutrientsPerRecipeMin = 1;
    public const int AtLeastXNutrientsPerRecipeDefault = 6;
    public const int AtLeastXNutrientsPerRecipeMax = 9;

    public const DayOfWeek SendDayDefault = DayOfWeek.Sunday;

    public const Equipment EquipmentDefault = Equipment.Oven | Equipment.Stove;

    public const IngredientOrder IngredientOrderDefault = IngredientOrder.OrderUsed;

    public const Verbosity VerbosityDefault = Verbosity.TotalTime | Verbosity.Servings | Verbosity.Images;

    public const FootnoteType FootnotesDefault = FootnoteType.CookingTips | FootnoteType.IngredientTips
        | FootnoteType.HealthTips | FootnoteType.HealthFacts | FootnoteType.GoodVibes | FootnoteType.Mindfulness;

    /// <summary>
    /// This shouldn't be too high (>12) or else the program will spend too much time trying 
    /// to get the user in range and end up not working or overworking specific muscles in the interim.
    /// 
    /// This shouldn't be too low (<12) or else the muscle target value will drop too much
    /// during rest days and overwork the user the next time they see a workout.
    /// </summary>
    public const int NutrientVolumeWeeks = 12;

    /// <summary>
    /// 8 because we want to leave the user with at least one week of data 
    /// and muscle targets only take effect after 1 week (MuscleTargetsTakeEffectAfterXWeeks).
    /// </summary>
    public const int TrainingVolumeClearDays = 8;

    /// <summary>
    /// After how many weeks until muscle targets start taking effect.
    /// </summary>
    public const int NutrientTargetsTakeEffectAfterXWeeks = 1;

    /// <summary>
    /// Add some padding to the upper-bounds of the nutrient targets.
    /// </summary>
    public const double NutrientTargetsScale = 1.05;

    /// <summary>
    /// How many custom user_frequency records do we allow per user?
    /// </summary>
    public const int MaxUserFrequencies = 7;

    /// <summary>
    /// How much to increment the user_nutrient target ranges with each increment?
    /// </summary>
    public const int IncrementNutrientTargetBy = 10;

    /// <summary>
    /// The percent relative to the nutrient's RDA that is used in the nutrient targets.
    /// </summary>
    public const int NutrientTargetDefaultPercent = 100;

    /// <summary>
    /// The max percent relative to the RDA to use as the nutrients default target TUL when there is none.
    /// </summary>
    public const int NutrientTargetTULDefault = 1000;

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
