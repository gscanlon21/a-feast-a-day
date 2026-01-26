using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("end_product")]
[DebuggerDisplay("{Name,nq}")]
public class EndProduct
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EpId { get; set; }

    [Required, Column("EndProduct")]
    public string EndProductName { get; set; } = string.Empty;

    public double? AverageCount { get; set; }

    public string? DataPunkUri { get; set; }

    public double? StandardDeviation { get; set; }

    [Required]
    public int Cnt { get; set; }

    public string? Json { get; set; } // varchar(max)

    [Required]
    public double Density { get; set; }

    // AS ('/Library/EndProductProducers?epid='+CONVERT([varchar](11),[epid])) PERSISTED,
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; private set; }

    // AS ('/Library/Bacteria?epid='+CONVERT([varchar](11),[epid])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? BacteriaUrl { get; private set; }

    // AS ('/Library/Statistics?epid='+CONVERT([varchar](11),[epid])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? StatisticsUrl { get; private set; }

    public double? NormalLow { get; set; }

    public double? NormalHigh { get; set; }

    public int? Mid2 { get; set; }

    public double? KMLow { get; set; }

    public double? KMHigh { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
