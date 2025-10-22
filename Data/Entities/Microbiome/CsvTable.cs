using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class CsvTable
{
    [Key, Required]
    public int Taxon { get; set; }

    public string? TaxRank { get; set; }

    public string? TaxName { get; set; }

    public string? Parent { get; set; }

    public int? Count { get; set; }

    public int? CountNorm { get; set; }
}
