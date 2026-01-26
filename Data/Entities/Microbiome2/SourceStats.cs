using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SourceStats
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    public double Frequency { get; set; }

    [Required]
    public double Average { get; set; }
}
