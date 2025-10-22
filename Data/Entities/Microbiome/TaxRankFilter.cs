using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class TaxRankFilter
{
    [Key]
    [Required]
    public string TaxRank { get; set; }

    [Required]
    public int FilterId { get; set; }
}
