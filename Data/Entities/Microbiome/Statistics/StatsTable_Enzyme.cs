using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

public class StatsTable_Enzyme
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public string ECKey { get; set; } = null!;

    public int? Obs { get; set; }

    public string Percentiles { get; set; } = null!;

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
