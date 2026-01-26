using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("probiotic_pubmed")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticPubMed
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Psid { get; set; }

    [Required]
    public string ProbioticSpecies { get; set; } = null!;

    [Required]
    public string SellerName { get; set; } = null!;

    [Required]
    public string SellerUtl { get; set; } = null!;

    public int? Taxon { get; set; }

    public string? SearchKey { get; set; }

    public int? Mid2 { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
