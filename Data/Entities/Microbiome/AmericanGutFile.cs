using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("AmericanGutFile")]
public class AmericanGutFile
{
    [Key]
    [Column(Order = 0)]
    [Required]
    public string TaxName { get; set; } = string.Empty;

    [Key]
    [Column(Order = 1)]
    [Required]
    public string TaxRank { get; set; } = string.Empty;

    [Required]
    public int CountNorm { get; set; }
}
