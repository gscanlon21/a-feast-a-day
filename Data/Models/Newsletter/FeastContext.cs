﻿using Core.Models.User;
using Data.Entities.User;

namespace Data.Models.Newsletter;

public class FeastContext
{
    public required DateOnly Date { get; init; }
    public User User { get; init; } = null!;
    public string Token { get; init; } = null!;

    /// <summary>
    /// The user's average percent daily volume for each nutrient.
    /// </summary>
    public required IDictionary<Nutrients, double?>? WeeklyNutrientsRDA { get; init; }
    public required IDictionary<Nutrients, double?>? WeeklyNutrientsTUL { get; init; }
    public required double WeeklyNutrientsWeeks { get; init; }
}
