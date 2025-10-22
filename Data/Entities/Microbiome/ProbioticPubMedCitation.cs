using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("probiotic_pubmed_citation")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticPubMedCitation
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public int Pcid { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


