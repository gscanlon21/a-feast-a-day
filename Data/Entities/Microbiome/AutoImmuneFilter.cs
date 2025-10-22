using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class AutoImmuneFilter
{
    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public string Direction { get; set; } = null!;

    [Required]
    public double Weight { get; set; }

    [Required]
    [Column("Tax_rank")]
    public string TaxRank { get; set; } = null!;
}
