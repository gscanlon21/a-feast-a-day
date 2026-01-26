using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome.Types;


[Table("thorne_sample_full")]
[DebuggerDisplay("{Name,nq}")]
public class ThorneSampleFull
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string Domain { get; set; } = null!;
    public string KINGDOM { get; set; } = null!;
    public string PHYLUM { get; set; } = null!;
    public string CLASS { get; set; } = null!;
    public string ORDER { get; set; } = null!;
    public string FAMILY { get; set; } = null!;
    public string GENUS { get; set; } = null!;
    public string SPECIES { get; set; } = null!;
    public string SEROGROUP { get; set; } = null!;
    public string SEROTYPE { get; set; } = null!;
    public string SUBSPECIES { get; set; } = null!;
    public string STRAIN { get; set; } = null!;
    public string ISOLATE { get; set; } = null!;
    public double? Abundance { get; set; }
    public double? P20 { get; set; }
    public double? P80 { get; set; }
    public double? Percentile { get; set; }
    public int? Taxon { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
