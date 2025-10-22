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

    public string Label { get; set; }

    public string Domain { get; set; }

    public string Phylum { get; set; }

    public string Class { get; set; }

    public string Order { get; set; }

    public string Family { get; set; }

    public string Genus { get; set; }

    public string Species { get; set; }

    public string IdL6 { get; set; }

    public string Taxonomy { get; set; }

    public string IdeLevel { get; set; }

    public string NCBIOutlink { get; set; }

    public string BacterioNetOutlink { get; set; }

    public string OmniHabitat { get; set; }

    public string OmniPheno { get; set; }

    public string OmniUse { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
