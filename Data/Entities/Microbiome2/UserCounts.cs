using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class UserCounts
{
    [Key, Column(Order = 0)]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    public int UserId { get; set; }

    public int? Count { get; set; }

    [Required]
    public int Count_Norm { get; set; }

    public double? Percentile { get; set; }

    //  AS (round([Count_Norm]/(10000.0),(4))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double Percentage { get; private set; }

    public double? ZeroPercentile { get; set; }
}
