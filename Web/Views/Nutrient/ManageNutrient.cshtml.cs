using Data.Entities.External;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


[Table("dietary_intake")]
[DebuggerDisplay("{Key}")]
public class DietaryIntakeViewModel
{
    public DietaryIntakeViewModel() { }
    public DietaryIntakeViewModel(DietaryIntake other)
    {
        Id = other.Id;
        Key = other.Key;
        Min = other.Min;
        Max = other.Max;
        Person = other.Person;
        Measure = other.Measure;
        Multiplier = other.Multiplier;
        CaloriesPerGram = other.CaloriesPerGram;
        Updated = other.Updated;
        Source = other.Source;
    }

    public int Id { get; init; }

    /// <summary>
    /// Use the generated name in Nutrients.
    /// The USDA's Name's may be clones with different Measures, so there is ambiguity there.
    /// </summary>
    [Display(Name = "Key", Description = "Use the generated name in Nutrients. The USDA's Name's may be clones with different Measures, so there is ambiguity there")]
    public string Key { get; set; } = null!;

    [Display(Name = "Min", Description = "Min")]
    public double? Min { get; set; }

    [Display(Name = "Max", Description = "Max")]
    public double? Max { get; set; }

    [Display(Name = "Person", Description = "Person")]
    public Person Person { get; set; }

    [Display(Name = "Measure", Description = "Measure")]
    public Measure Measure { get; set; }

    [Display(Name = "Multiplier", Description = "Multiplier")]
    public Multiplier Multiplier { get; set; }

    [Display(Name = "Calories Per Gram", Description = "Calories Per Gram")]
    public int CaloriesPerGram { get; set; }

    [Display(Name = "Updated", Description = "Updated")]
    public DateOnly Updated { get; set; }

    [Display(Name = "Source", Description = "Source")]
    public string? Source { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is DietaryIntakeViewModel other
        && other.Id == Id;
}
