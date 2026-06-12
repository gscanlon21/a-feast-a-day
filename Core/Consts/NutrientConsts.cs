
namespace Core.Consts;

public static class NutrientConsts
{
    public const int NutrientTargetMin = 0;
    public const int NutrientTargetMax = 100;
    public const double NutrientTargetStep = 0.25;

    /// <summary>
    /// How to round nutrient targets.
    /// </summary>
    public const MidpointRounding RoundBy = MidpointRounding.ToZero;

    /// <summary>
    /// This shouldn't be too high (>12) or else the program will spend too much time trying 
    /// to get the user in range and end up not working or overworking specific nutrients in the interim.
    /// 
    /// This shouldn't be too low (<12) or else the nutrient target value will drop too much
    /// during over the course of the week and overwork the user the next time they see a feast.
    /// </summary>
    public const int NutrientVolumeWeeks = 12;

    /// <summary>
    /// After how many weeks until nutrient targets start taking effect.
    /// </summary>
    public const int NutrientTargetsTakeEffectAfterXWeeks = 1;

    /// <summary>
    /// The percent relative to the nutrient's RDA that is used in the nutrient targets.
    /// </summary>
    public const int MaxTargetPercent = 100;

    /// <summary>
    /// The scale relative to the RDA to use as the TUL when there is none.
    /// </summary>
    public const int ScaleWhenNoTUL = 2;
}
