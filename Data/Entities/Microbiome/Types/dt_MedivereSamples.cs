using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_MedivereSamples
{
    public string TaxRank { get; set; } = null!;
    public string? TaxName { get; set; }
    public int? Count { get; set; }
    public int? CountNorm { get; set; }
    public int Taxon { get; set; }
}
