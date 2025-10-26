using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

class StatsTable_IndexName
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public string IndexName { get; set; }

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
}

