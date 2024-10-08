﻿using Core.Dtos.User;

namespace Core.Models.Newsletter;

public class FeastContext
{
    public required DateOnly Date { get; init; }
    public UserDto User { get; init; } = null!;
    public string Token { get; init; } = null!;

    /// <summary>
    /// The user's average percent daily volume for each nutrient.
    /// </summary>
    public required IDictionary<User.Nutrients, double?>? WeeklyNutrientsRDA { get; init; }
    public required IDictionary<User.Nutrients, double?>? WeeklyNutrientsTUL { get; init; }
    public required double WeeklyNutrientsWeeks { get; init; }
}
