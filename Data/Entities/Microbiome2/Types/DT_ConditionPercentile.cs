namespace Data.Entities.Microbiome.Types;

public class DT_ConditionPercentile
{
    public int? SampleId { get; set; }
    public int? Condid { get; set; }
    public int? Matches { get; set; }
    public double? Percentile { get; set; }
}

