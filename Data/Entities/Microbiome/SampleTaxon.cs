using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class SampleTaxon
{
    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public double? Abundance { get; set; }

    public double? Percentile { get; set; }

    public double? Per20 { get; set; }

    public double? Per80 { get; set; }
}
