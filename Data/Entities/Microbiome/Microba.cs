using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microba")]
[DebuggerDisplay("{Name,nq}")]
public class Microba
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    public int Taxon { get; set; }

    public string? TaxRank { get; set; }

    [Required]
    public string GtdbName { get; set; } = string.Empty;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
