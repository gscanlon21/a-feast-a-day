using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("Dosages")]
public class Dosages
{
    [Key, Column(Order = 0)]
    public int DosageId { get; set; }

    [Key, Column(Order = 1)]
    public int Mid2 { get; set; }

    public int? Cid { get; set; }

    public string? TrialName { get; set; }

    public string? TrialUrl { get; set; }

    [Required]
    public string Units { get; set; } = string.Empty;

    [Required]
    public double Dosage { get; set; }

    public bool? Effective { get; set; }

    public bool? Toxic { get; set; }
}
