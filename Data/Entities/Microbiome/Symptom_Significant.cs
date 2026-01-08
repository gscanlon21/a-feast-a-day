namespace Data.Entities.Microbiome;

public class Symptom_Significant
{
    public int? SymptomId { get; set; }

    public string Source { get; set; } = null!;

    public int? TaxonCnt { get; set; }

    public int? CompoundCnt { get; set; }

    public int? EnzymeCnt { get; set; }
}

