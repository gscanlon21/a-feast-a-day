using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class SampleTaxonRatio
{
    [Key, Column(Order = 0)]
    [Required]
    public int RatioId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int SampleId { get; set; }

    public double? Ratio { get; set; }

    public double? Percentile { get; set; }
}

