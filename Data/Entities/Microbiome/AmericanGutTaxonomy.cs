using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// American Gut Taxonomy.
/// CONSTRAINT [PK_AmericanGutTaxonomy] PRIMARY KEY CLUSTERED ([tax_name] ASC)
/// </summary>
[Table("american_gut_taxonomy")]
[DebuggerDisplay("{Name,nq}")]
public class AmericanGutTaxonomy
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string TaxName { get; init; } = null!;

    public int? Taxon { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is AmericanGutTaxonomy other
        && other.Id == Id;
}
