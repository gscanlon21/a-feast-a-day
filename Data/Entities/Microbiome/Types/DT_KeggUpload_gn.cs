namespace Data.Entities.Microbiome.Types;

public class DT_KeggUpload_gn
{
    public string Entry { get; set; } = null!;
    public int Taxon { get; set; }
    public string? Disease { get; set; }
}

