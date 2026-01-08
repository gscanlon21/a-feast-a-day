namespace Data.Entities.Microbiome.Temp;

public class Temp_Thorne
{
    public string TKey { get; set; } = null!;

    public double? Abundance { get; set; }

    public double? Percentile { get; set; }

    public double? Per20 { get; set; }

    public double? Per80 { get; set; }
}
