using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class AtlasBiomedImport_Errors
{
    [Required]
    public string Col1 { get; set; } = null!;

    public string? Col2 { get; set; }

    public string? Col3 { get; set; }

    public string? Col4 { get; set; }

    public string? Col5 { get; set; }

    public string? Col6 { get; set; }

    [Required]
    public double PC { get; set; }

    public int? OTU { get; set; }

    public int? Taxon { get; set; }

    public int? Count_Norm { get; set; }

    public string? TaxRank { get; set; }

    public string? Email { get; set; }
}
