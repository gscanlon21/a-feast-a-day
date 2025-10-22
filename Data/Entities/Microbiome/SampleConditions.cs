using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("sample_conditions")]
[DebuggerDisplay("{Name,nq}")]
public class SampleConditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int CondId { get; set; }

    public int? Percentage { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

