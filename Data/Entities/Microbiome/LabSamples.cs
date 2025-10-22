using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("lab_samples")]
[DebuggerDisplay("{Name,nq}")]
public class LabSamples
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LabSampleId { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

    [Required]
    public string LabTitle { get; set; } = string.Empty;

    [Required]
    public string LabCode { get; set; } = string.Empty;

    public string? LabDate { get; set; }

    public string? LabNotes { get; set; }

    public int? SampleId { get; set; }

    public int? PDFEmail { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
