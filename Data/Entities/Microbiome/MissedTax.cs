using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class MissedTax
{
    [Required]
    public string Kingdom { get; set; } = null!;

    [Required]
    public string Phylum { get; set; } = null!;

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    [Required]
    public double Count { get; set; }

    public double? Count_Norm { get; set; }

    public int? Taxon { get; set; }
}
