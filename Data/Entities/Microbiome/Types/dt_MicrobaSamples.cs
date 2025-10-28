namespace Data.Entities.Microbiome.Types;

public class dt_MicrobaSamples
{
    public int? SampleId { get; set; }
    public string Phylum { get; set; }
    public string? Family { get; set; }
    public string? Genus { get; set; }
    public string? Species { get; set; }
    public double Abundance { get; set; }
    public double? RangeLow { get; set; }
    public double? RangeHigh { get; set; }
}

