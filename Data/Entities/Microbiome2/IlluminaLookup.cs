using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class IlluminaLookup
{
    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Order { get; set; }

    public string? Class { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    [Key]
    public int? Taxon { get; set; }
}
