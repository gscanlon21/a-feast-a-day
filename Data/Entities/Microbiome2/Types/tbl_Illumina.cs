namespace Data.Entities.Microbiome.Types;

public class tbl_Illumina
{
    public string? Kingdom { get; set; }
    public string? Phylum { get; set; }
    public string? Order { get; set; }
    public string? Class { get; set; }
    public string? Family { get; set; }
    public string? Genus { get; set; }
    public string? Species { get; set; }
    public double? Num_Of_Hits { get; set; }
    public double? Percent { get; set; }
}
