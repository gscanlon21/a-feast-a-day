using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microba_insight")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobaInsight
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    public string Phylum { get; set; } = string.Empty;

    [Required]
    public string TaxRank { get; set; } = string.Empty;

    [Required]
    public string FullName { get; set; } = string.Empty;

    public int? Taxon { get; set; }

    public double? LowLevel { get; set; }

    public string? HighLevel { get; set; }

    [StringLength(100)]
    public string? Adapt { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
