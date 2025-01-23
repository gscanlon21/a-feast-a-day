using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// American Gut.
/// </summary>
[Table("american_gut")]
[DebuggerDisplay("{Name,nq}")]
public class AmericanGut
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int UserId { get; init; }

    public string TaxName { get; init; } = null!;

    public string TaxRank { get; init; } = null!;

    public int CountNorm { get; init; }

    public int? Taxon { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is AmericanGut other
        && other.Id == Id;
}
