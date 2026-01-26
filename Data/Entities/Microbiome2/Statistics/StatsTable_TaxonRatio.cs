using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

public class StatsTable_TaxonRatio
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; } = null!;

    [Key, Column(Order = 1)]
    [Required]
    public int RatioId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Percentile { get; set; }

    [Required]
    public double Value { get; set; }
}

