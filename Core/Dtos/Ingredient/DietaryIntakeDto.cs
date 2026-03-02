using Core.Models.Nutrients;

namespace Core.Dtos.Ingredient;

public class DietaryIntakeDto
{
    public int Id { get; init; }

    public string Key { get; init; } = null!;

    public double? Min { get; init; }

    public double? Max { get; init; }

    public Person Person { get; init; }

    public Measure Measure { get; init; }

    public Multiplier Multiplier { get; init; }

    public int CaloriesPerGram { get; init; }

    public DateOnly Updated { get; init; }

    public string Source { get; init; } = null!;
}
