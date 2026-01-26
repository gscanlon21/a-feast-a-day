using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("precision_biome_taxa")]
[DebuggerDisplay("{Name,nq}")]
public class PrecisionBiomeTaxa
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string? Sample { get; set; }

    public double? NcbiId { get; set; }

    public string? Domain { get; set; }

    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    public double? MeanAbundance { get; set; }
    public double? Q0Abundance { get; set; }
    public double? Q10Abundance { get; set; }
    public double? Q20Abundance { get; set; }
    public double? Q30Abundance { get; set; }
    public double? Q40Abundance { get; set; }
    public double? Q50Abundance { get; set; }
    public double? Q60Abundance { get; set; }
    public double? Q70Abundance { get; set; }
    public double? Q80Abundance { get; set; }
    public double? Q90Abundance { get; set; }
    public double? Q100Abundance { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

