namespace Terminal.Models;

internal record DailyAllowance(
    double Min,
    double Max,
    string Measure,
    string Multiplier,
    int CaloriesPerGram,
    string Person
);