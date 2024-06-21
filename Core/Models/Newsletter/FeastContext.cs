using Core.Dtos.User;
using Core.Models.User;

namespace Data.Models.Newsletter;

public class FeastContext
{
    public required DateOnly Date { get; init; }
    public UserDto User { get; init; } = null!;
    public string Token { get; init; } = null!;
    public int DaysUntilNextNewsletter { get; init; } = 1;
    public required IDictionary<Nutrients, int?>? WeeklyNutrients { get; init; }
    public required double WeeklyNutrientsWeeks { get; init; }
}
