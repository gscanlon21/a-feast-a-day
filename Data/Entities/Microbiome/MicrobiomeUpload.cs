using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microbiome_upload")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobiomeUpload
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? Taxon { get; set; }

    [Required]
    public string TaxName { get; set; }

    public string? TaxRank { get; set; }

    public int? Count { get; set; }

    [Required]
    public int CountNorm { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

