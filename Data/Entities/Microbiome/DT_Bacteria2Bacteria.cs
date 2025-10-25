namespace Data.Entities.Microbiome;

public class DT_Bacteria2Bacteria
{
    public int TaxonA { get; set; }
    public int TaxonB { get; set; }
    public double Slope { get; set; }
    public double Intecept { get; set; }  // Note: "Intecept" matches the SQL column name
    public double R2 { get; set; }
    public int Obs { get; set; }
    public string? Source { get; set; }
}
