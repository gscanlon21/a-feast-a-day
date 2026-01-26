using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class TaxRankSequence
{
    [Key]
    [Required]
    public string TaxRank { get; set; } = null!;

    [Required]
    public int TaxSeq { get; set; }
}
