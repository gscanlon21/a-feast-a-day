using Core.Models.User;
using Data.Entities.User;

namespace Data.Models.Newsletter;

public class FeastContext
{
    public required DateOnly Date { get; init; }
    public required User User { get; init; } = null!;
    public required string Token { get; init; } = null!;

    /// <summary>
    /// The user's average percent daily volume for each nutrient.
    /// </summary>
    public required IDictionary<Nutrients, double?>? WeeklyNutrientsRDA { get; init; }
    public required IDictionary<Nutrients, double?>? WeeklyNutrientsTUL { get; init; }
    public required double WeeklyNutrientsWeeks { get; init; }

    /// <summary>
    /// Is this workout being generated for a date in the past.
    /// </summary>
    public bool IsBackfill => Date != User.TodayOffset;
}
