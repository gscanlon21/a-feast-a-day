using Data.Entities.External;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Web.Views.Nutrient;

public class ManageNutrientViewModel
{
    public required string Token { get; init; }
    public required string Nutrient { get; init; }
    public required Data.Entities.Users.User User { get; init; }
    public required List<DietaryIntakeViewModel> DietaryIntakes { get; init; }
    public bool? WasUpdated { get; init; }
}


[DebuggerDisplay("{Key}: {Min}-{Max} {Measure}/{Multiplier}")]
public class DietaryIntakeViewModel
{
    public DietaryIntakeViewModel() { }
    public DietaryIntakeViewModel(DietaryIntake other)
    {
        Id = other.Id;
        Key = other.Key;
        Min = other.Min;
        Max = other.Max;
        Notes = other.Notes;
        Source = other.Source;
        Person = other.Person;
        Measure = other.Measure;
        Multiplier = other.Multiplier;
        CaloriesPerGram = other.CaloriesPerGram;
        LastUpdated = other.LastUpdated;
    }

    public int Id { get; init; }

    [Display(Name = "Key", Description = "Use the generated name in Nutrients. The USDA's Name's may be clones with different Measures, so there is ambiguity there")]
    public string Key { get; set; } = null!;

    [Display(Name = "RDA", Description = "Recommended Daily Allowance")]
    public double? Min { get; set; }

    [Display(Name = "TUL", Description = "Tolerable Upper Limit")]
    public double? Max { get; set; }

    [Display(Name = "Person", Description = "Person")]
    public Person Person { get; set; }

    [Display(Name = "Measure", Description = "Measure")]
    public Measure Measure { get; set; }

    [Display(Name = "Multiplier", Description = "Multiplier")]
    public Multiplier Multiplier { get; set; }

    [Display(Name = "Calories/Gram", Description = "Calories Per Gram")]
    public int CaloriesPerGram { get; set; }

    [Display(Name = "Updated", Description = "Updated")]
    public DateOnly LastUpdated { get; set; }

    [Display(Name = "Source", Description = "Source")]
    public string? Source { get; set; }

    [Display(Name = "Notes", Description = "Notes")]
    public string? Notes { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is DietaryIntakeViewModel other
        && other.Id == Id;
}
