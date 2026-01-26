using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("category_upload")]
[DebuggerDisplay("{Name,nq}")]
public class CategoryUpload
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    public double? Rawcount { get; set; }

    public double? Ratio { get; set; }

    public int? Taxon { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
