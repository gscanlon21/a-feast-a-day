namespace Data.Models;

public record DailyAllowance(
    double Min,
    double Max,
    string Measure,
    string Multiplier,
    int CaloriesPerGram,
    string Person
);