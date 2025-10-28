namespace Data.Entities.Microbiome.Types;

public class dt_StatsIdTable
{
    public int? Id { get; set; }
    public int? Obs { get; set; }
    public string? Percentiles { get; set; }
    public double? Mean { get; set; }
    public double? Stddev { get; set; }
    public double? Median { get; set; }
    public double? Lowlimit { get; set; }
    public double? Highlimit { get; set; }
    public double? Lowpercentile { get; set; }
    public double? Highpercentile { get; set; }
}
