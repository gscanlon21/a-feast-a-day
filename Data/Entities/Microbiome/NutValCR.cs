using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("nut_val_cR")]
[DebuggerDisplay("{Name,nq}")]
public class NutValCR
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string? NDBNo { get; set; }

    public string? NutrientName { get; set; }

    public string? NutrrNo { get; set; }

    public double? XbarAdj { get; set; }

    public double? SE { get; set; }

    public double? N { get; set; }

    public float? Low { get; set; }

    public float? High { get; set; }

    public string? CC { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

