using Core.Models;
using Core.Models.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.External;

[Table("dietary_intake")]
[DebuggerDisplay("{Key}")]
public class DietaryIntake
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// Use the generated name in Nutrients.
    /// The USDA's Name's may be clones with different Measures, so there is ambiguity there.
    /// </summary>
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

    [Display(Name = "Calories Per Gram", Description = "Calories Per Gram")]
    public int CaloriesPerGram { get; set; }

    [Display(Name = "Checked", Description = "Checked")]
    public DateOnly Checked { get; set; } = DateHelpers.Today;

    [Display(Name = "Updated", Description = "Updated")]
    public DateOnly Updated { get; set; } = DateHelpers.Today;

    [Display(Name = "Source", Description = "Source")]
    public string Source { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is DietaryIntake other
        && other.Id == Id;
}
