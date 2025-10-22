using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("not_healthy_predictor")]
[DebuggerDisplay("{Name,nq}")]
public class NotHealthyPredictor
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public int Taxon { get; set; }

    [Key, Required]
    public string TaxName { get; set; }

    [Required]
    public double Health { get; set; }

    [Required]
    public double Unhealthy { get; set; }

    public double? Low { get; set; }

    public double? High { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
