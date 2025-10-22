using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class UserCountsThorne
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int Taxon { get; set; }

    public int? Count { get; set; }

    [Required]
    public double CountNorm { get; set; }

    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    public double? Percentile { get; set; }

    // AS (round([Count_Norm]/(10000.0),(4))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? Percentage { get; set; }

    public double? ZeroPercentile { get; set; }
}

