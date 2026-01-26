using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class TaxRankFilter
{
    [Key]
    [Required]
    public string TaxRank { get; set; } = null!;

    [Required]
    public int FilterId { get; set; }
}
