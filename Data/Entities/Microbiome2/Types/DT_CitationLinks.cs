namespace Data.Entities.Microbiome.Types;

public class DT_CitationLinks
{
    public int? Cid { get; set; }
    public string Pmcid { get; set; } = null!;
    public string Doi { get; set; } = null!;
    public string DirectUrl { get; set; } = null!;
}

