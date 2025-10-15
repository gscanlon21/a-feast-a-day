using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("kegg_compound")]
[DebuggerDisplay("{Name,nq}")]
public class KEGG_Compound
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public int CPId { get; set; }

    [Key]
    [Required]
    public string CPD { get; set; } = string.Empty;

    public string? CompoundName { get; set; }

    public string? OtherName { get; set; }

    [StringLength(50)]
    public string? Formula { get; set; }

    // ('https://www.kegg.jp/entry/'+[CPD]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; private set; }

    public double? Mass { get; set; }

    public double? ProducedNormalLow { get; set; }

    public double? ProducedNormalHigh { get; set; }

    public double? ConsumedNormalLow { get; set; }

    public double? ConsumedNormalHigh { get; set; }

    public string? OATS { get; set; }

    public int? ProductCount { get; set; }

    public string? SubstrateCount { get; set; }

    public string? Supplement { get; set; }

    public string? HealthName { get; set; }

    public string? Description { get; set; }

    public bool? Checked { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
