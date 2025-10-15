using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("_antibacterial_activity")]
[DebuggerDisplay("{Name,nq}")]
public class AntibacterialActivity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? Mid2 { get; set; }

    public string? F1 { get; set; }

    public string? F2 { get; set; }

    public string? F3 { get; set; }

    public double? F4 { get; set; }

    public string? F5 { get; set; }

    public string? F6 { get; set; }

    public string? F7 { get; set; }

    [Column("lowest MIC found")]
    public string? LowestMICFound { get; set; }

    public double? F9 { get; set; }

    public double? F10 { get; set; }

    public string? F11 { get; set; }

    public string? F12 { get; set; }

    public string? F13 { get; set; }

    public string? F14 { get; set; }

    public string? F15 { get; set; }

    public string? F16 { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

