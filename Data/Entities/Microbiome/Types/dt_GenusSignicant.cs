namespace Data.Entities.Microbiome.Types;

public class dt_GenusSignicant
{
    public string Source { get; set; } = null!;
    public int Taxon { get; set; }
    public int? SymptomId { get; set; }
    public string? Direction { get; set; }
    public decimal? HighValue { get; set; }
    public decimal? LowValue { get; set; }
    public double? Prevalence { get; set; }
    public double? Chi2 { get; set; }
}

