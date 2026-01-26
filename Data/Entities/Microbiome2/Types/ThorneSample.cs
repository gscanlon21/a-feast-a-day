using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome.Types;


[Table("thorne_sample")]
[DebuggerDisplay("{Name,nq}")]
public class ThorneSample
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string Domain { get; set; } = null!;
    public double Abundance { get; set; }
    public double? Percentile { get; set; }
    public int? Taxon { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
