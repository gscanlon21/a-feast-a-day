namespace Data.Entities.Microbiome;

internal class Missing
{
    public int? SampleId { get; set; }

    public string? TKey { get; set; }

    public double? Abundance { get; set; }

    public double? Percentile { get; set; }

    public double? Per20 { get; set; }

    public double? Per80 { get; set; }
}

