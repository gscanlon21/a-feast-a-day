namespace Data.Entities.Microbiome.Types;

public class dt_CherryPick
{
    public string Source { get; set; } = null!;
    public int SymptomId { get; set; }
    public int Taxon { get; set; }
    public double Percentile { get; set; }
    public string Direction { get; set; } = null!;
}
