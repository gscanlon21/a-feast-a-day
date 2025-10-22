using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("condition_progression")]
[DebuggerDisplay("{Name,nq}")]
public class ConditionProgression
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public string FromCondition { get; set; } = null!;

    [Key, Column(Order = 1)]
    [Required]
    public string ToCondition { get; set; } = null!;

    [Required]
    public double Matches { get; set; }

    [Required]
    public double Total { get; set; }

    [Required]
    public double Possible { get; set; }

    // AS (case when [Total]<[possible] then ((100.0)*[Matches])/[Total] else ((100.0)*[Matches])/[Possible] end),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double Percentage { get; private set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

