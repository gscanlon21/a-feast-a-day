using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("lab_sample_bacteria")]
[DebuggerDisplay("{Name,nq}")]
public class LabSampleBacteria
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Key, Column(Order = 0)]
    public int LabSampleId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    public double Shift { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

