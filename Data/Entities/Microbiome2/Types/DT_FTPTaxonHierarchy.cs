namespace Data.Entities.Microbiome.Types;

public class DT_FTPTaxonHierarchy
{
    public int? Taxon { get; set; }
    public int? ParentTaxon { get; set; }
    public string? Rank { get; set; }
}
