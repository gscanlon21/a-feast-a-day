using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("metabolites")]
[DebuggerDisplay("{Name,nq}")]
public class Metabolites
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string? Metabolite { get; set; }

    public string? Bacteria { get; set; }

    [Column("Taxon ID")]
    public double? TaxonID { get; set; }

    public string? Rank { get; set; }

    [Column("Reference URL")]
    public string? ReferenceURL { get; set; }

    public string? F6 { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
