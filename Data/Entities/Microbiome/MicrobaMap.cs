using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microba_map")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobaMap
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    public string Phylum { get; set; } = string.Empty;

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    public int? Taxon { get; set; }

    public string? Working { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
