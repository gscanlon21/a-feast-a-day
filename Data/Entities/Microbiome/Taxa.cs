using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("taxa")]
[DebuggerDisplay("{Name,nq}")]
public class Taxa
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public double? TaxonId { get; set; }

    public int? Taxon { get; set; }

    public string Label { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string Phylum { get; set; } = null!;

    public string Class { get; set; } = null!;

    public string Order { get; set; } = null!;

    public string Family { get; set; } = null!;

    public string Genus { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string IdL6 { get; set; } = null!;

    public string Taxonomy { get; set; } = null!;

    public string IdeLevel { get; set; } = null!;

    public string NCBIOutlink { get; set; } = null!;

    public string BacterioNetOutlink { get; set; } = null!;

    public string OmniHabitat { get; set; } = null!;

    public string OmniPheno { get; set; } = null!;

    public string OmniUse { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
