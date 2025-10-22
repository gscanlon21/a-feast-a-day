namespace Data.Entities.Microbiome;

internal class Symptom_Significant
{
    public int? SymptomId { get; set; }

    public string Source { get; set; }

    public int? TaxonCnt { get; set; }

    public int? CompoundCnt { get; set; }

    public int? EnzymeCnt { get; set; }
}

