using Core.Models;
using Core.Models.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.External;

[Table("dietary_intake")]
[DebuggerDisplay("{Key}: {Min}-{Max} {Measure}/{Multiplier}")]
public class DietaryIntake
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// Use the generated name in Nutrients.
    /// The USDA's Name's may be clones with different Measures, so there is ambiguity there.
    /// </summary>
    public string Key { get; set; } = null!;

    public double? Min { get; set; }

    public double? Max { get; set; }

    public Person Person { get; set; }

    public Measure Measure { get; set; }

    public Multiplier Multiplier { get; set; }

    public int CaloriesPerGram { get; set; }

    public DateOnly Checked { get; set; } = DateHelpers.Today;

    public DateOnly Updated { get; set; } = DateHelpers.Today;

    public string Source { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is DietaryIntake other
        && other.Id == Id;
}
