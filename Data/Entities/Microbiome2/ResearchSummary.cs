using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("research_summary")]
[DebuggerDisplay("{Name,nq}")]
public class ResearchSummary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Key, Column(Order = 0)]
    public int SymptomId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public string Src { get; set; } = null!;

    public double? WithMean { get; set; }

    public double? WithoutMean { get; set; }

    public double? TScore { get; set; }

    public double? DF { get; set; }

    [Required]
    public string Probability { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
