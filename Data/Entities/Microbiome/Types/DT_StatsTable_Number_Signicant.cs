namespace Data.Entities.Microbiome.Types;

public class DT_StatsTable_Number_Signicant
{
    public int Id { get; set; }
    public int SymptomId { get; set; }
    public string Source { get; set; } = string.Empty;
    public double? Below15 { get; set; }
    public double? Above15 { get; set; }
    public double? WithSymptoms { get; set; }
    public double? BelowChi2 { get; set; }
    public double? AboveChi2 { get; set; }
}

