using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

class StatsTable_Taxon
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public int? Obs { get; set; }

    public string Percentiles { get; set; }

    public double? Mean { get; set; }

    public double? StdDev { get; set; }

    public double? Median { get; set; }

    public double? LowLimit { get; set; }

    public double? HighLimit { get; set; }

    public double? LowPercentile { get; set; }

    public double? HighPercentile { get; set; }

    public double? LowPercentage { get; set; }

    public double? HighPercentage { get; set; }

    public double? BoxPlotLow { get; set; }

    public double? BoxPlotHigh { get; set; }

    public double? P15 { get; set; }

    public double? P85 { get; set; }

    //  AS (case when ([mean]-(1.96)*[Stddev])>(0) then round([mean]-(1.96)*[Stddev],(1)) else (0) end),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? LabLow { get; private set; }

    //  AS (round([mean]+(1.96)*[Stddev],(1))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? LabHigh { get; private set; }
}
