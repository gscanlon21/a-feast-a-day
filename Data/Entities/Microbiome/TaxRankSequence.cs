using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class TaxRankSequence
{
    [Key]
    [Required]
    public string TaxRank { get; set; }

    [Required]
    public int TaxSeq { get; set; }
}
